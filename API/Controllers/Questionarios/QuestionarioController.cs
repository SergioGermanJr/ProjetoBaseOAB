using Aplicacao.Questionarios.servicos.interfaces;
using Aplicacao.Questoes.Servicos.Interfaces;
using DataTransfer.Questionarios.Request;
using DataTransfer.Questionarios.Response;
using Microsoft.AspNetCore.Http;
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
    }
}
