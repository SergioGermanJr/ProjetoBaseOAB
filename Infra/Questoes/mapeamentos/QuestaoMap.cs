using Dominio.Questoes.Entidades;
using FluentNHibernate.Mapping;


namespace Infra.Questoes.mapeamentos
{
    public class QuestaoMap : ClassMap<Questao>
    {
        public QuestaoMap()
        {
            Schema("oab");
            Table("QUESTOES");
            Id(produto => produto.Id).Column("ID");
            Map(produto => produto.Texto).Column("TEXTO");

            HasMany(p => p.Respostas)
            .KeyColumn("QUESTAOID") 
            .Inverse()              
            .Cascade.AllDeleteOrphan() 
            .LazyLoad();
        }
    }
}
