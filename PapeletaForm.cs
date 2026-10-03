namespace SDVE;

/// <summary>Módulo 2: papeleta electrónica con una sección por elección seleccionada.</summary>
public partial class PapeletaForm : Form
{
    // Constructor sin parámetros: lo necesita el diseñador de Visual Studio.
    public PapeletaForm()
    {
        InitializeComponent();
    }

    public PapeletaForm(IReadOnlyList<string> elecciones) : this()
    {
        lblTitulo.Text = $"🗳  Papeleta electrónica — {elecciones.Count} elección(es)";
        foreach (var eleccion in elecciones)
            panelPapeleta.Controls.Add(new BallotSection(eleccion));
    }

    private void btnCancelar_Click(object? sender, EventArgs e) => Close();

    private void btnConfirmar_Click(object? sender, EventArgs e)
    {
        foreach (var seccion in panelPapeleta.Controls.OfType<BallotSection>())
        {
            if (!seccion.TieneSeleccion)
            {
                MessageBox.Show($"Selecciona una opción en: {seccion.Text}.", "Papeleta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (seccion.WriteInVacio)
            {
                MessageBox.Show($"Escribe el nombre del candidato no registrado en: {seccion.Text}.", "Papeleta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        var r = MessageBox.Show("¿Confirmas tu voto? Esta acción no se puede deshacer.", "Confirmar voto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (r == DialogResult.Yes)
        {
            MessageBox.Show("¡Voto registrado! (maqueta, no se guardó nada)", "SDVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
