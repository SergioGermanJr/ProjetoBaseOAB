using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Questoes.Entidades;

namespace DataTransfer.Questoes.Response
{
    public class QuestaoResponse
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public List<RespostaResponse> Respostas { get; set; }
    }
}
