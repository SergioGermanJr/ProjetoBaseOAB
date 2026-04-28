using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Questoes.Requests
{
    public class QuestaoInserirRequest
    {
        public string Texto { get; set; }
        public IList<RespostaQuestaoInserirRequest> Respostas { get; set; } = new List<RespostaQuestaoInserirRequest>();
    }
}
