﻿using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.Roles))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.SecondName, y => y.MapFrom(z => z.SecondName))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City));
        }
    }
}