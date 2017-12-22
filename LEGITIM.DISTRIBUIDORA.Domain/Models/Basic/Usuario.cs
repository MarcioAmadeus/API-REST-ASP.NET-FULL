using LEGITIM.DISTRIBUIDORA.Utils.Enums;
using LEGITIM.DISTRIBUIDORA.Utils.SoftDelete;
using SharpArch.Domain.DomainModel;
using System.Collections.Generic;

namespace LEGITIM.DISTRIBUIDORA.Domain.Models.Basic
{
    public class Usuario : EntityWithTypedId<int>, ISoftDelete
    {
        public virtual eSimNao Ativo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string PathPhoto { get; set; }
        public virtual string FolderPhotos { get; set; }

        public virtual string Login { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string PessoaId { get; set; }
        public virtual Perfil Perfil { get; set; }


    }
}
