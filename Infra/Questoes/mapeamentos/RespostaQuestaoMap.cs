using Dominio.Questoes.Entidades;
using FluentNHibernate.Mapping;

namespace Infra.Questoes.mapeamentos
{
    public class RespostaQuestaoMap : ClassMap<RespostaQuestao>
    {
        public RespostaQuestaoMap()
        {
            Schema("oab");
            Table("RESPOSTAQUESTAO");
            Id(p => p.Id).Column("ID");
            References(p => p.Questao).Column("QUESTAOID");
            Map(p => p.Texto).Column("TEXTO");
            Map(p => p.Certa).Column("CERTA");
        }
    }
}
