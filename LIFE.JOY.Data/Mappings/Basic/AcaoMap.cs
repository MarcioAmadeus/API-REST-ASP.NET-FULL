using LIFE.JOY.Domain.Models.Basic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace LIFE.JOY.Data.Mappings.Basic
{
    public class AcaoMap : ClassMapping<Acao>
    {
        public AcaoMap()
        {
            Schema("GESTAO_ACADEMICA");
            Table("ACAO");

            Where("ATIVO = 'S'");

            Id(x => x.Id, m =>
            {
                m.Column("SQ_ACAO");
                m.Generator(Generators.Native, g => g.Params(new { sequence = "SQ_SQ_ACAO" }));
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

            Property(x => x.Controller, m =>
            {
                m.Column(c =>
                {
                    c.Name("CONTROLLER");
                    c.NotNullable(true);
                });
            });

            Property(x => x.Action, m =>
            {
                m.Column(c =>
                {
                    c.Name("ACTION");
                    c.NotNullable(true);
                });
            });


            Property(x => x.Prioridade, m =>
            {
                m.Column(c =>
                {
                    c.Name("PRIORIDADE");
                    c.NotNullable(false);
                });
            });

            Property(x => x.URL, m =>
            {
                m.Column(c =>
                {
                    c.Name("URL");
                    c.NotNullable(true);
                });
            });

            Property(x => x.Pai, m =>
            {
                m.Column(c =>
                {
                    c.Name("PAI");
                    c.NotNullable(false);
                });
            });

            Property(x => x.PrioridadeInterna, m =>
            {
                m.Column(c =>
                {
                    c.Name("PRIORIDADE_INTERNA");
                    c.NotNullable(false);
                });
            });

            Property(x => x.VisivelNoMenu, m =>
            {
                m.Column(c =>
                {
                    c.Name("VISIVEL_MENU");
                    c.Default("'S'");
                    c.Length(1);
                    c.NotNullable(true);
                });
            });
        }
    }
}
