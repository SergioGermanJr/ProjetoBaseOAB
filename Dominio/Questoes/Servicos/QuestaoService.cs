using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Questoes.comandos;
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

        public async Task<Questao> InserirAsync(QuestaoInserirComando comando)
        {
            List<Questao> questoes = await this.questaoRepositorio.BuscarQuestoesPorTexto(comando.Texto);
            if(questoes.Count > 0)
            {
                throw new Exception("Questao ja cadastrada");
            }
            Questao questao =  await this.questaoRepositorio.SalvarAsync(new(comando.Texto));
            if(comando.Respostas.Count() != 4) {
                throw new Exception("Deve haver exatamente quatro respostas.");
            }
            if (comando.Respostas.Where(x => x.Certa).Count() != 1) { 
                throw new Exception("Deve haver exatamente uma resposta correta.");
            }
            foreach (var respostaComando in comando.Respostas)
            {
                RespostaQuestao resposta = new(questao, respostaComando.Texto, respostaComando.Certa);
                questao.Respostas.Add(resposta);
            }
            await this.questaoRepositorio.SalvarAsync(questao);
            return questao;
        }
        public async Task<Questao> ValidarAsync(int id)
        {
            Questao questao = await this.questaoRepositorio.RecuperarAsync(id);
            if (questao == null)
                throw new Exception("Questão não encontrada");

            return questao;
        }
    }
}
