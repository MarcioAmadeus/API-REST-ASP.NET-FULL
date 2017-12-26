using LIFE.JOY.Utils.Enums;
using LIFE.JOY.Utils.SoftDelete;
using SharpArch.Domain.DomainModel;
using System.Collections.Generic;

namespace LIFE.JOY.Domain.Models.Basic
{
    public class Usuario : EntityWithTypedId<int>, ISoftDelete
    {
        public virtual eSimNao Ativo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Login { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string PessoaId { get; set; }
        public virtual Perfil Perfil { get; set; }
       
    }
}
