using Aplicacao.Questoes.Servicos.Interfaces;
using DataTransfer.Questoes.Requests;
using Dominio.Questoes.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISession = NHibernate.ISession;

namespace API.Controllers.Questoes
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoController : ControllerBase
    {
        private readonly IQuestaoAppService questaoAppService;
        public QuestaoController(IQuestaoAppService questaoAppService)
        {
            this.questaoAppService = questaoAppService;
        }
        [HttpGet("Id")]
        public async Task<ActionResult> Questao(int Id)
        {
            return Ok(await questaoAppService.ValidarAsync(Id));
        }
        [HttpPost]
        public async Task<ActionResult> Inserir(QuestaoInserirRequest request)
        {
            return Ok(await questaoAppService.InserirAsync(request));


        }
    }
}
