using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using RestauranteApp.Models;

namespace RestauranteApp.Data;

public partial class RestauranteContext : DbContext
{
    public RestauranteContext()
    {
    }

    public RestauranteContext(DbContextOptions<RestauranteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alertainventario> Alertainventarios { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Ingredienteproducto> Ingredienteproductos { get; set; }

    public virtual DbSet<Itempedido> Itempedidos { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=actividad05;user=root;password=cartulina123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alertainventario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("alertainventario");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.StockActual)
                .HasPrecision(10, 2)
                .HasColumnName("stock_actual");
            entity.Property(e => e.UmbralMinimo)
                .HasPrecision(10, 2)
                .HasColumnName("umbral_minimo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PRIMARY");

            entity.ToTable("factura");

            entity.HasIndex(e => e.PedidoId, "pedido_id").IsUnique();

            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'generada'")
                .HasColumnType("enum('generada','pagada','anulada')")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Pedido).WithOne(p => p.Factura)
                .HasForeignKey<Factura>(d => d.PedidoId)
                .HasConstraintName("factura_ibfk_1");
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IngredienteId).HasName("PRIMARY");

            entity.ToTable("ingrediente");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IngredienteId).HasColumnName("ingrediente_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.StockActual)
                .HasPrecision(10, 2)
                .HasColumnName("stock_actual");
            entity.Property(e => e.UmbralMinimo)
                .HasPrecision(10, 2)
                .HasColumnName("umbral_minimo");
        });

        modelBuilder.Entity<Ingredienteproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ingredienteproducto");

            entity.HasIndex(e => e.IngredienteId, "ingrediente_id");

            entity.HasIndex(e => new { e.ProductoId, e.IngredienteId }, "unique_ing_prod").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CantidadReq)
                .HasPrecision(10, 2)
                .HasColumnName("cantidad_req");
            entity.Property(e => e.IngredienteId).HasColumnName("ingrediente_id");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.Ingredienteproductos)
                .HasForeignKey(d => d.IngredienteId)
                .HasConstraintName("ingredienteproducto_ibfk_2");

            entity.HasOne(d => d.Producto).WithMany(p => p.Ingredienteproductos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("ingredienteproducto_ibfk_1");
        });

        modelBuilder.Entity<Itempedido>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("itempedido");

            entity.HasIndex(e => e.PedidoId, "pedido_id");

            entity.HasIndex(e => e.ProductoId, "producto_id");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(8, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Itempedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("itempedido_ibfk_1");

            entity.HasOne(d => d.Producto).WithMany(p => p.Itempedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itempedido_ibfk_2");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PRIMARY");

            entity.ToTable("mesa");

            entity.HasIndex(e => e.Numero, "numero").IsUnique();

            entity.Property(e => e.MesaId).HasColumnName("mesa_id");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'libre'")
                .HasColumnType("enum('libre','ocupada','reservada')")
                .HasColumnName("estado");
            entity.Property(e => e.Numero).HasColumnName("numero");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PRIMARY");

            entity.ToTable("pedido");

            entity.HasIndex(e => e.ClienteId, "cliente_id");

            entity.HasIndex(e => e.MesaId, "mesa_id");

            entity.HasIndex(e => e.ReservaId, "reserva_id");

            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'pendiente'")
                .HasColumnType("enum('pendiente','preparando','entregado','cancelado')")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha");
            entity.Property(e => e.MesaId).HasColumnName("mesa_id");
            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("pedido_ibfk_3");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedido_ibfk_1");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedido_ibfk_2");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(8, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('plato','bebida','postre')")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PRIMARY");

            entity.ToTable("reserva");

            entity.HasIndex(e => e.ClienteId, "cliente_id");

            entity.HasIndex(e => new { e.MesaId, e.Fecha, e.Horario }, "unique_reserva").IsUnique();

            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'confirmada'")
                .HasColumnType("enum('confirmada','modificada','cancelada')")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Horario)
                .HasColumnType("time")
                .HasColumnName("horario");
            entity.Property(e => e.MesaId).HasColumnName("mesa_id");
            entity.Property(e => e.Recurrente)
                .HasDefaultValueSql("'0'")
                .HasColumnName("recurrente");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("reserva_ibfk_1");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
