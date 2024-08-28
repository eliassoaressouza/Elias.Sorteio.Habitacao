using Elias.Sorteio.Habitacao.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elias.Sorteio.Habitacao.Testes
{
    [TestClass]
    public class SorteioTest
    {
        [TestMethod]
        public void ObterListaSorteioTestes()
        {

            var pessoaCore = new SorteioCore(new PessoaCore());
            var lista = pessoaCore.ObterListaSorteados();
            Assert.IsTrue(lista != null && lista.Any());

        }
    }
}
