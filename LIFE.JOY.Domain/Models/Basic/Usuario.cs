using LIFE.JOY.Utils.Enums;
using LIFE.JOY.Utils.SoftDelete;
using SharpArch.Domain.DomainModel;
using System;
using System.Collections.Generic;

namespace LIFE.JOY.Domain.Models.Basic
{
    public class Usuario : EntityWithTypedId<int>, ISoftDelete
    {
        public virtual eSimNao Ativo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Login { get; set; }
        public virtual string Source { get; set; }
        public virtual string PhotoURL { get; set; }
        public virtual string Fullname { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Nickname { get; set; }
        public virtual DateTime Birth { get; set; }
        public virtual string Bio { get; set; }
        public virtual string Senha { get; set; }
        public virtual string PessoaId { get; set; }
        public virtual Perfil Perfil { get; set; }

    }
}
