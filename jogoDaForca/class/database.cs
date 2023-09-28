using System;
using Npgsql;

namespace BD
{
    public class Database
    {
        public string Url { get; set; }
        public string Password { get; set; }
        public string UsernameBD { get; set; }
        public string Banco { get; set; }
        public string Door { get; set; }
        public NpgsqlConnection Connection { get; set; }

        public Database(string url, string pass, string username, string banco, string door)
        {
            Url = url;
            Password = pass;
            UsernameBD = username;
            Banco = banco;
            Door = door;

            // Substitua os valores abaixo pelos seus próprios dados de conexão.
            var connectionString = $"Host={Url};Port={Door};Username={UsernameBD};Password={Password};Database={Banco}";
            Connection = new NpgsqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            Connection.Open();
            // Console.WriteLine($"Conexão com o banco '{Banco}' efetuada com sucesso!");
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
