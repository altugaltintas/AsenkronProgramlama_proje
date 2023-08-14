using AsenkronProgramlama.Models.DTOs;
using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.VMs;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace AsenkronProgramlama.Infrastructure.AutoMappers
{
    public class Mappers :Profile
    {

        public Mappers()    //mapleme kütüphanesi  AutoMapper.Extensions.Microsoft... kütüphanesi
        {                                                                   //slug proptery sıra geldiğinde ignore et taşıma işlemin yapıyor
                                                                            //

            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            // CreateMap<CreateCategoryDTO, Category>().ReverseMap().ForMember(a=> a.Slug,opt=> opt.Ignore());    // CreateMap<CreateCategoryDTO, Category>().ReverseMap();  yaparsak  dto bakarak category alır veya cagory bakarak dto alır bu genelde update işlemlerinde kullanılır 
            CreateMap<Category,UpdateCategoryDTO>().ReverseMap();

            CreateMap<CreateProductVM, Product>();//create product sağladığımda product yapman lazım bunun için map yapmam lazım

            CreateMap<Product, UpdateProductVM>().ReverseMap();
        }
    }
}
