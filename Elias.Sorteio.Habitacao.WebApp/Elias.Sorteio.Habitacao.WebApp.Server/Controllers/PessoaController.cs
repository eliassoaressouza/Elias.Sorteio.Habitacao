using Elias.Sorteio.Habitacao.Shared.Core.Interfaces;
using Elias.Sorteio.Habitacao.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Elias.Sorteio.Habitacao.WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaCore _pessoaCore;
        public PessoaController(IPessoaCore pessoaCore)
        {
            _pessoaCore=pessoaCore;
        }
       
        [HttpGet]
        public List<Pessoa> Get()
        {
            var lista = new List<Pessoa>();
            try
            {
                 lista = _pessoaCore.ObterLista();
                
            }
            catch (Exception ex)
            {

                
            }
            return lista;

        }
        
    }
}
