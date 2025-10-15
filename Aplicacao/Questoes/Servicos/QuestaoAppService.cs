using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Questoes.Servicos.Interfaces;
using DataTransfer.Questoes.Response;
using Dominio.Questoes.Entidades;
using Dominio.Questoes.Servicos.Interfaces;

namespace Aplicacao.Questoes.Servicos
{
    public class QuestaoAppService : IQuestaoAppService
    {
        private readonly IQuestaoService questaoService;
        public QuestaoAppService(IQuestaoService questaoService)
        {
            this.questaoService = questaoService;   
        }
        public async Task<QuestaoResponse> ValidarAsync(int id)
        {
            Questao questao =  await this.questaoService.ValidarAsync(id);
            return new QuestaoResponse { Texto = questao.Texto}
            ;

        }
    }
}
