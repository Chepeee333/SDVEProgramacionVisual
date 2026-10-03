namespace SDVE;

/// <summary>Módulo 4: exportación de resultados a CSV, JSON o XML.</summary>
public partial class ExportarForm : Form
{
    public ExportarForm()
    {
        InitializeComponent();
    }

    private void btnExaminar_Click(object? sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv|JSON (*.json)|*.json|XML (*.xml)|*.xml" };
        if (dlg.ShowDialog(this) == DialogResult.OK) txtRuta.Text = dlg.FileName;
    }

    private void btnExportar_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Exportación simulada (maqueta).", "SDVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
