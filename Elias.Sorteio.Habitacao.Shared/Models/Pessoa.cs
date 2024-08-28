using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elias.Sorteio.Habitacao.Shared.Models
{
    public class Pessoa
    {
        
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public double Renda { get; set; }
        public string Cota { get; set; }
        public string CID { get; set; }

        public int NumeroSorteio { get; set; }

    }
}
