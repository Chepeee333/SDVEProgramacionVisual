namespace SDVE;

/// <summary>Datos de ejemplo compartidos por los formularios (maqueta).</summary>
internal static class Datos
{
    public static readonly Dictionary<string, string[]> Candidatos = new()
    {
        ["Sociedad de Alumnos"] = new[] { "Planilla Azul - Ana Torres", "Planilla Verde - Luis Ramírez", "Planilla Roja - María Gómez" },
        ["Consejo Universitario"] = new[] { "Carlos Mendoza", "Sofía Herrera", "Jorge Navarro" },
        ["Consejo de Representantes"] = new[] { "Valeria Cruz", "Diego Castillo", "Paola Ibarra" },
    };

    public static readonly string[] Carreras =
        { "Ing. en Computación", "Ing. Informática", "Ing. en Redes", "Lic. en Administración", "Lic. en Contaduría" };

    public static readonly string[] Centros = { "CUCEI", "CUCEA", "CUCS", "CUCSH" };
}
