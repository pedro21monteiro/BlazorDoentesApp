using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TbConsulta> TbConsultas { get; set; } = null!;
        public virtual DbSet<TbDoente> TbDoentes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbConsulta>(entity =>
            {
                entity.ToTable("tb_Consultas");

                //entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data).HasColumnType("DATE");

                entity.Property(e => e.Especialidade)
                    .HasColumnType("VARCHAR (20)")
                    .HasColumnName("especialidade");

                entity.Property(e => e.IdDoente).HasColumnName("IDDoente");


            });

            modelBuilder.Entity<TbDoente>(entity =>
            {
                entity.ToTable("tb_doentes");

                entity.Property(e => e.DataNascimento).HasColumnType("DATE");

                entity.Property(e => e.Nome).HasColumnType("VARCHAR (30)");

                entity.Property(e => e.Sexo).HasColumnType("VARCHAR (20)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
