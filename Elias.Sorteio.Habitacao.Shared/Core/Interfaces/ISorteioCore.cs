using Elias.Sorteio.Habitacao.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elias.Sorteio.Habitacao.Shared.Core.Interfaces
{
    public interface ISorteioCore
    {
        List<Pessoa> ObterListaSorteados();
    }
}
