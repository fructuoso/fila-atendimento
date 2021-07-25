using Fila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Services
{
    public interface IAtendimentoService
    {
        Atendimento SolicitarAtendimento(Atendimento atendimento);
        Atendimento ChamarProximo(string tipoAtendimento);
    }
}
