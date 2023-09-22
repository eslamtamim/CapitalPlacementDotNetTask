using AutoMapper;
using CapitalPlacementDotNetTask.Dtos.PreviewPageDTOs;
using CapitalPlacementDotNetTask.Models.ApplecationFormPage;
using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;
using System.Drawing;

namespace CapitalPlacementDotNetTask.Mapping
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<AdditionalProgramInformation, AdditionalProgramInformationDto>().ReverseMap();
            CreateMap<ProgramDetails, ProgramDetailsDto>().ReverseMap();
           
        }

    }
}
