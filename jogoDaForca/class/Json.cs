using System;
using Newtonsoft.Json;
using Words;
using System.Collections.Generic;

namespace JsonTratament {
    public class jsonConvert {
        public string dica {get; set;}
        public string palavra {get; set;}

        // globais 
        private string caminho = "C:/Git/GitHub/ConsumptionAPI/jogoDaForca/files/words.json";
        private List<string> palavraDaVez= new List<String>();

        // Instanciando classe de leitura de Json
        WordsJson search = new();

        public void carregarPalavras (){
            if (File.Exists(caminho)){
                string conteudoJson = File.ReadAllText(caminho);
                WordsJson palavras = JsonConvert.DeserializeObject<WordsJson>(conteudoJson);
                foreach (var palavra in palavras.Words)
                {  
                    // Os atributos vão atuar como variável, não sei se é o certo mas vamos ver como se comporta
                    this.palavra = Convert.ToString(palavra.escrita);
                    // this.dica    = Convert.ToString(palavra.dica);
                    palavraDaVez.Add(Convert.ToString(this.palavra));
                    
                    // teste de colletor ok
                    // Console.WriteLine($"{palavra.escrita}");
                }
            } else {
                Console.WriteLine("O arquivo JSON não foi encontrado.");
            }
            Console.WriteLine("Palavras carregadas");
            chamarPalavras();
        }

        public void mostrarPalavras(){
            
            if (File.Exists(caminho)){
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
            } else {
                Console.WriteLine("O arquivo JSON não foi encontrado.");
            }
        }

        public void chamarPalavras(){
            Console.WriteLine("\n\n\n\nLet's go Him");
            
        }
    }
}