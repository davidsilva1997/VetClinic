using AutoMapper;

namespace VetClinicAPI.Profiles
{
    public class VetProfile : Profile
    {
        public VetProfile()
        {
            CreateMap<Models.Vet, Models.DTO.Vet>()
                .ReverseMap();
        }
    }
}
