﻿using LIFE.JOY.Domain.Models.Basic;
using NHibernate;
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

            Property(x => x.Source, m =>
            {
                m.Column(c =>
                {
                    c.Name("SOURCE");
                    c.NotNullable(true);
                });
            });

            Property(x => x.Gender, m =>
            {
                m.Column(c =>
                {
                    c.Name("GENDER");
                    c.NotNullable(true);
                });
            });

            Property(x => x.Nickname, m =>
            {
                m.Column(c =>
                {
                    c.Name("NICK_NAME");
                    c.NotNullable(false);
                });
            });

            Property(x => x.Birth, m =>
            {
                m.Type(NHibernateUtil.Date);
                m.Column(c =>
                {
                    c.Name("BIRTH");
                    c.NotNullable(false);
                });
            });

            Property(x => x.Bio, m =>
            {
                m.Column(c =>
                {
                    c.Name("BIO");
                    c.NotNullable(false);
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