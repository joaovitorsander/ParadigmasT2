using Api.Database;
using Api.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
    }


    public class ProdutoServices
    {
        private readonly ContextDB _contextDB;
        public ProdutoServices(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        public List<Produto> GetAll()
        {
            return (List<Produto>)_contextDB.Produtos;
        }

        public Produto GetById(int codigo)
        {
            try
            {
                return _contextDB.Produtos.Where(p => p.Codigo == codigo).First();
            }
            catch
            {
                throw new NotFoundException();
            }
        }
    }
}