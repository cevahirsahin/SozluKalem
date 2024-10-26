using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SozluKalem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozluKalem.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C"),
                RoleId = Guid.Parse("05931A8A-3F08-47E2-BA90-7E330577DA58")
            },
           new AppUserRole
           {
               UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
               RoleId = Guid.Parse("DF71AEBF-24BA-47C0-84EA-10270143E8C6")
           });

        }
    }
}