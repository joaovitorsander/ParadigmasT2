using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Classes;
using T2.Interfaces;

namespace T2.Relatorios
{
    public class EstoqueSeguranca : IRelatorio
    {
        static public void Imprimir(List<Produto> produtos)
        {
            var EstoqueDeSeguranca = from produto in produtos
                                     where (produto.Estoque < (produto.QtdVendida * 0.33))
                                     select produto;

            foreach (var produto in EstoqueDeSeguranca)
            {
                Console.WriteLine(String.Format("{0} - {1}: {2}", produto.Codigo, produto.Descricao, produto.Estoque));
            }
        }
    }
}
