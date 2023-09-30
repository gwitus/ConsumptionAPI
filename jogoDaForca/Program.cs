using System;
using System.Security.Cryptography.X509Certificates;
using BD;
using JsonTratament;
using Npgsql;
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
        jogador.nickName = Convert.ToString(Console.ReadLine()).Trim();
        
        // Se não existir vai cadastrar com um novo - não estava afim de adaptar um menu
        if (!string.IsNullOrEmpty(jogador.nickName)) {
            jogador.verificarLogin(jogador.nickName);
        }

        String input;

        while (true)
        {  
            Console.WriteLine("\n_Digite 0 para sair \n_Digite 2 para continuar \n_Digite 1 para ver o placar");


            Console.Write("Insira a opção: ");
            input = Console.ReadLine();

            if (input.Equals("0"))
            {
                break;
            } else if(input.Equals("2")){
               if (string.IsNullOrEmpty(jogador.nickName))
                {
                    Console.WriteLine("O nickname não pode ser nulo!!");
                    Console.Write("\nInsira um nome válido:  ");
                    Console.WriteLine("\nQuando desejar sair da aplicação digite '0'");
                }
                else
                {
                    jason.carregarPalavras(jogador);
                    Console.WriteLine("\n\nQuando desejar sair da aplicação digite '0'");
                    Console.WriteLine("\n\nSe desejar uma nova palavra, digite '2'");
                } 
            } else if (input.Equals("1")){
                jogador.verPlacar(jogador.nickName);
            } else
            {
                Console.WriteLine("opção inválida");
                break;   
            }
        }
    }
}
