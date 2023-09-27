using System;
using System.Security.Cryptography.X509Certificates;
using BD;
using JsonTratament;
using Npgsql;
using JsonTratament;

class Principal
{
    public static void Main(string[] args)
    {
        // variáveis globais
        string nickName;
        jsonConvert jason = new();
        
        // Conexão
        Database connection = new("127.0.0.1", "1234@", "postgres", "Forca", "5432");
        connection.OpenConnection();

        // Estudar colocar um do-while
        Console.WriteLine("Bem vindo ao Jogo da Forca\nInsira seu nickname: ");
        nickName = Console.ReadLine().Trim();

        // Condicional 
        if (string.IsNullOrEmpty(nickName))
        {
            Console.WriteLine("O nickname não pode ser nulo!!");
        }

        // Statement
        using var comandoSql = new NpgsqlCommand($"SELECT nome from jogadores WHERE nome = '{nickName}';", connection.Connection);
        var jogador = comandoSql.ExecuteScalar();

        // Se não retornar nenhum jogador, logo o cara não existe
        if (string.IsNullOrEmpty((string?)jogador))
        {
            newPlayer(nickName, connection);
        } else {
            Console.WriteLine($"Bom jogo, {jogador}");
        }
        jason.carregarPalavras();
        connection.CloseConnection();
    }


        public static void newPlayer(string jogador, Database connection)
        {
            // Não gosto do auto increment, então vou trazer o último id e adicionar 1 e fodase
            using var searchID = new NpgsqlCommand($"SELECT id from jogadores ORDER BY id DESC LIMIT 1;", connection.Connection);
            // Pontos engraçados, pela tabela ser int ele já se converte automáticamente - mó tesão
            var resultOfSearchID = searchID.ExecuteScalar();

            if (resultOfSearchID != null){
                // Forma preguiçosa de comandos sql, o Npgsql tem mais funcionalidades e ainda mais fáceis
                // Mas quis treinar como se fosse statement do java, uma coisa de cada vez

                try
                {
                    using var newPlayer = new NpgsqlCommand($"INSERT INTO jogadores(id, nome, placarmax) values ({resultOfSearchID} + 1, '{jogador}', 0);", connection.Connection);
                    var crudNewPlayer = newPlayer.ExecuteScalar();
                    Console.WriteLine("Novo Player cadastrado!");
                }
                catch (System.Exception)
                {
                    throw;
                }               
            } else {
                // tenho que partir do pressuposto que sempre tenha algum jogador cadastrado antes, um admin sla,
                //  se não fodeu minha condicional
                Console.Write("\n\nErro no ID (database ou código) - validar!!");
            }
        }
}
