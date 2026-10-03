namespace SDVE;

/// <summary>Módulo 3: resultados agregados (tabla, indicadores y gráfica).</summary>
public partial class ResultadosForm : Form
{
    public ResultadosForm()
    {
        InitializeComponent();

        cmbConvocatoria.Items.AddRange(Datos.Candidatos.Keys.ToArray());
        cmbConvocatoria.SelectedIndex = 0;
        cmbAgrupar.SelectedIndex = 1;

        // Datos de ejemplo
        grid.Rows.Add("Ing. en Computación", 320, 240, "75.0 %", "25.0 %");
        grid.Rows.Add("Ing. Informática", 280, 190, "67.9 %", "32.1 %");
        grid.Rows.Add("Ing. en Redes", 210, 150, "71.4 %", "28.6 %");
        grid.Rows.Add("Lic. en Administración", 220, 150, "68.2 %", "31.8 %");
        grid.Rows.Add("Lic. en Contaduría", 170, 116, "68.2 %", "31.8 %");
    }

    private void panelGrafica_Resize(object? sender, EventArgs e) => panelGrafica.Invalidate();

    private void panelGrafica_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        var datos = new (string Nombre, int Votos)[] { ("Azul", 340), ("Verde", 280), ("Roja", 190), ("No reg.", 36) };
        int max = datos.Max(d => d.Votos);
        int margen = 40, anchoBarra = 60, separacion = 30;
        int altoMax = Math.Max(10, panelGrafica.Height - margen * 2 - 20);

        using var fuenteTitulo = new Font("Segoe UI", 11F, FontStyle.Bold);
        using var pincel = new SolidBrush(Color.FromArgb(30, 60, 114));
        g.DrawString("Votos por candidato (ejemplo)", fuenteTitulo, Brushes.Black, 15, 10);

        for (int i = 0; i < datos.Length; i++)
        {
            int alto = (int)((double)datos[i].Votos / max * altoMax);
            int x = margen + i * (anchoBarra + separacion);
            int y = panelGrafica.Height - margen - alto;
            g.FillRectangle(pincel, x, y, anchoBarra, alto);
            g.DrawString(datos[i].Votos.ToString(), Font, Brushes.Black, x + 10, y - 22);
            g.DrawString(datos[i].Nombre, Font, Brushes.Black, x, panelGrafica.Height - margen + 5);
        }
    }
}
