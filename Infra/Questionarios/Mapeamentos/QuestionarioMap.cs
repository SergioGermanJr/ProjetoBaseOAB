

using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Enumeradores;
using FluentNHibernate.Mapping;

namespace Infra.Questionarios.Mapeamentos
{
    public class QuestionarioMap : ClassMap<Questionario>
    {
        public QuestionarioMap() {
            Schema("oab");
            Table("QUESTIONARIO");
            Id(p => p.Id).Column("ID");
            Map(p => p.DataInicio).Column("DATA").CustomType<DateTime>();
            Map(p => p.DataConclusao).Column("DATACONCLUSAO").CustomType<DateTime>();
            Map(p => p.Status).Column("STATUS").CustomType<StatusQuestionarioEnum>();
            Map(p => p.Porcentagem).Column("PORCENTAGEM");

            HasMany(p => p.Questoes)
            .KeyColumn("QUESTIONARIOID")
            .Inverse()
            .Cascade.AllDeleteOrphan()
            .LazyLoad();

        }
    }
}
