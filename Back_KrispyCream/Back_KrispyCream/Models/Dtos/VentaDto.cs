namespace Back_KrispyCream.Models.Dtos
{
    public class VentaDto
    {
        public string Producto { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal TotalGanacia { get; set; }

        public string? CreadoPor { get; set; }

        public DateTime? CreadoEn { get; set; }

        public string? ActualizadoPor { get; set; }

        public DateTime? ActualizadoEn { get; set; }
    }
}
