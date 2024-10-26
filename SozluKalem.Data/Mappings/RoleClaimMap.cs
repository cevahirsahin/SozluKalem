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
    public class RoleClaimMap
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.HasKey(rc => rc.Id);

            builder.ToTable("AspNetRoleClaims");
        }
    }
}
