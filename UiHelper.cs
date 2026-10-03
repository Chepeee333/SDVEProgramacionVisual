using System.Drawing;
using System.Windows.Forms;

namespace SDVE;

/// <summary>Elementos visuales reutilizables para mantener el mismo estilo en todos los formularios.</summary>
internal static class UiHelper
{
    public static readonly Color Primario = Color.FromArgb(30, 60, 114);

    public static Panel Header(string titulo) => new()
    {
        Dock = DockStyle.Top,
        Height = 60,
        BackColor = Primario,
        Controls =
        {
            new Label
            {
                Text = titulo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 14),
            }
        }
    };

    public static Button BotonPrimario(string texto, Point ubicacion, Size tamano, Color? color = null) => new()
    {
        Text = texto,
        Location = ubicacion,
        Size = tamano,
        BackColor = color ?? Primario,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
    };

    public static void ConfigurarFormulario(Form f, string titulo, Size tamano)
    {
        f.Text = titulo;
        f.Size = tamano;
        f.StartPosition = FormStartPosition.CenterParent;
        f.Font = new Font("Segoe UI", 10F);
    }
}
