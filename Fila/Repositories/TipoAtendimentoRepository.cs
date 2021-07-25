using Fila.EF;
using Fila.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Repositories
{
    public class TipoAtendimentoRepository : ITipoAtendimentoRepository
    {
        private readonly FilaDbContext _filaDbContext;
        private readonly DbSet<TipoAtendimento> _dbSet;

        public TipoAtendimentoRepository(FilaDbContext filaDbContext)
        {
            _filaDbContext = filaDbContext;
            _dbSet = _filaDbContext.Set<TipoAtendimento>();
        }

        public int GerarProximoNumero(string tipo)
        {
            var tipoAtendimento = _dbSet.FirstOrDefault(t => t.Tipo == tipo);

            if (tipoAtendimento == null)
            {
                tipoAtendimento = new TipoAtendimento() { Tipo = tipo, UltimoNumero = 1 };
                _dbSet.Add(tipoAtendimento);
            }
            else
            {
                tipoAtendimento.UltimoNumero++;
                _dbSet.Update(tipoAtendimento);
            }

            _filaDbContext.SaveChanges();

            return tipoAtendimento.UltimoNumero;
        }
    }
}
