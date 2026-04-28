
using Dominio.Questionarios.Entidades;
using FluentNHibernate.Mapping;

namespace Infra.Questionarios.Mapeamentos
{
    public class QuestionarioQuestaoMap : ClassMap<QuestionarioQuestao>
    {
        public QuestionarioQuestaoMap() {
            Schema("oab");
            Table("QUESTIONARIOQUESTOES");
            Id(p => p.Id).Column("ID");
            References(p => p.Questao).Column("QUESTAOID");
            References(p => p.Questionario).Column("QUESTIONARIOID");
            References(p => p.Resposta).Column("RESPOSTAID");

        }
    }
}
