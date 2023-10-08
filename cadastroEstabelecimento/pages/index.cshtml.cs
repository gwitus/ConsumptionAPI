using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace cadastroEstabelecimento.pages
{
    public class index : PageModel {
        public int teste = 0;
        public void OnGet()
        {
            Console.WriteLine($"Cada um com seus problems! {teste}");
        }
    }
}