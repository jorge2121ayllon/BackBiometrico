using System;
using System.Reflection;
using backend.Core.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
