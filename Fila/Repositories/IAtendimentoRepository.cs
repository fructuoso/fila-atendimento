using Fila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Repositories
{
    public interface IAtendimentoRepository
    {
        Atendimento Inserir(Atendimento atendimento);

        Atendimento ChamarProximo(string tipoAtendimento);
    }
}
