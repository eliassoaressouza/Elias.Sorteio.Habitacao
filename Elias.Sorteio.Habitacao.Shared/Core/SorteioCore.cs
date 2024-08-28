using Elias.Sorteio.Habitacao.Shared.Core.Interfaces;
using Elias.Sorteio.Habitacao.Shared.Models;

namespace Elias.Sorteio.Habitacao.Shared.Core
{
    public class SorteioCore : ISorteioCore
    {
        private readonly IPessoaCore _pessoaCore;
        public SorteioCore(IPessoaCore pessoaCore)
        {
            _pessoaCore = pessoaCore;
        }

        public List<Pessoa> ObterListaSorteados()
        {
            List<Pessoa> lista = new List<Pessoa>();

            var listaTudo = _pessoaCore.ObterLista();

            var listaIdoso = listaTudo.Where(p => p.Cota == "IDOSO");
            var listaDeficiente = listaTudo.Where(p => p.Cota == "DEFICIENTE FÍSICO");
            var listaGeral = listaTudo.Where(p => p.Cota == "GERAL");

            var idosoSorteado = SorteiaCPFPelaLista(listaIdoso.ToList(), 1);
            var deficienteSorteado = SorteiaCPFPelaLista(listaDeficiente.ToList(), 1);
            var geralSorteado = SorteiaCPFPelaLista(listaGeral.ToList(), 3);

            var listasMerge = new List<string>(idosoSorteado.Count + deficienteSorteado.Count + geralSorteado.Count);
            listasMerge.AddRange(idosoSorteado);
            listasMerge.AddRange(deficienteSorteado);
            listasMerge.AddRange(geralSorteado);
            foreach (var pessoa in listaTudo)
            {
                if (listasMerge.Contains(pessoa.CPF))
                {
                    lista.Add(pessoa);
                }
            }
            return lista;
        }



        private List<string> SorteiaCPFPelaLista(List<Pessoa> lista, int quantidadeSorteados)
        {
            var lstPessoasSorteadas = new List<string>();
            var listaCPFS = new List<string>();

            //crio uma lista de CPFS
            foreach (var pessoa in lista)
            {
                listaCPFS.Add(pessoa.CPF);
            }
            for (var i = 0; i < quantidadeSorteados; i++)
            {
                var timesorteado = Sorteio(listaCPFS.ToArray());
                if (!lstPessoasSorteadas.Any(x => x.Contains(timesorteado)))
                {
                    lstPessoasSorteadas.Add(timesorteado);
                }
                else
                {
                    i--;
                }
            }
            return lstPessoasSorteadas;
        }
        private static string Sorteio(string[] times)
        {
            var rnd = new Random();

            var r = rnd.Next(times.Length);
            return ((string)times[r]);
        }

    }
}
