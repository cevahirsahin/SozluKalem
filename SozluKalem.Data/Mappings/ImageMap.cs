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
    public class ImageMap : IEntityTypeConfiguration<Image>

    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {


                Id = Guid.Parse("3C625D86-B321-4421-933C-CDA6DF2DB96E"),
                FileName = "images/testimage",
                FileType = "jpg",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Image {

                Id = Guid.Parse("1A7CF8D7-8482-48A3-805E-2C0B534B0B49"),
                FileName = "images/vstest",
                FileType = "png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            });
        }
   
    }
}
