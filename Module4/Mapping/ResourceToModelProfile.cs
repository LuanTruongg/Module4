using AutoMapper;
using Module4.Models;
using Module4.Resource;

namespace Module4.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}
