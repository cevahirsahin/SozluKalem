﻿using AutoMapper;
using SozluKalem.Entity.DTOs.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozluKalem.Entity.Entities;

namespace SozluKalem.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile() 
        {
            CreateMap<ArticleDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap();
            CreateMap<ArticleAddDto, Article>().ReverseMap();

        
        }  
    }
}
