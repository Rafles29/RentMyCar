using AutoMapper;
using Model;
using RentMyCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMyCar.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Adress, AdressView>().ReverseMap();

            CreateMap<Rent, RentView>().ForMember( r => r.UserName, ex => ex.MapFrom(r => r.User.UserName)).ReverseMap();

            CreateMap<User, UserView>().ReverseMap();

            CreateMap<Price, PriceView>().ReverseMap();

            CreateMap<Performance, PerformanceView>().ReverseMap();

            CreateMap<Car, CarView>().ForMember(c => c.UserName, ex => ex.MapFrom(c => c.User.UserName)).ReverseMap();

            CreateMap<Equipment, PriceView>().ReverseMap();

            CreateMap<RegisterViewModel, User>().ReverseMap();
        }        
    }
}
