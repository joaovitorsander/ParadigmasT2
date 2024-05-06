using APIWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog;

namespace ApiWebDB.Controllers
{
    /// <summary>
    /// Controlador para gerenciar endereços.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        public readonly EnderecoService _service;
        private readonly Microsoft.Extensions.Logging.ILogger _log;

        public EnderecosController(EnderecoService service, ILogger<EnderecosController> log)
        {
            _service = service;
            _log = log;
        }

        /// <summary>
        /// Insere um novo endereço.
        /// </summary>
        /// <param name="endereco">O endereço a ser inserido.</param>
        /// <returns>O endereço inserido.</returns>
        [HttpPost()]
        public ActionResult<TbEndereco> Insert(EnderecoDTO endereco)
        {
            try
            {
                var entity = _service.Insert(endereco);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                _log.LogError(E.Message);
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message);
            }
        }

        /// <summary>
        /// Atualiza um endereço existente.
        /// </summary>
        /// <param name="id">O ID do endereço a ser atualizado.</param>
        /// <param name="dto">Os novos dados do endereço.</param>
        /// <returns>O endereço atualizado.</returns>
        [HttpPut("{id}")]
        public ActionResult<TbEndereco> Update(int id, EnderecoDTO dto)
        {
            try
            {
                var entity = _service.Update(dto, id);
                return Ok(entity);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um endereço.
        /// </summary>
        /// <param name="id">O ID do endereço a ser excluído.</param>
        /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public ActionResult<TbEndereco> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }

        /// <summary>
        /// Obtém um endereço pelo ID.
        /// </summary>
        /// <param name="id">O ID do endereço a ser obtido.</param>
        /// <returns>O endereço solicitado.</returns>
        [HttpGet("{id}")]
        public ActionResult<TbEndereco> GetById(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }

        /// <summary>
        /// Obtém todos os endereços.
        /// </summary>
        /// <returns>Uma lista de todos os endereços.</returns>
        [HttpGet()]
        public ActionResult<TbEndereco> Get()
        {
            try
            {
                var entity = _service.Get();
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
    }
}