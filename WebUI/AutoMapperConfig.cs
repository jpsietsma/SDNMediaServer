using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Author,
                           opts => opts.MapFrom(src => src.Author.Name));
        }
    }
}
