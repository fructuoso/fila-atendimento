using Fila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.ViewModels
{
    public class LoginResponse
    {
        public string Login { get; set; }
        public IList<string> Permissoes { get; set; }
        public string Token { get; set; }
    }
}
