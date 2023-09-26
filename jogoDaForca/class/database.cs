using System;
using System.Diagnostics.Contracts;
using Npgsql;

namespace BD {
    public class Database
    {
        private readonly string ConnectionString;
        public String _url { get; set; }
        public String _password { get; set; }
        public String _usernameBD { get; set; }
        public String _banco { get; set; }
        public String _door{ get; set; }

        public Database(string url, string pass, string username, string banco, string door)
        {
            // dessa forma é mais firula, basicamente vou ter que instanciar e passar os parametros
            _url = url;
            _password = pass;
            _usernameBD = username;
            _banco = banco;
            _door = door;

            // Substitua os valores abaixo pelos seus próprios dados de conexão.
            ConnectionString = $"Host={_url};Port={_door};Username={_usernameBD};Password={_password};Database={_banco}";
        }

        public NpgsqlConnection OpenConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
            connection.Open();
            return connection;

            try
            {
                if (connection != null)
                {
                    return connection;
                    Console.WriteLine($"Conexão com o banco {_banco} efetuado com sucesso!");
                }
            }
            catch (System.Exception)
            {
                throw;
            }            
        }
    }
}