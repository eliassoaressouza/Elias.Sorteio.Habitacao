using Elias.Sorteio.Habitacao.Shared.Core;
using Elias.Sorteio.Habitacao.Shared.Core.Interfaces;
using Elias.Sorteio.Habitacao.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elias.Sorteio.Habitacao.WebApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {
        private readonly ISorteioCore _sorteioCore;
        public SorteioController(ISorteioCore sorteioCore)
        {
            _sorteioCore = sorteioCore;
        }

        [HttpGet]
        public List<Pessoa> Get()
        {
            var lista = new List<Pessoa>();
            try
            {
                lista = _sorteioCore.ObterListaSorteados();

            }
            catch (Exception ex)
            {


            }
            return lista;

        }
    }
}
