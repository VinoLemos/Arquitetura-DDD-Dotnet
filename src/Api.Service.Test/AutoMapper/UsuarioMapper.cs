using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTest
    {
        [Fact(DisplayName = "É possível Mapear os Modelos")]
        public void E_Possivel_Mapear_Os_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(item);
            }

            // Model => Entity
            var dtoToEntity = Mapper.Map<UserEntity>(model);
            AssertEntityToModelFields(dtoToEntity, model);

            // Entity => Dto
            var userDto = Mapper.Map<UserDto>(dtoToEntity);
            AssertDtoToModelFields(userDto, model);

            var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
            AssertListDtoToEntityFields(listaDto, listaEntity);

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(dtoToEntity);
            AssertDtoCreateResultToEntity(userDtoCreateResult, dtoToEntity);

            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(dtoToEntity);
            AssertDtoUpdateResultToEntity(userDtoUpdateResult, dtoToEntity);

            // Dto para Model
            var userModel = Mapper.Map<UserModel>(userDto);
            AssertModelToDtoFields(userModel, userDto);

            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            AssertDtoCreateToModel(userDtoCreate, userModel);

            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            AssertDtoUpdateToModel(userDtoUpdate, userModel);
        }
        private static void AssertEntityToModelFields(UserEntity data, UserModel source)
        {
            Assert.Equal(data.Id, source.Id);
            Assert.Equal(data.Name, source.Name);
            Assert.Equal(data.Email, source.Email);
            Assert.Equal(data.CreateAt, source.CreateAt);
            Assert.Equal(data.UpdateAt, source.UpdateAt);
        }
        private static void AssertDtoToModelFields(UserDto data, UserModel source)
        {
            Assert.Equal(data.Id, source.Id);
            Assert.Equal(data.Name, source.Name);
            Assert.Equal(data.Email, source.Email);
            Assert.Equal(data.CreateAt, source.CreateAt);
            Assert.Equal(data.UpdateAt, source.UpdateAt);
        }

        private static void AssertModelToDtoFields(UserModel data, UserDto source)
        {
            Assert.Equal(data.Id, source.Id);
            Assert.Equal(data.Name, source.Name);
            Assert.Equal(data.Email, source.Email);
            Assert.Equal(data.CreateAt, source.CreateAt);
            Assert.Equal(data.UpdateAt, source.UpdateAt);
        }

        private static void AssertListDtoToEntityFields(List<UserDto> dataList, List<UserEntity> source)
        {
            for (int i = 0; i < dataList.Count(); i++)
            {

                Assert.True(dataList.Count() == source.Count());
                Assert.Equal(dataList[i].Id, source[i].Id);
                Assert.Equal(dataList[i].Name, source[i].Name);
                Assert.Equal(dataList[i].Email, source[i].Email);
                Assert.Equal(dataList[i].CreateAt, source[i].CreateAt);
            }
        }

        private static void AssertDtoCreateResultToEntity(UserDtoCreateResult data, UserEntity source)
        {
            Assert.Equal(data.Id, source.Id);
            Assert.Equal(data.Name, source.Name);
            Assert.Equal(data.Email, source.Email);
            Assert.Equal(data.CreateAt, source.CreateAt);
        }

        private static void AssertDtoUpdateResultToEntity(UserDtoUpdateResult data, UserEntity source)
        {
            Assert.Equal(data.Id, source.Id);
            Assert.Equal(data.Name, source.Name);
            Assert.Equal(data.Email, source.Email);
            Assert.Equal(data.UpdateAt, source.UpdateAt);
        }
        private static void AssertDtoCreateToModel(UserDtoCreate data, UserModel source)
        {
            Assert.Equal(data.Name, source.Name);
            Assert.Equal(data.Email, source.Email);
        }
    
        private static void AssertDtoUpdateToModel(UserDtoUpdate data, UserModel source)
        {
            Assert.Equal(data.Id, source.Id);
            Assert.Equal(data.Name, source.Name);
            Assert.Equal(data.Email, source.Email);
        }
    }
}