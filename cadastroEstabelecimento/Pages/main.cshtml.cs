using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace cadastroEstabelecimento.Pages
{
    public class main : PageModel
    {
        private readonly ILogger<main> _logger;
        public string teste;

        public main(ILogger<main> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            teste = $"horário{DateTime.Now}";
        }
    }
}