using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace LEGITIM.DISTRIBUIDORA.Data.Mappings.Basic
{
    public class AlunoMap : ClassMapping<Aluno>
    {
        public AlunoMap()
        {
            Schema("LEGITIM_DISTRIBUIDORA");
            Table("ALUNO");

            Where("ATIVO = 'S'");

            Id(x => x.Id, m =>
            {
                m.Column("SQ_ALUNO");
                m.Generator(Generators.Native, g => g.Params(new { sequence = "SQ_SQ_ALUNO" }));
            });

            Property(x => x.Ativo, m =>
            {
                m.Column(c =>
                {
                    c.Name("ATIVO");
                    c.Default("'S'");
                    c.Length(1);
                    c.NotNullable(true);
                });
            });

            Property(x => x.Nome, m =>
            {
                m.Column(c =>
                {
                    c.Name("NOME");
                    c.NotNullable(true);
                });
            });

        }
    }
}
