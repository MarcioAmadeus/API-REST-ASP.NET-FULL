using LIFE.JOY.Domain.Models.Basic;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace LIFE.JOY.Data.Mappings.Basic
{
    public class AlunoMap : ClassMapping<Aluno>
    {
        public AlunoMap()
        {
           Schema("GESTAO_ACADEMICA");
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

            Property(x => x.Matricula, m =>
            {
                m.Column(c =>
                {
                    c.Name("MATRICULA");
                    c.NotNullable(true);
                });
            });

            Property(x => x.EmailExterno, m =>
            {
                m.Column(c =>
                {
                    c.Name("EMAIL_EXTERNO");
                    c.NotNullable(true);
                });
            });

            Property(x => x.EmailInterno, m =>
            {
                m.Column(c =>
                {
                    c.Name("EMAIL_INTERNO");
                    c.NotNullable(false);
                });
            });

            Property(x => x.Curriculo, m =>
            {
                m.Column(c =>
                {
                    c.Name("CURRICULO");
                    c.NotNullable(false);
                });
            });

         
            Property(x => x.Situacao, m =>
            {
                m.Column(c =>
                {
                    c.Name("SITUACAO");
                    c.NotNullable(false);
                });
            });

            Property(x => x.DataIngresso, m =>
            {
                m.Type(NHibernateUtil.Date);
                m.Column(c =>
                {
                    c.Name("DATA_INGRESSO");
                    c.NotNullable(false);
                });
            });

            

            //VINCULO TRABALHO
            Property(x => x.EnderecoProfissional, m =>
            {
                m.Column(c =>
                {
                    c.Name("ENDERECO_PROFISSIONAL");
                    c.NotNullable(false);
                });
            });

            Property(x => x.Cargo, m =>
            {
                m.Column(c =>
                {
                    c.Name("CARGO");
                    c.NotNullable(false);
                });
            });

            Property(x => x.TipoInstituicao, m =>
            {
                m.Column(c =>
                {
                    c.Name("TIPO_INSTITUICAO");
                    c.NotNullable(false);
                });
            });

            Property(x => x.TipoVinculo, m =>
            {
                m.Column(c =>
                {
                    c.Name("TIPO_VINCULO");
                    c.NotNullable(false);
                });
            });
            Property(x => x.ExpectativaAtuacao, m =>
            {
                m.Column(c =>
                {
                    c.Name("EXPECTATIVA_ATUACAO");
                    c.NotNullable(false);
                });
            });

            Property(x => x.MesmaAreaTrabalho, m =>
            {
                m.Column(c =>
                {
                    c.Name("MESMA_AREA_TRABALHO");
                    c.NotNullable(false);
                });
            });

            //FINANCIADOR
            Property(x => x.ProgramaFomento, m =>
            {
                m.Column(c =>
                {
                    c.Name("PROGRAMA_FOMENTO");
                    c.NotNullable(false);
                });
            });

            Property(x => x.NumeroMesesBolsa, m =>
            {
                m.Column(c =>
                {
                    c.Name("NUMERO_MESES_BOLSA");
                    c.NotNullable(false);
                });
            });

        }
    }
}
