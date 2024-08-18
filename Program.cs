using System;
using ControleBd;

public class Program
{
    static void Main(string[] args)
    {
        using (ControleEstoque controleEstoque = new ControleEstoque())
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Criar Produto");
                Console.WriteLine("2. Modificar Produto");
                Console.WriteLine("3. Remover Produto");
                Console.WriteLine("4. Listar Produtos");
                Console.WriteLine("5. Sair");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome do produto: ");
                        string nome = Console.ReadLine();
                        Console.Write("Descrição do produto: ");
                        string descricao = Console.ReadLine();
                        Console.Write("Valor do produto: ");
                        decimal valor = decimal.Parse(Console.ReadLine());
                        Console.Write("Data de validade (yyyy-MM-dd): ");
                        DateTime validade = DateTime.Parse(Console.ReadLine());
                        Console.Write("Quantidade em estoque: ");
                        int quantidade = int.Parse(Console.ReadLine());

                        controleEstoque.CriarProduto(nome, descricao, valor, validade, quantidade);
                        break;

                    case "2":
                        Console.Write("ID do produto a modificar: ");
                        int idModificacao = int.Parse(Console.ReadLine());
                        Console.Write("Novo nome do produto: ");
                        string novoNome = Console.ReadLine();
                        Console.Write("Nova descrição do produto: ");
                        string novaDescricao = Console.ReadLine();
                        Console.Write("Novo valor do produto: ");
                        decimal novoValor = decimal.Parse(Console.ReadLine());
                        Console.Write("Nova data de validade (yyyy-MM-dd): ");
                        DateTime novaValidade = DateTime.Parse(Console.ReadLine());
                        Console.Write("Nova quantidade em estoque: ");
                        int novaQuantidade = int.Parse(Console.ReadLine());

                        controleEstoque.ModificarProduto(idModificacao, novoNome, novaDescricao, novoValor, novaValidade, novaQuantidade);
                        break;

                    case "3":
                        Console.Write("ID do produto a remover: ");
                        int idRemocao = int.Parse(Console.ReadLine());

                        controleEstoque.RemoverProduto(idRemocao);
                        break;

                    case "4":
                        controleEstoque.ListarProdutos();
                        break;

                    case "5":
                        continuar = false;
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
