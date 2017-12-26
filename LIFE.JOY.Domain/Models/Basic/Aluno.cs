using LIFE.JOY.Utils.Enums;
using LIFE.JOY.Utils.SoftDelete;
using SharpArch.Domain.DomainModel;
using System;

namespace LIFE.JOY.Domain.Models.Basic
{
    public class Aluno : EntityWithTypedId<int>, ISoftDelete
    {
        public virtual eSimNao Ativo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Matricula { get; set; }
        public virtual string EmailExterno { get; set; }
        public virtual string EmailInterno { get; set; }
        public virtual string Situacao { get; set; }
        public virtual string Curriculo { get; set; }
        public virtual DateTime DataIngresso { get; set; }
        public virtual string LattesLink { get; set; }

        //VINCULO TRABALHO
        public virtual string EnderecoProfissional { get; set; }
        public virtual string Cargo { get; set; }
        public virtual string TipoVinculo { get; set; }
        public virtual string TipoInstituicao { get; set; }
        public virtual string ExpectativaAtuacao { get; set; }
        public virtual string MesmaAreaTrabalho { get; set; }

        //FINANCIADOR
        public virtual string ProgramaFomento { get; set; }
        public virtual int NumeroMesesBolsa { get; set; }

    }
}
