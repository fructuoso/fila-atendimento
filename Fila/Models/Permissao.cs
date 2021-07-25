using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Models
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Permissao(string nome)
        {
            Nome = nome;
        }
    }
}
