namespace Back_KrispyCream.Models.Entities;

public partial class Venta
{
    public int Id { get; set; }

    public string Producto { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal TotalGanacia { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? CreadoEn { get; set; }

    public string? ActualizadoPor { get; set; }

    public DateTime? ActualizadoEn { get; set; }
}
