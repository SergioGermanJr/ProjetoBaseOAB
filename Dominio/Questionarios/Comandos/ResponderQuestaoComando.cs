using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Questionarios.Entidades;
using Dominio.Questoes.Entidades;

namespace Dominio.Questionarios.Comandos
{
    public class ResponderQuestaoComando
    {
        public int questionarioId { get; set; }
        public int questaoId { get; set; }
        public int respostaQuestaoId { get; set; }
    }
}
