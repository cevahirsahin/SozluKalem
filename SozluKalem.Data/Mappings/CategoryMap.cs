using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozluKalem.Entity.Entities;
using System.Xml.Linq;

namespace SozluKalem.Data.Mappings
{
    public class CategoryMap :IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            builder.HasData(new Category

            {
                Id = Guid.Parse("0F8EC991-0435-4D61-9EDB-CCF01B8E8915"),
                Name = "ASP.NET Core",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Category
            {
                Id = Guid.Parse("25220C0B-A5E3-491A-8D1E-D792DAB7537B"),
                Name = "Visual Studio 2022",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,


            });
        
        }

    }
}
