using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementation;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task IsUserCrudPossible()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            UserImplementation _repositorio = new UserImplementation(context);
            UserEntity _entity = new UserEntity
            {
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName()
            };

            var _registroCriado = await _repositorio.InsertAsync(_entity);
            Assert.NotNull(_registroCriado);
            Assert.Equal(_entity.Email, _registroCriado.Email);
            Assert.Equal(_entity.Name, _registroCriado.Name);
            Assert.False(_registroCriado.Id == Guid.Empty);
        }
    }
}