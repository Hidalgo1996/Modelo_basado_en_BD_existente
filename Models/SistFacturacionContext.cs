using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Modelo_basado_en_BD_existente.Models;

public partial class SistFacturacionContext : DbContext
{
    public SistFacturacionContext()
    {
    }

    public SistFacturacionContext(DbContextOptions<SistFacturacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<FacturaCabecera> FacturaCabeceras { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__categori__140587C71C2F71C0");

            entity.ToTable("categoria");

            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__cliente__7B86132F4AD360D2");

            entity.ToTable("cliente");

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<FacturaCabecera>(entity =>
        {
            entity.HasKey(e => e.IdfacturaCabecera).HasName("PK__factura___3185411B0F6D93C1");

            entity.ToTable("factura_cabecera");

            entity.Property(e => e.IdfacturaCabecera).HasColumnName("idfactura_cabecera");
            entity.Property(e => e.ClienteIdcliente).HasColumnName("cliente_idcliente");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FacturaDetalleIdfacturaDetalle).HasColumnName("factura_detalle_idfactura_detalle");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.MetodoPagoIdmetodoPago).HasColumnName("metodo_pago_idmetodo_pago");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.ClienteIdclienteNavigation).WithMany(p => p.FacturaCabeceras)
                .HasForeignKey(d => d.ClienteIdcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__factura_c__clien__4316F928");

            entity.HasOne(d => d.FacturaDetalleIdfacturaDetalleNavigation).WithMany(p => p.FacturaCabeceras)
                .HasForeignKey(d => d.FacturaDetalleIdfacturaDetalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__factura_c__factu__44FF419A");

            entity.HasOne(d => d.MetodoPagoIdmetodoPagoNavigation).WithMany(p => p.FacturaCabeceras)
                .HasForeignKey(d => d.MetodoPagoIdmetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__factura_c__metod__440B1D61");
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.IdfacturaDetalle).HasName("PK__factura___C60406F2E08A5E72");

            entity.ToTable("factura_detalle");

            entity.Property(e => e.IdfacturaDetalle).HasColumnName("idfactura_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.ProductoIdproducto).HasColumnName("producto_idproducto");

            entity.HasOne(d => d.ProductoIdproductoNavigation).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ProductoIdproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__factura_d__produ__403A8C7D");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdmetodoPago).HasName("PK__metodo_p__3160EC1D0A7EAD08");

            entity.ToTable("metodo_pago");

            entity.Property(e => e.IdmetodoPago).HasColumnName("idmetodo_pago");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NombrePago)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre_pago");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__producto__DC53BE3CA95AC066");

            entity.ToTable("producto");

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.CategoriaIdcategoria).HasColumnName("categoria_idcategoria");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.CategoriaIdcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaIdcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__producto__catego__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
