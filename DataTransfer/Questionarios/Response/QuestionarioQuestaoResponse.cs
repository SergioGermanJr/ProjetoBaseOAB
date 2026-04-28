using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Questoes.Entidades;

namespace DataTransfer.Questionarios.Response
{
    public class QuestionarioQuestaoResponse
    {
        public int questaoId { get; set; }
        public int? respostaQuestaoId { get; set; }
    }
}
