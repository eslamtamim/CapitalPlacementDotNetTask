using AutoMapper;
using CapitalPlacementDotNetTask.Models.ApplecationFormPage;
using CapitalPlacementDotNetTask.Models.PreviewPage;
using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;

namespace CapitalPlacementDotNetTask.Mapping
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<AdditionalProgramInformation, AdditionalProgramInformationDto>().ReverseMap();
        }

    }
}
