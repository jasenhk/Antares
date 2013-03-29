using System;
using System.Collections.Generic;
using AutoMapper;
using Antares.Data;
using Antares.Web.Models;

namespace Antares.Web
{
    public static class AutoMapConfig
    {
        public static void RegisterMappings()
        {
            //Mapper.CreateMap<UserProfile, IUserInfoViewModel>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}