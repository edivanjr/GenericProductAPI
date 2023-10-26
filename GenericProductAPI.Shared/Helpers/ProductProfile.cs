using AutoMapper;
using GenericProductAPI.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProductAPI.Shared.Helpers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>(); 
            CreateMap<ProductDTO, Product>(); 
            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, CreateProductDTO>();
        }
    }
}
