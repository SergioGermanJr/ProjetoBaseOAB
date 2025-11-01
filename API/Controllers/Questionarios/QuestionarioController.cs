using Aplicacao.Questionarios.servicos.interfaces;
using Aplicacao.Questoes.Servicos.Interfaces;
using DataTransfer.Questionarios.Request;
using DataTransfer.Questionarios.Response; 
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Questionarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionarioController : ControllerBase
    {
        private readonly IQuestionarioAppService questionarioAppService;
        public QuestionarioController(IQuestionarioAppService questionarioAppService)
        {
            this.questionarioAppService = questionarioAppService;
        }

        [HttpPost]
        public async Task<QuestionarioResponse> CriarAsync([FromBody] QuestionarioInserirRequest request)
        {
            QuestionarioResponse response = await questionarioAppService.CriarAsync(request.QuantidadeQuestoes);
            return response;
        }

        [HttpPost("Responder")]
        public async Task<QuestionarioQuestaoResponse> ResponderQuestao(QuestionarioResponderQuestaoRequest request)
        {
            return await this.questionarioAppService.ResponderQuestao(request);
        }

        [HttpPut("Finalizar/{questionarioId}")]

        public async Task<ActionResult<QuestionarioResponse>> FinalizarQuestionario(int questionarioId)
        {
            return Ok(await this.questionarioAppService.FinalizarQuestionarioAsync(questionarioId));
        }
    }
}
