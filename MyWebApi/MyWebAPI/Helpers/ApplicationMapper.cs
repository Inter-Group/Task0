﻿using AutoMapper;
using MyWebAPI.Data;
using MyWebAPI.Models;

namespace MyWebAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Products,ProductsModel>().ReverseMap();
        }
    }
}
