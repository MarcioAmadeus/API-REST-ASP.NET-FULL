using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace LEGITIM.DISTRIBUIDORA.Data.Mappings.Basic
{
    public class PerfilMap : ClassMapping<Perfil>
    {
        public PerfilMap()
        {
           Schema("LEGITIM_DISTRIBUIDORA");
            Table("PERFIL");

            Where("ATIVO = 'S'");

            Id(x => x.Id, m =>
            {
                m.Column("SQ_PERFIL");
                m.Generator(Generators.Native, g => g.Params(new { sequence = "SQ_SQ_PERFIL" }));
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

            Property(x => x.Descricao, m =>
            {
                m.Column(c =>
                {
                    c.Name("DESCRICAO");
                    c.NotNullable(true);
                });
            });

            Bag(x => x.Acoes, collectionMapping =>
            {
                collectionMapping.Schema("LEGITIM_DISTRIBUIDORA");
                collectionMapping.Table("PERFIL_ACAO");
                collectionMapping.Cascade(Cascade.None);
                collectionMapping.Key(k => k.Column("SQ_PERFIL"));
            }, map => map.ManyToMany(p => { p.Column("SQ_ACAO"); p.Where("ATIVO = 'S'"); }));

        }
    }
}
