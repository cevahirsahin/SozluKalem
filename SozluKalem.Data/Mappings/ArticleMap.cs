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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
     
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "ASP.NET Core Deneme Makalesi 1",
                Content = "ASP.NET Core Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rutrum porta dui, vitae tristique tellus commodo eu. Nam nec posuere augue. Donec rutrum lectus at eleifend dignissim. Ut at ligula aliquet, semper lectus nec, varius tellus. Suspendisse eget magna lacus. Fusce nibh mi, egestas quis justo sit amet, accumsan tempus sapien. Morbi bibendum eleifend ultricies. Nunc at ante aliquam, eleifend felis et, porttitor justo. Pellentesque augue justo, luctus at condimentum at, placerat eget eros.",
                ViewCount = 15,
                CategoryId = Guid.Parse("0F8EC991-0435-4D61-9EDB-CCF01B8E8915"),
                ImageId = Guid.Parse("3C625D86-B321-4421-933C-CDA6DF2DB96E"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi 1",
                Content = "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rutrum porta dui, vitae tristique tellus commodo eu. Nam nec posuere augue. Donec rutrum lectus at eleifend dignissim. Ut at ligula aliquet, semper lectus nec, varius tellus. Suspendisse eget magna lacus. Fusce nibh mi, egestas quis justo sit amet, accumsan tempus sapien. Morbi bibendum eleifend ultricies. Nunc at ante aliquam, eleifend felis et, porttitor justo. Pellentesque augue justo, luctus at condimentum at, placerat eget eros.",
                ViewCount = 15,
                CategoryId = Guid.Parse("25220C0B-A5E3-491A-8D1E-D792DAB7537B"),
                ImageId= Guid.Parse("1A7CF8D7-8482-48A3-805E-2C0B534B0B49"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427")


            }


            );

        }
    }
}
