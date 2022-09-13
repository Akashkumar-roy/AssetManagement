using AutoMapper;
using Asset_Management1.Products;
using Asset_Management1.Projects;

namespace Asset_Management1;

public class Asset_Management1ApplicationAutoMapperProfile : Profile
{
    public Asset_Management1ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        //eateMap<Product, ProductDto>();
        //eateMap<CreateUpdateProductDto, Product>();
        CreateMap<ProductDto, CreateUpdateProductDto>();

        // Projects
        CreateMap<Project, ProjectDto>();
        CreateMap<CreateUpdateProjectDto, Project>();
    }
}
