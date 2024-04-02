using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Classes;
using T2.Interfaces;

namespace T2.Relatorios
{
    public class CategoriaMaisVendida : IRelatorio
    {
        static public void Imprimir(List<Produto> produtos)
        {
            var categoriaAgrupadaESomada = from produto in produtos
                                           orderby produto.QtdVendida descending
                                           group produto by produto.Categoria into CategoriaAgrupada
                                           select new
                                           {
                                               Categoria = CategoriaAgrupada.Key,
                                               Total = CategoriaAgrupada.Sum(p => p.QtdVendida),
                                           };

            var categoriaMaisVendida = categoriaAgrupadaESomada.Take(1);

            foreach (var categoria in categoriaMaisVendida)
            {
                Console.WriteLine(String.Format("A categoria mais vendida é: {0}", categoria.Categoria));
            }
        }
    }
}
