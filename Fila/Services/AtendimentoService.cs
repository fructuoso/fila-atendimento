using Fila.Models;
using Fila.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly ITipoAtendimentoRepository _tipoAtendimentoRepository;

        public AtendimentoService(
            IAtendimentoRepository atendimentoRepository,
            ITipoAtendimentoRepository tipoAtendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
            _tipoAtendimentoRepository = tipoAtendimentoRepository;
        }

        public Atendimento ChamarProximo(string tipoAtendimento)
        {
            return _atendimentoRepository.ChamarProximo(tipoAtendimento);
        }

        public Atendimento SolicitarAtendimento(Atendimento atendimento)
        {
            atendimento.Numero = _tipoAtendimentoRepository.GerarProximoNumero(atendimento.TipoAtendimentoId);
            atendimento.Status = "SOLICITADO";
            atendimento.DataHoraSolicitacao = DateTime.Now;

            return _atendimentoRepository.Inserir(atendimento);
        }
    }
}
