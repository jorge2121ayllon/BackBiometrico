using backend.Core.Entities;
using backend.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace backend.Infraestructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {



            builder.Property(e => e.Rol)
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(
               x => x.ToString(),
               x => (RoleType)Enum.Parse(typeof(RoleType), x)
               );



            builder.Property(e => e.Clave)
                   .IsRequired()
                   .HasMaxLength(100)
                   .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnType("date");

            builder.Property(e => e.Gmail)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NombreUsuario)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Rol)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
