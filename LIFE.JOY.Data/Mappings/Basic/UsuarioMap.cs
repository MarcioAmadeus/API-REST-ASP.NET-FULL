using LIFE.JOY.Domain.Models.Basic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace LIFE.JOY.Data.Mappings.Basic
{

    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Schema("GESTAO_ACADEMICA");
            Table("USUARIO");

            Where("ATIVO = 'S'");

            Id(x => x.Id, m =>
            {
                m.Column("SQ_USUARIO");
                m.Generator(Generators.Native, g => g.Params(new { sequence = "SQ_SQ_USUARIO" }));
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

            Property(x => x.Login, m =>
            {
                m.Column(c =>
                {
                    c.Name("LOGIN");
                    c.NotNullable(true);
                });
            });

            Property(x => x.Email, m =>
            {
                m.Column(c =>
                {
                    c.Name("EMAIL");
                    c.NotNullable(true);
                });
            });

            Property(x => x.Senha, m =>
            {
                m.Column(c =>
                {
                    c.Name("SENHA");
                    c.NotNullable(true);
                });
            });

            Property(x => x.PessoaId, m =>
            {
                m.Column(c =>
                {
                    c.Name("PESSOAID");
                    c.NotNullable(false);
                });
            });

            ManyToOne(x => x.Perfil, m =>
            {
                m.ForeignKey("FK_PERFIL");
                m.Column(c =>
                {
                    c.Name("SQ_PERFIL");
                    c.NotNullable(true);
                });
            });
        }
    }
}