using ASPNET.CORE.WEB.APP.Models;
using ASPNET.CORE.WEB.APP.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ASPNET.CORE.WEB.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        [HttpPost]
        [Route("v1/Cadastrar/")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status500InternalServerError)]
        public object CadastrarCliente(string documento, string nome)
        {
            try
            {
                string validacaoEntrada = ValidaCamposEntrada(documento, nome);

                if (!string.IsNullOrEmpty(validacaoEntrada))
                    return BadRequest(validacaoEntrada);

                RepositorioCliente cliente = new RepositorioCliente();
                cliente.CadastrarCliente(documento, nome);

                return StatusCode(200, JsonConvert.SerializeObject("Cliente cadastrado com sucesso"));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("v1/Listar/")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status500InternalServerError)]
        public object ConsultarClientes(string documento)
        {
            try
            {
                RepositorioCliente cliente = new RepositorioCliente();
                var r = cliente.ConsultarCliente(documento);
                return Ok(r);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, (JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json"));
            }
        }

        #region METODO PARA VALIDAR OS CAMPOS DE ENTRADA
        private string ValidaCamposEntrada(string documento, string nome)
        {
            string messagem = string.Empty;

            if (string.IsNullOrEmpty(documento))
                messagem = "Documento de identificação é obrigatório";
            else if (documento.Trim().Length != 11)
                messagem = string.Format("Documento {0} deve conter 11 caracteres", documento);

            return messagem;
        }
        #endregion
    }
}