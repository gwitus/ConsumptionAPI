// Senha da API: 648b3f22ef567da8b7fb4599aaA
using System;
using weatherForecast.Entities;
using weatherForecast.Entities.services;

namespace Principal {
    class Exe 
    {
        static async Task Main (){
            SearchCity();
        }

        static async void SearchCity(){
            // Pegando cidade
            Console.WriteLine("Write a city in English: ");
            string read = Console.ReadLine();
            string engine = read.Trim();

            // Precisa instanciar o service primeiro e depois na classe só de objetos chamar ela com await
            ServicesForeCast partOfService = new();
            // Esperar na api buscar a informação passada
            Weather search = await partOfService.SearchOnApi(engine);

            Console.WriteLine(search.city);
            Console.WriteLine(search.damp);
            Console.WriteLine(search.temperatureInCelsius);
        }
    }
}