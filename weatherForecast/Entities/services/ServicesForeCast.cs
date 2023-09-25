using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using weatherForecast.Entities;


namespace weatherForecast.Entities.services
{
    public class ServicesForeCast
    {
        // Tem que ter um método async porque pode demorar e etc, ou seja, como você já estudou
        // O programa não pode pular de etapa enquanto o serviço não terminar de ser executado
        // Criando a Task assincrona
        // Estou buscando do tipo Weather

        // Estrutura básica da Task - modificador | parametro | se é uma tarefa | tipo | nome | atributo (parametro)
        public async Task<Weather> SearchOnApi (String city){
            // Classe especial utilizado para fazer as requisições
            HttpClient clienteHttp = new();
            // Método para receber o endereço da API e buscar os valores
            var response = await clienteHttp.GetAsync("https://api.tomorrow.io/v4/weather/forecast?location=42.3478,-71.0466&apikey=68lgqLczU1IMctZwYDlh5Yyl0PIENZbY");
            // Vai esperar o conteudo da linha acima e ler como string
            var jsonString = await response.Content.ReadAsStringAsync();
            
            // Foi preciso instalar o pacote por fora com o 'dotnet add package Newtonsoft.Json'
            // Está pegando o JSON e convertendo para objetos C# para o tipo informado no '<>'
            // os nomes dos atributos têm que ter o mesmo nome
            Weather jsonObject = JsonConvert.DeserializeObject<Weather>(jsonString);



            // Hora de tratar possíveis exceções, como por exemplo o json estar vazio
            if (jsonObject != null){
                return jsonObject;
            } else {
                Console.WriteLine("Corno encontrado!");
            }

            return jsonObject;
        }
    }
}