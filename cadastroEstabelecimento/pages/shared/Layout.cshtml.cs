using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace cadastroEstabelecimento.pages.shared
{
    public class Layout : PageModel
    {
        private readonly ILogger<Layout> _logger;

        public Layout(ILogger<Layout> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}