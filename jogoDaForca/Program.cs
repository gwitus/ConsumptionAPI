using System;
using System.Security.Cryptography.X509Certificates;
using BD;
using JsonTratament;
using Npgsql;
using JsonTratament;
using pessoa;
using System.Runtime.InteropServices;

class Principal
{
    public static void Main(string[] args)
    {
        Jogador jogador = new();
        jsonConvert jason = new();
        Console.Write("__**Bem vindo ao Jogo da Forca**__");
        Console.Write("\nInsira seu nick:  ");

        // Construção do 'menu'

        while (true)
        {
            // Final do loop
            jogador.nickName = Convert.ToString(Console.ReadLine()).Trim();
            if (jogador.nickName.Equals("0"))
            {
                break;
            }
            else
            {
                if (string.IsNullOrEmpty(jogador.nickName))
                {
                    Console.WriteLine("O nickname não pode ser nulo!!");
                    Console.Write("\nInsira um nome válido:  ");
                    Console.WriteLine("\nQuando desejar sair da aplicação digite '0'");
                }
                else
                {
                    jogador.verificarLogin(jogador.nickName);
                    jason.carregarPalavras();
                    Console.WriteLine("\n\nQuando desejar sair da aplicação digite '0'");
                }
            }

        }
    }
}
