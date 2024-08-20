using System;
using System.Reflection;
using backend.Core.Entities;
using backend.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Infraestructure.Data
{
    public partial class InversionContext : DbContext
    {
        public InversionContext()
        {
        }

        public InversionContext(DbContextOptions<InversionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
