using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Interfaces;
using T2.Classes;

namespace T2.Relatorios
{
    public class MaisVendidos : IRelatorio
    {
        static public void Imprimir(List<Produto> produtos)
        {
            var list = produtos
                       .OrderByDescending(p => p.QtdVendida)
                       .Take(5);
            foreach (var produto in list)
            {
                Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades vendidas", produto.Codigo, produto.Descricao, produto.QtdVendida));
            }
        }
    }
}
