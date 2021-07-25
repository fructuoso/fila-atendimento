using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.ViewModels
{
    public class SolicitacaoAtendimentoRequest
    {
        public string Nome { get; set; }
        
        /// <summary>
        /// Normal
        /// Prioritário
        /// </summary>
        public string TipoAtendimento { get; set; }
    }
}
