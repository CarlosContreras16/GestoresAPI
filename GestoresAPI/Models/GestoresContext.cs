using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestoresAPI.Models;

public partial class GestoresContext : DbContext
{
    public GestoresContext()
    {
    }

    public GestoresContext(DbContextOptions<GestoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GestoresBd> GestoresBds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-P7DQD9CC; Encrypt=False; DataBase=Gestores;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GestoresBd>(entity =>
        {
            entity.ToTable("gestores_bd");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Desarrollador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("desarrollador");
            entity.Property(e => e.Lanzamiento).HasColumnName("lanzamiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
