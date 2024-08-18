using System;
using Microsoft.Data.SqlClient;

namespace ControleBd;

public class ControleEstoque : IDisposable
{
    // String de conexão ao SQL Server
    private string connectionString = "Server=PC-P1;Database=master;User Id=sa;Password=3030;Integrated Security=SSPI;TrustServerCertificate=True";
    private SqlConnection connection;
    // Construtor: cria e abre a conexão ao instanciar a classe
    public ControleEstoque()
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    // Método para criar um novo produto
    public void CriarProduto(string nome, string descricao, decimal valor, DateTime validade, int quantidade)
    {
        string query = "INSERT INTO Produtos (nome, descricao, valor, validade, quantidade) VALUES (@nome, @descricao, @valor, @validade, @quantidade)";
        
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@nome", nome);
            command.Parameters.AddWithValue("@descricao", descricao);
            command.Parameters.AddWithValue("@valor", valor);
            command.Parameters.AddWithValue("@validade", validade);
            command.Parameters.AddWithValue("@quantidade", quantidade);

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Produto criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar produto: " + ex.Message);
            }
        }
    }

    // Método para modificar um produto existente
    public void ModificarProduto(int produtoId, string nome, string descricao, decimal valor, DateTime validade, int quantidade)
    {
        string query = "UPDATE Produtos SET nome = @nome, descricao = @descricao, valor = @valor, validade = @validade, quantidade = @quantidade WHERE produtoId = @produtoId";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@produtoId", produtoId);
            command.Parameters.AddWithValue("@nome", nome);
            command.Parameters.AddWithValue("@descricao", descricao);
            command.Parameters.AddWithValue("@valor", valor);
            command.Parameters.AddWithValue("@validade", validade);
            command.Parameters.AddWithValue("@quantidade", quantidade);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto modificado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Nenhum produto encontrado com o ID fornecido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao modificar produto: " + ex.Message);
            }
        }
    }

    // Método para remover um produto
    public void RemoverProduto(int produtoId)
    {
        string query = "DELETE FROM Produtos WHERE produtoId = @produtoId";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@produtoId", produtoId);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Nenhum produto encontrado com o ID fornecido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao remover produto: " + ex.Message);
            }
        }
    }

    // Novo método para listar todos os produtos
    public void ListarProdutos()
    {
        string query = "SELECT * FROM Produtos";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Produtos no estoque:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["produtoId"]}, Nome: {reader["nome"]}, Descrição: {reader["descricao"]}, Valor: {reader["valor"]}, Validade: {reader["validade"]}, Quantidade: {reader["quantidade"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhum produto encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar produtos: " + ex.Message);
            }
        }
    }

    // Método para fechar a conexão
    public void Dispose()
    {
        if (connection != null)
        {
            connection.Close();
            connection.Dispose();
        }
    }
}