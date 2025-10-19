
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
        public async Task<RespostaQuestao> InserirAsync(Questao questao, RespostaQuestaoInserirComando comando)
        {
            RespostaQuestao respostaQuestao = new RespostaQuestao(questao, comando.Texto, comando.Certa);

           return await this.RespostaQuestaoRepositorio.SalvarAsync(respostaQuestao);
        }
        public async Task<RespostaQuestao> ValidarAsync(int id)
        {
            return await this.RespostaQuestaoRepositorio.RecuperarAsync(id);
        }
    }
}
