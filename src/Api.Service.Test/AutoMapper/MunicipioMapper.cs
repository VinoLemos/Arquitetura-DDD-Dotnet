using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTest
    {
        [Fact(DisplayName = "É possível mapear os modelos de Município")]
        public void E_Possivel_Mapear_Os_Modelos_Municipio()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var entityList = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                };
                entityList.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Dto
            var dto = Mapper.Map<MunicipioDto>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Nome, entity.Nome);
            Assert.Equal(dto.CodIBGE, entity.CodIBGE);
            Assert.Equal(dto.UfId, entity.UfId);

            var dtoCompleto = Mapper.Map<MunicipioDtoCompleto>(entityList.FirstOrDefault());
            Assert.Equal(dtoCompleto.Id, entityList.FirstOrDefault().Id);
            Assert.Equal(dtoCompleto.Nome, entityList.FirstOrDefault().Nome);
            Assert.Equal(dtoCompleto.CodIBGE, entityList.FirstOrDefault().CodIBGE);
            Assert.Equal(dtoCompleto.UfId, entityList.FirstOrDefault().UfId);
            Assert.NotNull(dtoCompleto.Uf);

            var listDto = Mapper.Map<List<MunicipioDto>>(entityList);
            Assert.True(listDto.Count == entityList.Count);
            for (int i = 0; i < listDto.Count; i++)
            {
                Assert.Equal(listDto[i].Id, entityList[i].Id);
                Assert.Equal(listDto[i].Nome, entityList[i].Nome);
                Assert.Equal(listDto[i].CodIBGE, entityList[i].CodIBGE);
                Assert.Equal(listDto[i].UfId, entityList[i].UfId);
            }

            var createResult = Mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(createResult.Id, entity.Id);
            Assert.Equal(createResult.Nome, entity.Nome);
            Assert.Equal(createResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(createResult.UfId, entity.UfId);
            Assert.Equal(createResult.CreateAt, entity.CreateAt);

            var updateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(updateResult.Id, entity.Id);
            Assert.Equal(updateResult.Nome, entity.Nome);
            Assert.Equal(updateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(updateResult.UfId, entity.UfId);
            Assert.Equal(updateResult.UpdateAt, entity.UpdateAt);

            // Dto => Model
            var municipioModel = Mapper.Map<MunicipioModel>(dto);
            Assert.Equal(municipioModel.Id, dto.Id);
            Assert.Equal(municipioModel.Nome, dto.Nome);
            Assert.Equal(municipioModel.CodIBGE, dto.CodIBGE);
            Assert.Equal(municipioModel.UfId, dto.UfId);

            var dtoCreate = Mapper.Map<MunicipioDtoCreate>(municipioModel);
            Assert.Equal(dtoCreate.Nome, municipioModel.Nome);
            Assert.Equal(dtoCreate.CodIBGE, municipioModel.CodIBGE);
            Assert.Equal(dtoCreate.UfId, municipioModel.UfId);

            var dtoUpdate = Mapper.Map<MunicipioDtoUpdate>(municipioModel);
            Assert.Equal(dtoUpdate.Id, municipioModel.Id);
            Assert.Equal(dtoUpdate.Nome, municipioModel.Nome);
            Assert.Equal(dtoUpdate.CodIBGE, municipioModel.CodIBGE);
            Assert.Equal(dtoUpdate.UfId, municipioModel.UfId);
        }
    }
}