using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Questoes.Entidades;
using Dominio.Questoes.Repositorios.Interfaces;
using Dominio.Questoes.Servicos.Interfaces;

namespace Dominio.Questoes.Servicos
{
    public class QuestaoService : IQuestaoService
    {
        private readonly IQuestaoRepositorio questaoRepositorio;
        public QuestaoService(IQuestaoRepositorio questaoRepositorio)
        {
            this.questaoRepositorio = questaoRepositorio;
        }
        public async Task<Questao> ValidarAsync(int id)
        {
            Questao questao = await this.questaoRepositorio.RecuperarAsync(id);

            if(questao == null)
                throw new Exception("Questão não encontrada");

            return questao;
        }
    }
}
