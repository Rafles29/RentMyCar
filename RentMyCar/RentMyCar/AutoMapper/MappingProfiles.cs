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

            CreateMap<Rent, RentView>().ReverseMap();

            CreateMap<User, UserView>().ReverseMap();

            CreateMap<Price, PriceView>().ReverseMap();

            CreateMap<Performance, PerformanceView>().ReverseMap();

            CreateMap<Car, CarView>().ReverseMap();

            CreateMap<Equipment, PriceView>().ReverseMap();

            CreateMap<RegisterViewModel, User>().ReverseMap();
        }        
    }
}
