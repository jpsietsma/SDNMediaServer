using AutoMapper;
using MediaClasses.Classes;
using MediaClasses.Classes.APIClasses;
using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Config.MappedProfiles
{
    public class MediaServerMapProfile : Profile
    {
        public MediaServerMapProfile()
        {
            CreateMap<MediaFile, MediaFileViewModel>();

            CreateMap<SortMediaFile, SortFileViewModel>();

            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)

        }


    }
}
