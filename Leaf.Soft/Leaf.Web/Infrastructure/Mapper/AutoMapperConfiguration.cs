using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leaf.Core.Domain.Users;
using Leaf.Web.Models.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Leaf.Web.Infrastructure.Mapper
{

    //public class AutoMapperProfileConfiguration : Profile
    //{
    //    protected override void Configure()
    //    {
    //        CreateMap<Application, ApplicationViewModel>();
    //        CreateMap<ApplicationViewModel, Application>();
          
    //    }
    //}
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        public static void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>{

                cfg.CreateMap<User, UserModel>()
                .ForMember(dest=>dest.StatusName,mo=>mo.Ignore());
                cfg.CreateMap<UserModel, User>();

            });
            _mapper = _mapperConfiguration.CreateMapper();
           
        }

        public static void Init(IServiceCollection services)
        {
            _mapperConfiguration = new MapperConfiguration(cfg => {

                cfg.CreateMap<User, UserModel>()
                .ForMember(dest => dest.StatusName, mo => mo.Ignore());
                cfg.CreateMap<UserModel, User>();

            });
            //_mapper = _mapperConfiguration.CreateMapper();
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
        }


        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                return _mapperConfiguration;
            }
        }
    }
}
