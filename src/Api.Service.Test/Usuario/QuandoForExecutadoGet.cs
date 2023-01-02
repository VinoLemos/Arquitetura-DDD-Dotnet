using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario))
                        .ReturnsAsync(userDto);
            _userService = _serviceMock.Object;

            var result = await _userService.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                        .Returns(Task.FromResult((UserDto)null));
            _userService = _serviceMock.Object;

            var _record = await _userService.Get(IdUsuario);
            Assert.Null(_record);
        }
    }
}