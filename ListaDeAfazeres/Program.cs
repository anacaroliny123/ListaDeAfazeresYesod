using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

class Program
{
    private static string connectionString;

    static void Main(string[] args)
    {
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        connectionString = configuration.GetConnectionString("dados");
        var opcao = menu();
        while (opcao != "5")
        {
            if (opcao == "1")
            {
                adicionarTarefa();

            }
            if (opcao == "2")
            {
                editarTarefa();
            }

            if (opcao == "3")
            {
                verTarefa();
            }
            if (opcao == "4")
            {
                excluirTarefa();
            }

            menu();
        }
    }

    static string menu()
    {
        var opcao = "";
        Console.WriteLine("Você deseja: ");
        Console.WriteLine("1 - Adicionar tarefa");
        Console.WriteLine("2 - Editar tarefa");
        Console.WriteLine("1 - Visualizar tarefa");
        Console.WriteLine("1 - Excluir tarefa");
        Console.WriteLine("5 - Sair");
        opcao = Console.ReadLine();

        return opcao;
    }

    static void adicionarTarefa()
    {

        Console.Clear();
        Console.Write("Digite a tarefa: ");
        var tarefa = Console.ReadLine();
        Console.WriteLine("Digite a data da tarefa (yyyy-mm-dd): ");
        var data = Console.ReadLine();
        Console.WriteLine("Digite a dificuldade da tarefa: ");
        var dificulcade = Console.ReadLine();

        // Connect to MySQL database and insert data
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO cad_tarefas(tarefas, data_tarefas, dificuldade) VALUES (@tarefa, @data, @dificuldade)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tarefa", tarefa);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@difculdade", dificulcade);
                command.ExecuteNonQuery();
            }
        }
        Console.Clear();
        Console.WriteLine("Tarefa inserida com sucesso.");
    }

    static void editarTarefa()
    {

    }

    static void verTarefa()
    {
      
    }

    static void excluirTarefa()
    {

    }


} 
        
