using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaplesAppSL.Support
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<StaplesAppSL.Models.Person, StaplesAppDAL.Models.Person>();
                config.CreateMap<StaplesAppDAL.Models.Person, StaplesAppSL.Models.Person>();
            });
        }
    }
}