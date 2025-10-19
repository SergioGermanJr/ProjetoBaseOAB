using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Questoes.Servicos.Interfaces;
using DataTransfer.Questoes.Requests;
using DataTransfer.Questoes.Response;
using Dominio.Questoes.comandos;
using Dominio.Questoes.Entidades;
using Dominio.Questoes.Servicos.Interfaces;
using Infra.Utils.UnityOfWork.Interface;

namespace Aplicacao.Questoes.Servicos
{
    public class QuestaoAppService : IQuestaoAppService
    {
        private readonly IQuestaoService questaoService;
        private readonly IUnitOfWork _unitOfWork;
        public QuestaoAppService(IQuestaoService questaoService, IUnitOfWork unitOfWork)
        {
            this.questaoService = questaoService;
            _unitOfWork = unitOfWork;
        }
        public async Task<QuestaoResponse> ValidarAsync(int id)
        {
            Questao questao =  await this.questaoService.ValidarAsync(id);
            return new QuestaoResponse { Texto = questao.Texto}
            ;

        }

        public async Task<QuestaoResponse> InserirAsync(QuestaoInserirRequest request)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                QuestaoInserirComando comando = new QuestaoInserirComando 
                { 
                    Texto = request.Texto, 
                    Respostas = request.Respostas.Select(x => new RespostaQuestaoInserirComando { Certa = x.Certa, Texto = x.Texto }).ToList() 
                };
                Questao questao = await this.questaoService.InserirAsync(comando);
                QuestaoResponse response = new QuestaoResponse { Texto = questao.Texto };
                await _unitOfWork.CommitAsync();
                return response;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            
        }
    }
}
