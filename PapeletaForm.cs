namespace SDVE;

/*
 CONTEXTO GENERAL:
 Este formulario es la papeleta electrónica del Sistema Digital de Votación Estudiantil (SDVE).
 Muestra solo las convocatorias que el alumno eligió en la pantalla anterior.
 Cada convocatoria se muestra como un recuadro con los candidatos oficiales,
 la opción de voto en blanco y una casilla de texto para escribir un candidato no registrado (write-in).
 Al confirmar, se valida que el alumno haya contestado todas las convocatorias elegidas
 y se guardan los votos en la clase Datos.
*/

public partial class PapeletaForm : Form
{
    // Controles creados dinámicamente por convocatoria
    private Dictionary<string, List<RadioButton>> opciones = new();
    private Dictionary<string, RadioButton> radiosBlanco = new();
    private Dictionary<string, RadioButton> radiosWriteIn = new();
    private Dictionary<string, TextBox> cajasWriteIn = new();

    public PapeletaForm()
    {
        InitializeComponent();

        // Mostrar el código del alumno en el título
        if (Datos.VotanteActual != null)
        {
            lblTitulo.Text = "🗳  Papeleta electrónica - Alumno " + Datos.VotanteActual.Codigo;
        }

        ArmarPapeleta();
    }

    // Función para armar la papeleta según las convocatorias elegidas
    private void ArmarPapeleta()
    {
        foreach (string conv in Datos.ConvocatoriasSeleccionadas)
        {
            string[] candidatos = Datos.Candidatos[conv];

            GroupBox caja = new GroupBox();
            caja.Text = conv;
            caja.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            caja.Width = 860;
            caja.Margin = new Padding(0, 0, 0, 15);

            List<RadioButton> lista = new();
            int y = 35;

            // Un radio por cada candidato oficial
            foreach (string nombre in candidatos)
            {
                RadioButton rb = new RadioButton();
                rb.Text = nombre;
                rb.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                rb.AutoSize = true;
                rb.Location = new Point(25, y);
                caja.Controls.Add(rb);
                lista.Add(rb);
                y += 32;
            }

            // Radio para voto en blanco
            RadioButton rbBlanco = new RadioButton();
            rbBlanco.Text = Datos.VotoBlanco;
            rbBlanco.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            rbBlanco.AutoSize = true;
            rbBlanco.Location = new Point(25, y);
            caja.Controls.Add(rbBlanco);
            y += 32;

            // Radio y casilla para candidato no registrado (write-in)
            RadioButton rbWriteIn = new RadioButton();
            rbWriteIn.Text = "Candidato no registrado:";
            rbWriteIn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            rbWriteIn.AutoSize = true;
            rbWriteIn.Location = new Point(25, y);
            caja.Controls.Add(rbWriteIn);

            TextBox txt = new TextBox();
            txt.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txt.Width = 350;
            txt.Location = new Point(250, y - 3);
            txt.Enabled = false;
            caja.Controls.Add(txt);

            // Activar la casilla solo si se elige la opción write-in
            rbWriteIn.CheckedChanged += (s, e) =>
            {
                txt.Enabled = rbWriteIn.Checked;
                if (rbWriteIn.Checked) txt.Focus();
            };

            y += 40;
            caja.Height = y + 10;

            panelPapeleta.Controls.Add(caja);

            // Guardar referencias para leerlas al confirmar
            opciones[conv] = lista;
            radiosBlanco[conv] = rbBlanco;
            radiosWriteIn[conv] = rbWriteIn;
            cajasWriteIn[conv] = txt;
        }
    }

    // Botón para confirmar el voto
    private void btnConfirmar_Click(object? sender, EventArgs e)
    {
        if (Datos.VotanteActual == null)
        {
            MessageBox.Show("No hay un votante activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Lista temporal con las respuestas: convocatoria, candidato, write-in
        List<(string conv, string candidato, bool writeIn)> respuestas = new();

        // Validar que se haya contestado cada convocatoria
        foreach (string conv in Datos.ConvocatoriasSeleccionadas)
        {
            RadioButton? elegido = opciones[conv].FirstOrDefault(r => r.Checked);

            if (elegido != null)
            {
                respuestas.Add((conv, elegido.Text, false));
            }
            else if (radiosBlanco[conv].Checked)
            {
                respuestas.Add((conv, Datos.VotoBlanco, false));
            }
            else if (radiosWriteIn[conv].Checked)
            {
                string escrito = cajasWriteIn[conv].Text.Trim();

                if (escrito == "")
                {
                    MessageBox.Show("Escribe el nombre del candidato no registrado en: " + conv,
                        "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                respuestas.Add((conv, escrito, true));
            }
            else
            {
                MessageBox.Show("Falta elegir una opción en: " + conv,
                    "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        // Confirmar antes de guardar
        DialogResult resp = MessageBox.Show("¿Confirmas tu voto? Ya no podrás cambiarlo.",
            "Confirmar voto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resp != DialogResult.Yes) return;

        // Guardar los votos (revisando que no se repita)
        foreach (var r in respuestas)
        {
            if (Datos.YaVoto(Datos.VotanteActual.Codigo, r.conv)) continue;
            Datos.RegistrarVoto(Datos.VotanteActual, r.conv, r.candidato, r.writeIn);
        }

        MessageBox.Show("Tu voto fue registrado. ¡Gracias por participar!",
            "Voto registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Limpiar la sesión y cerrar
        Datos.VotanteActual = null;
        Datos.ConvocatoriasSeleccionadas = new List<string>();
        Close();
    }

    // Botón para cancelar la votación
    private void btnCancelar_Click(object? sender, EventArgs e)
    {
        DialogResult resp = MessageBox.Show("¿Seguro que quieres cancelar? No se guardará ningún voto.",
            "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resp != DialogResult.Yes) return;

        Datos.VotanteActual = null;
        Datos.ConvocatoriasSeleccionadas = new List<string>();
        Close();
    }
}