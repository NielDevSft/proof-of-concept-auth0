using Authentication.Domain.Funcionarios;
using Authentication.Domain.Funcionarios.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        // GET: api/Funcionario
        [HttpPost]
        [Route("listar-filtro")]
        public IEnumerable<object> ListaFiltro([FromBody] Dictionary<string, object> body)
        {
            var nomeCompleto = body.FirstOrDefault(e => e.Key == "nomeCompleto").Value;
            var idadeMinima = body.FirstOrDefault(e => e.Key == "idadeMinima").Value;
            var idadeLimite = body.FirstOrDefault(e => e.Key == "idadeLimite").Value;
            var habilidades = body.FirstOrDefault(e => e.Key == "habilidades").Value;
            var sexo = body.FirstOrDefault(e => e.Key == "sexo").Value;


            return _funcionarioService.ListarPorFiltro(
                (nomeCompleto != null) ? nomeCompleto.ToString() : null,
                (idadeMinima != null) ? (byte?)idadeMinima : null,
                (idadeLimite != null) ? (byte?)idadeLimite : null,
                (sexo != null) ? (byte?)sexo : null,
                (habilidades != null) ? StringToByteArray(habilidades) : null);
        }        

        // GET: api/Funcionario/5
        [HttpPost]
        public void Cadastrar([FromBody] object body)
        {
            _funcionarioService.Cadastrar((Funcionario)body);
        }

        // PUT: api/Funcionario/5
        [HttpPut]
        public void Atualizar([FromBody] object body)
        {
            _funcionarioService.Atualizar((Funcionario)body);
        }

        private static byte[] StringToByteArray(object arrayString)
        {
            var arrayByte = new List<byte>();
            foreach (var c in arrayString.ToString().ToCharArray().Where(c => c != ']' && c != '[' && c != ','))
            {
                arrayByte.Add(byte.Parse(c.ToString()));
            }
            return arrayByte.ToArray();
        }

    }
}
