using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using Xunit;

namespace Patrimonio.Teste.Controllers
{
    public class LoginControllerTestes
    {
        [Fact] // Descrição
        public void DeveRetornarUmUsuarioInvalido()
        {
            // Pré-Condição
            var repositoriofake = new Mock<IUsuarioRepository>();
            repositoriofake
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            LoginViewModel dados = new LoginViewModel();

            var controller = new LoginController(repositoriofake.Object);

            // Procedimento
            var resultado = controller.Login(dados);

            // Resultado Esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }

        [Fact] // Descrição
        public void DeveRetornarUmUsuarioValido()
        {
            // Pré-Condição
            var usuariofake = new Usuario();
            usuariofake.Email = "paulo@email.com";
            usuariofake.Senha = "123456789";

            var repositoriofake = new Mock<IUsuarioRepository>();
            repositoriofake
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuariofake);

            LoginViewModel dados = new LoginViewModel();

            var controller = new LoginController(repositoriofake.Object);

            // Procedimento
            var resultado = controller.Login(dados);

            // Resultado Esperado
            Assert.IsType<OkObjectResult>(resultado);

        }
    }
}
