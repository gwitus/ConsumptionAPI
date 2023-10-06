using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace cadastroEstabelecimento.Pages.Shared
{
    public class _layoutDefault : PageModel
    {
        private readonly ILogger<_layoutDefault> _logger;
        // error reporting
        public _layoutDefault(ILogger<_layoutDefault> logger)
        {
            _logger = logger;
        }

        // permite o acesso, tudo o que vai acontecer quando o corno acessar acontece aqui
        // OnPost é útil quando a página é acessada por meio de requisição de informações, como formulários por exemplo - (funciona para uma página de login - considerar projeto com BD e validação pertinente);
        
        public void OnGet()
        {

        }
    }
}