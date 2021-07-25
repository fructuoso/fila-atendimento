using Fila.EF;
using Fila.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly FilaDbContext _filaDbContext;
        private readonly DbSet<Atendimento> _dbSet;

        public AtendimentoRepository(FilaDbContext filaDbContext)
        {
            _filaDbContext = filaDbContext;
            _dbSet = _filaDbContext.Set<Atendimento>();
        }

        public Atendimento ChamarProximo(string tipoAtendimento)
        {
            Atendimento atendimento = _dbSet
                .Where(a => a.TipoAtendimentoId == tipoAtendimento && a.Status == "SOLICITADO")
                .OrderBy(a => a.DataHoraSolicitacao)
                .FirstOrDefault();

            if (atendimento != null)
            {
                atendimento.Status = "CHAMADO";
                _filaDbContext.SaveChanges();
            }

            return atendimento;
        }

        public Atendimento Inserir(Atendimento atendimento)
        {
            _dbSet.Add(atendimento);
            _filaDbContext.SaveChanges();
            return atendimento;
        }
    }
}
