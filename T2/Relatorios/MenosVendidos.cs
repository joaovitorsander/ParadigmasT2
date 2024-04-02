using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Classes;
using T2.Interfaces;

namespace T2.Relatorios
{
    public class MenosVendidos : IRelatorio
    {
        static public void Imprimir(List<Produto> produtos)
        {
            var produtosOrdenados = produtos.OrderBy(p => p.QtdVendida);

            var top5Menosvendidos = produtosOrdenados.Take(5);

            Console.WriteLine("Os 5 produtos menos vendidos são:");
            foreach (Produto produto in top5Menosvendidos)
            {
                Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades vendidas", produto.Codigo, produto.Descricao, produto.QtdVendida));
            }
        }
    }
}
