namespace ECom.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();

        CreateMap<Photo, PhotoDto>().ReverseMap();

       
        CreateMap<Product, ProductDto>()
            //.ForMember(dest => dest.Category.Name, opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();
    }
}