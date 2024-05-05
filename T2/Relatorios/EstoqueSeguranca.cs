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
         public List<Produto> Imprimir(List<Produto> produtos)
        {
            return (List<Produto>) (from produto in produtos
                                      where (produto.Estoque < (produto.QtdVendida * 0.33))
                                    select produto);

        }
    }
}
