using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Proveduria.Models;

namespace Proveduria;

public partial class ProveeduriaPiiContext : DbContext
{
    public ProveeduriaPiiContext()
    {
    }

    public ProveeduriaPiiContext(DbContextOptions<ProveeduriaPiiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesFacturasCompra> DetallesFacturasCompras { get; set; }

    public virtual DbSet<DetallesFacturasVenta> DetallesFacturasVenta { get; set; }

    public virtual DbSet<FacturasCompra> FacturasCompras { get; set; }

    public virtual DbSet<FacturasVenta> FacturasVenta { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<ImpuestosMensuales> ImpuestosMensuales { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<roles> Roles { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Data Source=DESKTOP-5TAL4MU;Initial Catalog=Proveeduria_PII;Integrated Security=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__E005FBFFE967E729");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("ID_Cliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Cliente");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Direccion_Cliente");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Cliente");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Telefono_Cliente");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetallesFacturasCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__Detalles__BCDCDC9BBFE02681");

            entity.ToTable("Detalles_Facturas_Compra");

            entity.Property(e => e.IdDetalleCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_Detalle_Compra");
            entity.Property(e => e.IdFacturaCompra).HasColumnName("ID_Factura_Compra");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_Unitario");

            entity.HasOne(d => d.IdFacturaCompraNavigation).WithMany(p => p.DetallesFacturasCompras)
                .HasForeignKey(d => d.IdFacturaCompra)
                .HasConstraintName("FK__Detalles___ID_Fa__46E78A0C");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesFacturasCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalles___ID_Pr__47DBAE45");
        });

        modelBuilder.Entity<DetallesFacturasVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__Detalles__DF908C88C4958DBA");

            entity.ToTable("Detalles_Facturas_Venta");

            entity.Property(e => e.IdDetalleVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Detalle_Venta");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_Factura_Venta");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_Unitario");

            entity.HasOne(d => d.IdFacturaVentaNavigation).WithMany(p => p.DetallesFacturasVenta)
                .HasForeignKey(d => d.IdFacturaVenta)
                .HasConstraintName("FK__Detalles___ID_Fa__4D94879B");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesFacturasVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalles___ID_Pr__4E88ABD4");
        });

        modelBuilder.Entity<FacturasCompra>(entity =>
        {
            entity.HasKey(e => e.IdFacturaCompra).HasName("PK__Facturas__F3E65D8D2C5C5163");

            entity.ToTable("Facturas_Compra");

            entity.Property(e => e.IdFacturaCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_Factura_Compra");
            entity.Property(e => e.FechaFactura).HasColumnName("Fecha_Factura");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Monto_Total");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_Factura");
            entity.Property(e => e.TotalImpuestosPagados)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Impuestos_Pagados");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.FacturasCompras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Facturas___ID_Pr__440B1D61");
        });

        modelBuilder.Entity<FacturasVenta>(entity =>
        {
            entity.HasKey(e => e.IdFacturaVenta).HasName("PK__Facturas__5FF041B19C15C2CC");

            entity.ToTable("Facturas_Venta");

            entity.Property(e => e.IdFacturaVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Factura_Venta");
            entity.Property(e => e.FechaFactura).HasColumnName("Fecha_Factura");
            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Monto_Total");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_Factura");
            entity.Property(e => e.TotalImpuestosCobrados)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Impuestos_Cobrados");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.FacturasVenta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Facturas___ID_Cl__4AB81AF0");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario).HasName("PK__Funciona__0AE977B9ECA2E764");

            entity.Property(e => e.IdFuncionario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Funcionario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoFuncionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Funcionario");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreFuncionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Funcionario");
        });

        modelBuilder.Entity<ImpuestosMensuales>(entity =>
        {
            entity.HasKey(e => e.IdImpuestoMensual).HasName("PK__Impuesto__FF87A52C7C7183B3");

            entity.ToTable("Impuestos_Mensuales");

            entity.Property(e => e.IdImpuestoMensual)
                .ValueGeneratedNever()
                .HasColumnName("ID_Impuesto_Mensual");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__9B4120E2D311C01C");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("ID_Producto");
            entity.Property(e => e.CantidadDisponible).HasColumnName("Cantidad_Disponible");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_Venta");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__7D65272F4DEFC3D8");

            entity.Property(e => e.IdProveedor)
                .ValueGeneratedNever()
                .HasColumnName("ID_Proveedor");
            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Proveedor");
            entity.Property(e => e.DireccionProveedor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Direccion_Proveedor");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Proveedor");
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Telefono_Proveedor");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__202AD22069DD61F6");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("ID_Rol");
            entity.Property(e => e.EstadoRol).HasColumnName("Estado_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE255FC041E");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Contasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Tipo_Usuario");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__DE4431C51A493474");

            entity.ToTable("Usuarios");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoFuncionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Funcionario");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreFuncionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Funcionario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario1s)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__ID_Rol__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
