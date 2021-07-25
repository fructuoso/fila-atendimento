using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.ViewModels
{
    public class SolicitacaoAtendimentoResponse
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string TipoAtendimento { get; set; }
        public DateTime DataHoraSolicitacao { get; set; }
    }
}
