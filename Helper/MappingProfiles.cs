using AutoMapper;
using Hello_World.Dto;
using Hello_World.Models;

namespace Hello_World.Helper
{
    public class MappingProfiles : Profile 
    {
        public MappingProfiles() 
        { 
            CreateMap<Bill , BillDto>();
            CreateMap<BillDto, Bill>();
            CreateMap<Status , StatusDto>();
            CreateMap<StatusDto, Status>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
        }

    }
}
