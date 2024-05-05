using Api.DataBase.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoServices _produtoServices;

        public ProdutosController(ProdutoServices produtoServices) 
        {
            _produtoServices = produtoServices;   
        }

        [HttpGet()]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<List<Produto>> GetAll() 
        {
            return Ok(_produtoServices.GetAll());
        }

        [HttpGet(":codigo")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<Produto> GetByCOdigo(int codigo) 
        {
            try
            {
                var produto = _produtoServices.GetById(codigo);

                return Ok(produto);

            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um problema ao acessar o produto." + e.Message);
            }
        }

    }
}
