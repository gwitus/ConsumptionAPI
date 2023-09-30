using BD;
using Npgsql;
using Npgsql.Replication.PgOutput.Messages;

namespace pessoa {
    public class Jogador {
        public string nickName {get; set;}
        public int recorde {get; set;}
        private Database connection = new("127.0.0.1", "1234@", "postgres", "Forca", "5432");
        public void verificarLogin(string nickJogador){
            connection.OpenConnection();
            // Statement
            using var comandoSql     = new NpgsqlCommand($"SELECT nome from jogadores WHERE nome = '{nickJogador}';", connection.Connection);
            using var comandoRecorde = new NpgsqlCommand($"SELECT placarmax from jogadores WHERE nome = '{nickJogador}';", connection.Connection);
            var jogador         = comandoSql.ExecuteScalar();
            var placarDoJogador = comandoRecorde.ExecuteScalar();
            // Se o player existir, bem vindo, do contrário cadastra
            if (string.IsNullOrEmpty(Convert.ToString(jogador))){
                newPlayer(nickJogador, connection);
                Console.WriteLine($"Bem vindo jogador {nickJogador}" + " :)");
            } else {
                Console.WriteLine($"\n\nBem vindo jogador {jogador}" + " :)" + $"  Seu placar é de {placarDoJogador}");
            }
        }
        
          public void newPlayer(string jogador, Database connectionParameter)
        {
            using var searchID = new NpgsqlCommand($"SELECT id from jogadores ORDER BY id DESC LIMIT 1;", connectionParameter.Connection);
            // Pontos engraçados, pela tabela ser int ele já se converte automáticamente - mó tesão
            var resultOfSearchID = searchID.ExecuteScalar();

            if (resultOfSearchID != null){
                try
                {
                    using var newPlayer = new NpgsqlCommand($"INSERT INTO jogadores(id, nome, placarmax) values ({resultOfSearchID} + 1, '{jogador}', 0);", connectionParameter.Connection);
                    var crudNewPlayer = newPlayer.ExecuteScalar();
                    Console.WriteLine("Novo Player cadastrado!");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Problemas na inserção de dados em banco");
                    throw;
                }               
            } else {
                // tenho que partir do pressuposto que sempre tenha algum jogador cadastrado antes, um admin sla,
                //  se não fodeu minha condicional
                Console.Write("\n\nErro no ID (database ou código) - validar!!");
            }
        }

        public void verPlacar(string nomeJogador){
            using var comandoRecorde = new NpgsqlCommand($"SELECT placarmax from jogadores WHERE nome = '{nomeJogador}';", connection.Connection);
            var executarPlacar = comandoRecorde.ExecuteScalar();
            Console.WriteLine($"O placar de {nomeJogador} é {executarPlacar}");
        }
    }
}