using Patrimonio.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Teste.Domains
{
    public class UsuarioDomainTestes
    {
        [Fact] // Descrição
        public void DeveRetornarUsuarioPreenchido()
        {
            // Pré-Condição
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123";

            // Procedimento
            bool resultado = true;

            if(usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }


            // Resultado Esperado
            Assert.True(resultado);

        }
    }
}
