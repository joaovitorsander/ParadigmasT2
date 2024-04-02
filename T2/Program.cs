using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using T2.Classes;

var dataSet = File.ReadAllText("..\\..\\..\\dataset.csv");

var listaProdutos = ProdutoParser.ConverterLista(dataSet);

//Console.WriteLine(listaProdutos);

static void MaisVendidos(List<Produto> produtos)
{

    var produtosOrdenados = produtos.OrderByDescending(p => p.QtdVendida);

    var top5Maisvendidos = produtosOrdenados.Take(5);

    Console.WriteLine("Os 5 produtos mais vendidos são:");
    foreach (Produto produto in top5Maisvendidos)
    {
        Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades vendidas", produto.Codigo, produto.Descricao, produto.QtdVendida));
    }
}

static void MenosVendidos(List<Produto> produtos)
{
    var produtosOrdenados = produtos.OrderBy(p => p.QtdVendida);

    var top5Menosvendidos = produtosOrdenados.Take(5);

    Console.WriteLine("Os 5 produtos menos vendidos são:");
    foreach (Produto produto in top5Menosvendidos)
    {
        Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades vendidas", produto.Codigo, produto.Descricao, produto.QtdVendida));
    }
}

static void ProdutosComMaisEstoque(List<Produto> produtos)
{
    var produtosOrdenados = produtos.OrderByDescending(p => p.Estoque);

    var top3MaisEstoque = produtosOrdenados.Take(3);

    Console.WriteLine("Os 3 produtos com mais estoque são:");
    foreach (Produto produto in top3MaisEstoque)
    {
        Console.WriteLine(String.Format("Código {0} - {1} com {2} unidades em estoque", produto.Codigo, produto.Descricao, produto.Estoque));
    }
}

static void CategoriaMaisVendida(List<Produto> produtos)
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

static void EstoqueDeSeguranca(List<Produto> produtos)
{
    var EstoqueDeSeguranca = from produto in produtos
                             where (produto.Estoque < (produto.QtdVendida * 0.33))
                             select produto;
    
    foreach (var produto in EstoqueDeSeguranca)
    {
        Console.WriteLine(String.Format("{0} - {1}: {2}", produto.Codigo, produto.Descricao, produto.Estoque));
    }

}

static void MediaDePrecoPorCategoria(List<Produto> produtos)
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


static void ExcessoEstoque(List<Produto> produtos)
{
    var ExcessoEstoque = from produto in produtos
                         where (produto.Estoque >= produto.QtdVendida * 3)
                         select produto;

    foreach (var produto in ExcessoEstoque)
    {
        Console.WriteLine(String.Format("{0} - {1}: {2}", produto.Codigo, produto.Descricao, produto.Estoque));
    }
}


bool sair = false;

while (!sair)
{
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1. Produtos mais vendidos");
    Console.WriteLine("2. Produtos com mais estoque");
    Console.WriteLine("3. Categoria mais vendida");
    Console.WriteLine("4. Produtos menos vendidos");
    Console.WriteLine("5. Estoque de segurança");
    Console.WriteLine("6. Excesso de estoque");
    Console.WriteLine("7. Média de preço por categoria");
    Console.WriteLine("8. Sair");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("Você selecionou 'Produtos mais vendidos'");
            MaisVendidos(listaProdutos);
            break;
        case "2":
            Console.WriteLine("Você selecionou 'Produtos com mais estoque'");
            ProdutosComMaisEstoque(listaProdutos);
            break;
        case "3":
            Console.WriteLine("Você selecionou 'Categoria mais vendida'");
            CategoriaMaisVendida(listaProdutos);
            break;
        case "4":
            Console.WriteLine("Você selecionou 'Produtos menos vendidos'");
            MenosVendidos(listaProdutos);
            break;
        case "5":
            Console.WriteLine("Você selecionou 'Estoque de segurança'");
            EstoqueDeSeguranca(listaProdutos);
            break;
        case "6":
            Console.WriteLine("Você selecionou 'Excesso de estoque'");
            ExcessoEstoque(listaProdutos);
            break;
        case "7":
            Console.WriteLine("Você selecionou 'Média de preço por categoria'");
            MediaDePrecoPorCategoria(listaProdutos);
            break;
        case "8":
            Console.WriteLine("Fechando a aplicação...");
            break;
        default:
            Console.WriteLine("Opção inválida. Por favor, selecione novamente.");
            break;
    }

    Console.WriteLine("\nPressione Enter para continuar...");
    Console.ReadLine();
    Console.Clear();
}