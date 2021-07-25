using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string TipoAtendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public DateTime DataHoraSolicitacao { get; set; }
        public string Status { get; set; }
    }
}
