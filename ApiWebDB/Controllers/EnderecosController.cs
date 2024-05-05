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
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController: ControllerBase
    {
        public readonly EnderecoService _service;
        private readonly Microsoft.Extensions.Logging.ILogger _log;

        public EnderecosController(EnderecoService service, ILogger<EnderecosController> log)
        {
            _service = service;
            _log = log;
        }

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
