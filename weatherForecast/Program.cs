// Senha da API: 648b3f22ef567da8b7fb4599aaA
using System;
using weatherForecast.Entities;
using weatherForecast.Entities.services;

namespace Principal {
    class Exe 
    {
        static async Task Main (){
            // Precisa instanciar o service primeiro e depois na classe só de objetos chamar ela com await
            ServicesForeCast partOfService = new();
            // Esperar na api buscar a informação passada
            Weather search = await partOfService.SearchOnApi();
            Console.WriteLine($"Nome da Localização: {search.Location.Name}");
        }
        // static async void SearchCity(){}
    }
}