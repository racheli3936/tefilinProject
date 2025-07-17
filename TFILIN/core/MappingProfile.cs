using AutoMapper;
using core.DTOs;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<Role,RoleDto>().ReverseMap();
            CreateMap<Donor, DonorDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<StoreOwner, StoreOwnerDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();  
            CreateMap<StoreStand, StoreStandDto>().ReverseMap();
            CreateMap<StatusCall, StatusCallDto>().ReverseMap();
            CreateMap<StoreOwnerConversation, StoreOwnerConversationDto>().ReverseMap();
            CreateMap<ToDoVisit, ToDoVisitDto>().ReverseMap();
            CreateMap<ToDo, ToDoDto>().ReverseMap();
            CreateMap<MonthlyDonation, MonthlyDonationDto>().ReverseMap();
            CreateMap<Donation, DonationDto>().ReverseMap();

        }
    }
}
