using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Repositories
{
    public interface ITipoAtendimentoRepository
    {
        int GerarProximoNumero(string tipo);
    }
}
