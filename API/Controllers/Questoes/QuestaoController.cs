using Dominio.Questoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISession = NHibernate.ISession;

namespace API.Controllers.Questoes
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoController : ControllerBase
    {
        private readonly ISession session;
        public QuestaoController(ISession session)
        {
            this.session = session;
        }
        [HttpGet]
        public ActionResult Questao() {
            return Ok(session.Query<Questao>());
        }
    }
}
