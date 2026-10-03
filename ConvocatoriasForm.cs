namespace SDVE;

/// <summary>Módulo 1: selección de convocatorias y datos del votante.</summary>
public partial class ConvocatoriasForm : Form
{
    public ConvocatoriasForm()
    {
        InitializeComponent();

        cmbCarrera.Items.AddRange(Datos.Carreras);
        cmbCentro.Items.AddRange(Datos.Centros);
        cmbCarrera.SelectedIndex = 0;
        cmbCentro.SelectedIndex = 0;
    }

    private void btnCargar_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Aquí se abriría el selector de archivo con la lista oficial (maqueta).", "SDVE");
    }

    private void btnIniciar_Click(object? sender, EventArgs e)
    {
        var seleccion = new List<string>();
        if (chkSociedad.Checked) seleccion.Add("Sociedad de Alumnos");
        if (chkConsejoU.Checked) seleccion.Add("Consejo Universitario");
        if (chkRepresentantes.Checked) seleccion.Add("Consejo de Representantes");

        if (seleccion.Count == 0)
        {
            MessageBox.Show("Selecciona al menos una convocatoria.", "SDVE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var papeleta = new PapeletaForm(seleccion);
        papeleta.ShowDialog(this);
    }
}
