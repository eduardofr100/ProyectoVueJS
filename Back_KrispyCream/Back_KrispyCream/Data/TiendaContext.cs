using Back_KrispyCream.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_KrispyCream.Data;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-SP22435M;Database=Tienda;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ventas__3213E83FDAE0E2DE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualizadoEn)
                .HasColumnType("datetime")
                .HasColumnName("actualizadoEn");
            entity.Property(e => e.ActualizadoPor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("actualizadoPor");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CreadoEn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creadoEn");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("creadoPor");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Producto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("producto");
            entity.Property(e => e.TotalGanacia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalGanacia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
