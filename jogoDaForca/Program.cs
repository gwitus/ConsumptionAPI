using System;
using System.Security.Cryptography.X509Certificates;
using BD;
using JsonTratament;
using Npgsql;
using JsonTratament;
using pessoa;

class Principal
{
    public static void Main(string[] args)
    {
        Jogador jogador = new();
        jsonConvert jason = new();
        Console.Write("Bem vindo ao Jogo da Forca\nInsira seu nickname: ");
        jogador.nickName = Convert.ToString(Console.ReadLine());

        if (string.IsNullOrEmpty(jogador.nickName))
        {
            Console.WriteLine("O nickname não pode ser nulo!!");
        } else {
            jogador.verificarLogin(jogador.nickName);
        }
    }
}
