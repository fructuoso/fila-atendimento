using Fila.Models;
using Fila.Services;
using Fila.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendimentoController : Controller
    {
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<SolicitacaoAtendimentoResponse> Post(SolicitacaoAtendimentoRequest request)
        {
            Atendimento atendimento = new Atendimento()
            {
                Nome = request.Nome,
                TipoAtendimentoId = request.TipoAtendimento
            };

            _atendimentoService.SolicitarAtendimento(atendimento);

            SolicitacaoAtendimentoResponse response = new SolicitacaoAtendimentoResponse()
            {
                Id = atendimento.Id,
                DataHoraSolicitacao = atendimento.DataHoraSolicitacao,
                Numero = atendimento.Numero,
                TipoAtendimento = atendimento.TipoAtendimentoId
            };

            return Ok(response);
        }

        [HttpGet("{tipoAtendimento}/proximo")]
        [Authorize(Roles = "atendimento")]
        public ActionResult<Atendimento> Proximo(string tipoAtendimento)
        {
            Atendimento atendimento = _atendimentoService.ChamarProximo(tipoAtendimento);

            if (atendimento == null) return NotFound(); //404

            return Ok(atendimento);
        }
    }
}
