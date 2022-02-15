using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Teste.Utils
{
    public class CriptografiaTestes
    {
        [Fact] // Descrição
        public void DeveRetornarHashEmBCrypt()
        {
            // Pré-Condição
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento
            var retorno = regex.IsMatch(senha);

            // Resultado Esperado
            Assert.True(retorno);
        }

        [Fact] // Descrição
        public void DeveRetornarComparacaoValida()
        {
            // Pré-Condição
            var senha = "123456789";
            var hash = "$2a$11$1vb5sQPp6RTzAW.0WFZgjuW1fwNWrK6c6ssyZFUd1fLlBqDaUejKq";

            // Procedimento
            var comparacao = Criptografia.Comparar(senha, hash);

            // Resultado Esperado
            Assert.True(comparacao);
        }
    }
}