using Microsoft.AspNetCore.Http;
using SozluKalem.Entity.DTOs.Categories;
using SozluKalem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozluKalem.Entity.DTOs.Articles
{
    public class ArticleUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   
        public string Content { get; set; } 
        public Guid CategoryId { get; set; }

        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }
}
