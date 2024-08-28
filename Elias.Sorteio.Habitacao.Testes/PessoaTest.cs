using Elias.Sorteio.Habitacao.Shared.Core;


namespace Elias.Sorteio.Habitacao.Testes
{
    [TestClass]
    public class PessoaTest
    {
        [TestMethod]
        public void ObterListaPessoaTestes()
        {

            var pessoaCore = new PessoaCore();
            var lista = pessoaCore.ObterLista();


            Assert.IsTrue(lista != null && lista.Any());



        }
    }
}
