using HobbyPrinterApi.Models;
using HobbyPrinterApi.Models.DTO.People_DTO;
using AutoMapper;
using Microsoft.Identity.Client;
using HobbyPrinterApi.Models.DTO.Hobby_DTO;
using HobbyPrinterApi.Models.DTO.Link_DTO;

namespace HobbyPrinterApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // Mapping API - People
            CreateMap<People, PeopleCreateDto>().ReverseMap();
            CreateMap<People, PeopleGetDto>().ReverseMap();
            CreateMap<People, PeopleUpdateDto>().ReverseMap();
            
            // Mapping API - Hobbys
            CreateMap<Hobby, HobbyCreateDto>().ReverseMap();
            CreateMap<Hobby, HobbyGetDto>().ReverseMap();
            CreateMap<Hobby, HobbyUpdateDto>().ReverseMap();

            // Mapping API - Link
            CreateMap<Link, LinkCreateDto>().ReverseMap();
            CreateMap<Link, LinkGetDto>().ReverseMap();
            CreateMap<Link, LinkUpdateDto>().ReverseMap();

        }
    }
}
