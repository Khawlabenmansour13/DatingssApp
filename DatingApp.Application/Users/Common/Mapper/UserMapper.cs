using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Common.Mapper
{
    public class UserMapper
    {
       
            private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                    cfg.AddProfile<DatingApplicationMappingUser>();
                });

                var mapper = config.CreateMapper();
                return mapper;
            });

            public static IMapper Mapper => Lazy.Value;
        }
    
}
