using System;
using Api.CrossCutting.Mappings;
using AutoMapper;
using Xunit;

namespace Api.Service.Test
{
    public abstract class BaseTest
    {
        public IMapper Mapper { get; set; }

        public BaseTest()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(config =>
                {
                    config.AddProfile(new ModelToEntityProfile());
                    config.AddProfile(new DtoToModelProfile());
                    config.AddProfile(new EntityToDtoProfile());
                });

                return config.CreateMapper();
            }

            public void Dispose()
            {

            }
        }
    }
}
