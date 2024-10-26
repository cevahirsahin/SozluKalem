using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozluKalem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozluKalem.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<AppRole> 
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(new AppRole
            {
                Id=Guid.Parse("05931A8A-3F08-47E2-BA90-7E330577DA58"),
                Name="Superadmin",
                NormalizedName="SUPERADMIN",
                ConcurrencyStamp=Guid.NewGuid().ToString()

            },
            new AppRole
            {
                Id=Guid.Parse("DF71AEBF-24BA-47C0-84EA-10270143E8C6"),
                Name="Admin",
                NormalizedName="ADMIN",
                ConcurrencyStamp=Guid.NewGuid().ToString()  

            },
            new AppRole
            {
                Id=Guid.Parse("8B330EFF-334F-40B2-9E37-4C2C76329224"),
                Name="User",
                NormalizedName="USER",
                ConcurrencyStamp=Guid.NewGuid().ToString()  
            });
            
        }

    }
}
