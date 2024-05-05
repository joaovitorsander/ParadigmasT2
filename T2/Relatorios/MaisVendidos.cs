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
        public List<Produto> Imprimir(List<Produto> produtos)
        {
            return (List<Produto>) produtos.
                                    OrderByDescending(p => p.QtdVendida).
                                    Take(5);
        }
    }
}
