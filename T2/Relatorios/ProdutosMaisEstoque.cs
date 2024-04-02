using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Classes;
using T2.Interfaces;

namespace T2.Relatorios
{
    public class ProdutosMaisEstoque : IRelatorio
    {
        static public void Imprimir(List<Produto> produtos)
        {
            var produtosOrdenados = produtos.OrderByDescending(p => p.Estoque);

            var top3MaisEstoque = produtosOrdenados.Take(3);

            Console.WriteLine("Os 3 produtos com mais estoque são:");
            foreach (Produto produto in top3MaisEstoque)
            {
                Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades em estoque", produto.Codigo, produto.Descricao, produto.Estoque));
            }
        }
    }
}
