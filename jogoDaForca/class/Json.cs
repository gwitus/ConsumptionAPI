using System;
using Newtonsoft.Json;
using Words;
using System.Collections.Generic;
using BD;
using Npgsql;
using pessoa;
using System.Data;

namespace JsonTratament
{
    public class jsonConvert
    {
        public string dica { get; set; }
        public string palavra { get; set; }
        public Database connection = new("127.0.0.1", "1234@", "postgres", "Forca", "5432");        
        
        // globais 
        private string caminho = "C:/Git/GitHub/ConsumptionAPI/jogoDaForca/files/words.json";
        private List<string> palavraDaVez = new List<String>();
        private List<char> letraDaPalavra = new List<char>();
        Random random = new();
        // Instanciando classe de leitura de Json
        WordsJson search = new();


        public void carregarPalavras(Jogador jogador)
        {
            if (File.Exists(caminho))
            {
                string conteudoJson = File.ReadAllText(caminho);
                WordsJson palavras = JsonConvert.DeserializeObject<WordsJson>(conteudoJson);
                foreach (var palavra in palavras.Words)
                {
                    // Os atributos vão atuar como variável, não sei se é o certo mas vamos ver como se comporta
                    this.palavra = Convert.ToString(palavra.escrita);
                    this.dica = Convert.ToString(palavra.dica);
                    // this.dica    = Convert.ToString(palavra.dica);
                    palavraDaVez.Add(Convert.ToString(this.palavra));
                }
                // List já preenchida
                chamarPalavras(palavraDaVez, jogador.nickName);
            }
            else
            {
                Console.WriteLine("O arquivo JSON não foi encontrado.");
            }
        }

        public void mostrarPalavras()
        {

            if (File.Exists(caminho))
            {
                string conteudoJson = File.ReadAllText(caminho);
                Console.WriteLine("as seguintes palavras estão no database: ");
                // Precisa disso aqui para converter json para classe C#, a classe Json só faz a leitura
                WordsJson palavras = JsonConvert.DeserializeObject<WordsJson>(conteudoJson);

                int i = 1;
                foreach (var palavra in palavras.Words)
                {
                    Console.WriteLine($"Palavra {i}: {palavra.escrita}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("O arquivo JSON não foi encontrado.");
            }
        }

        private void chamarPalavras(List<String> cadeiaDePalavras, String jogador)
        {
            connection.OpenConnection();
            // Instanciando algo randomico
            int indiceAleatorio = random.Next(cadeiaDePalavras.Count);
            // recebe uma palavra aleatória do Json
            string aux = cadeiaDePalavras[indiceAleatorio];
            // ToChar para Convert e Tolist manda para a List
            this.letraDaPalavra = aux.ToCharArray().ToList();

            // validação da palavra, lembrar de apagar;
            Console.WriteLine(aux);
            int sizeChar = 0;

            foreach (char indice in this.letraDaPalavra)
            {
                // ToArrayChar tava botando para código Ascii, precisei do ToString
                // Console.Write(Convert.ToString(indice) + ' '); - Print se precisar
                sizeChar++;
            }

            Console.WriteLine($"A nova palavra tem {sizeChar} letras\ne a dica é: {this.dica}\n");

            Char[] barLine = new Char[sizeChar];

            for (int index = 0; index < sizeChar; index++)
            {
                barLine[index] = '_';
                Console.Write(barLine[index] + " ");
            }
            Console.Write("\n");

            int acertos = 0;
            String pegaLetra;
            using var placarJogadorSQL = new NpgsqlCommand($"SELECT placarmax from jogadores WHERE nome = '{jogador}';", connection.Connection);
            var placarDoJogador = placarJogadorSQL.ExecuteScalar();

            // Laço infinito
            while (true)
            {
                Console.Write("Insira a nova letra: ");
                pegaLetra = Console.ReadLine();
                // o convert pra char estava atrapalhando meus planos, então gambiarra nele
                if (pegaLetra.Length != 0)
                {
                    for (int index = 0; index < barLine.Length; index++)
                    {
                        if (pegaLetra[0] == letraDaPalavra[index])
                        {
                            barLine[index] = letraDaPalavra[index];
                            acertos++;
                        }
                    }

                    for (int index = 0; index < barLine.Length; index++)
                    {
                        Console.Write($"{barLine[index]}");
                    }
                }


                Console.WriteLine("\n\n");

                if (acertos > 0)
                {
                    Console.WriteLine($"Parabéns, faltam somente {this.letraDaPalavra.Count - acertos} letras");
                }

                // Método para acerto imediato
                if (acertos == barLine.Count())
                {
                    Console.WriteLine($"Parabéns, a palavra era: {aux}");
                    using var comandoSql = new NpgsqlCommand($"UPDATE jogadores SET placarmax = {placarDoJogador} + 1 WHERE nome = '{jogador}';", connection.Connection);
                    var executarPlacar = comandoSql.ExecuteScalar();
                    break;
                }
            }


        }
    }
}