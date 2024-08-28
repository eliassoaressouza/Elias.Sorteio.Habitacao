using CsvHelper;
using CsvHelper.Configuration;
using Elias.Sorteio.Habitacao.Shared.Core.Interfaces;
using Elias.Sorteio.Habitacao.Shared.Models;
using System.Globalization;

namespace Elias.Sorteio.Habitacao.Shared.Core
{
    public class PessoaCore: IPessoaCore
    {


        public List<Pessoa> ObterLista()
        {
            var lista = new List<Pessoa>();
            try
            {
                var Path = "C:\\Users\\Elias Soares\\Desktop\\Projetos-Code\\Habitacao-Teste\\Elias.Sorteio.Habitacao\\Elias.Sorteio.Habitacao.Shared\\Files\\lista_pessoas.csv";
                using (var reader = new StreamReader(Path))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        BadDataFound = null,
                        Delimiter = ","
                    };
                    using (var csv = new CsvReader(reader, config))
                    {
                        var csvRecordsResp = csv.GetRecords<Arquivo>();
                        int count = 1;
                        foreach (var recordCsv in csvRecordsResp)
                        {
                            lista.Add(Convert(recordCsv,count));
                            count++;
                        }

                    }

                }
                }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
        private Pessoa Convert(Arquivo arquivo,int id)
        {
            var pessoa = new Pessoa();
          
            pessoa.DataNascimento = DateOnly.Parse(arquivo.DataNascimento);
            pessoa.Nome = arquivo.Nome;
            pessoa.CPF = arquivo.CPF;
            pessoa.Cota = arquivo.Cota;
            pessoa.CID = arquivo.CID;
            pessoa.Renda=double.Parse(arquivo.Renda);
            return pessoa;
        }
    }
}
