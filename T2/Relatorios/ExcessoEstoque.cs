using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Classes;
using T2.Interfaces;

namespace T2.Relatorios
{
    public class ExcessoEstoque : IRelatorio
    {
        static public void Imprimir(List<Produto> produtos)
        {
            var ExcessoEstoque = from produto in produtos
                                 where (produto.Estoque >= produto.QtdVendida * 3)
                                 select produto;

            foreach (var produto in ExcessoEstoque)
            {
                Console.WriteLine(String.Format("{0} - {1}: {2}", produto.Codigo, produto.Descricao, produto.Estoque));
            }
        }
    }
}
