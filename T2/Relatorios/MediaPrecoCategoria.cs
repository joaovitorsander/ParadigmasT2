using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Classes;
using T2.Interfaces;

namespace T2.Relatorios
{
    public class MediaPrecoCategoria : IRelatorio
    {
        static public void Imprimir(List<Produto> produtos)
        {
            var MediaPrecoCategoria = from produto in produtos
                                      group produto by produto.Categoria into CategoriaAgrupada
                                      select new
                                      {
                                          Categoria = CategoriaAgrupada.Key,
                                          Media = CategoriaAgrupada.Average(p => p.Preco),
                                      };


            foreach (var categoria in MediaPrecoCategoria)
            {
                Console.WriteLine(String.Format("{0}: {1:n2}", categoria.Categoria, categoria.Media));
            }
        }
    }
}
