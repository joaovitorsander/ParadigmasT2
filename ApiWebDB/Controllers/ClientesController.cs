using ApiWebDB.Services;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using APIWebDB.BaseDados.Models;

using Microsoft.AspNetCore.Mvc;

namespace ApiWebDB.Controllers
{
    /// <summary>
    /// Controlador para gerenciar clientes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="cliente">O cliente a ser inserido.</param>
        /// <returns>O cliente inserido.</returns>
        [HttpPost()]
        public ActionResult<TbCliente> Insert(ClienteDTO cliente)
        {
            try
            {
                var entity = _service.Insert(cliente);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                return BadRequest(E.Message);
            }
        }

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="id">O ID do cliente a ser atualizado.</param>
        /// <param name="dto">Os novos dados do cliente.</param>
        /// <returns>O cliente atualizado.</returns>
        [HttpPut("{id}")]
        public ActionResult<TbCliente> Update(int id, ClienteDTO dto)
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
        /// Exclui um cliente.
        /// </summary>
        /// <param name="id">O ID do cliente a ser excluído.</param>
        /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public ActionResult<TbCliente> Delete(int id)
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
        /// Obtém um cliente pelo ID.
        /// </summary>
        /// <param name="id">O ID do cliente a ser obtido.</param>
        /// <returns>O cliente solicitado.</returns>
        [HttpGet("{id}")]
        public ActionResult<TbCliente> GetById(int id)
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
        /// Obtém todos os clientes.
        /// </summary>
        /// <returns>Uma lista de todos os clientes.</returns>
        [HttpGet()]
        public ActionResult<TbCliente> Get()
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
