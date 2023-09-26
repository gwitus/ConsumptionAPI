using System;
using BD;

class Principal {
    public static void Main(string[] args) {
        
        Database connection = new("127.0.0.1", "1234@", "postgres", "Forca", "5432");
        connection.OpenConnection();

        string nickName;
        Console.WriteLine("Bem vindo ao Jogo da Forca\nInsira seu nickname: ");
        nickName = Console.ReadLine();
        // Condicional 
        if (nickName.Equals(string.Empty)){Console.WriteLine("O nickname não pode ser nulo!!");}
        


    }
}

// Preciso de uma forma de comparar o nome e também de validar se esse nome já existe no banco de dados para que o login continue
// Preciso de uma forma de ranking cuja eu gere a partir do banco de dados
// A conexão com o BD vai ser feita utilizando-se do entity framework