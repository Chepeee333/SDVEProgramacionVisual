namespace SDVE;

/// <summary>Formulario principal: desde aquí se abre cada módulo en su propio formulario.</summary>
public partial class MenuPrincipalForm : Form
{
    public MenuPrincipalForm()
    {
        InitializeComponent();
    }

    private void btnConvocatorias_Click(object? sender, EventArgs e)
    {
        using var f = new ConvocatoriasForm();
        f.ShowDialog(this);
    }

    private void btnPapeleta_Click(object? sender, EventArgs e)
    {
        using var f = new PapeletaForm(Datos.Candidatos.Keys.ToList());
        f.ShowDialog(this);
    }

    private void btnResultados_Click(object? sender, EventArgs e)
    {
        using var f = new ResultadosForm();
        f.ShowDialog(this);
    }

    private void btnExportar_Click(object? sender, EventArgs e)
    {
        using var f = new ExportarForm();
        f.ShowDialog(this);
    }

    private void btnSalir_Click(object? sender, EventArgs e) => Close();
}
