using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Datos
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<PermisosAcciones> PermisosAcciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acciones>()
                .HasMany(e => e.PermisosAcciones)
                .WithRequired(e => e.Acciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permisos>()
                .HasMany(e => e.PermisosAcciones)
                .WithRequired(e => e.Permisos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permisos>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Permisos)
                .WillCascadeOnDelete(false);
        }
    }
}
