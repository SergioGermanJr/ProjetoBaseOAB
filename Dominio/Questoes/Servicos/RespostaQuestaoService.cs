
using Dominio.Questoes.comandos;
using Dominio.Questoes.Entidades;
using Dominio.Questoes.Repositorios.Interfaces;
using Dominio.Questoes.Servicos.Interfaces;

namespace Dominio.Questoes.Servicos
{
    public class RespostaQuestaoService : IRespostaQuestaoService
    {
        private readonly IRespostaQuestaoRepositorio RespostaQuestaoRepositorio;
        public RespostaQuestaoService(IRespostaQuestaoRepositorio respostaQuestaoRepositorio)
        {
            this.RespostaQuestaoRepositorio = respostaQuestaoRepositorio;
        }
        public async Task<RespostaQuestao> ValidarAsync(int id)
        {
            return await this.RespostaQuestaoRepositorio.RecuperarAsync(id);
        }
    }
}
