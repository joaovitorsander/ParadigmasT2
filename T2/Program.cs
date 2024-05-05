using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using T2.Classes;
using T2.Relatorios;

var dataSet = File.ReadAllText("..\\..\\..\\dataset.csv");

var listaProdutos = ProdutoParser.ConverterLista(dataSet);

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
            //MaisVendidos.Imprimir(listaProdutos);
            break;
        case "2":
            Console.WriteLine("Você selecionou 'Produtos com mais estoque'");
            //ProdutosMaisEstoque.Imprimir(listaProdutos);
            break;
        case "3":
            Console.WriteLine("Você selecionou 'Categoria mais vendida'");
            CategoriaMaisVendida.Imprimir(listaProdutos);
            break;
        case "4":
            Console.WriteLine("Você selecionou 'Produtos menos vendidos'");
            //MenosVendidos.Imprimir(listaProdutos);
            break;
        case "5":
            Console.WriteLine("Você selecionou 'Estoque de segurança'");
            //EstoqueSeguranca.Imprimir(listaProdutos);
            break;
        case "6":
            Console.WriteLine("Você selecionou 'Excesso de estoque'");
            //ExcessoEstoque.Imprimir(listaProdutos);
            break;
        case "7":
            Console.WriteLine("Você selecionou 'Média de preço por categoria'");
            MediaPrecoCategoria.Imprimir(listaProdutos);
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