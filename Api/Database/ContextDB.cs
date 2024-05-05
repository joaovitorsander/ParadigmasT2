using Api.DataBase.Models;
using Api.DataBase.Parser;
using System.Collections.Generic;
using System.IO;

namespace Api.Database
{
    public class ContextDB
    {
        private readonly string _dataSet;
        private readonly List<Produto> _produtos;

        public ContextDB()
        {
            _dataSet = File.ReadAllText("dataset.csv");
            _produtos = ProdutoParser.ConverterLista(_dataSet);
        }

        public List<Produto> Produtos => _produtos;  
    }
}
