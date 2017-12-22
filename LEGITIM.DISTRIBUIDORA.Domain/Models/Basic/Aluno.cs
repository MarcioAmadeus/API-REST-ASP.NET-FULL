using LEGITIM.DISTRIBUIDORA.Utils.Enums;
using LEGITIM.DISTRIBUIDORA.Utils.SoftDelete;
using SharpArch.Domain.DomainModel;
using System;

namespace LEGITIM.DISTRIBUIDORA.Domain.Models.Basic
{
    public class Aluno : EntityWithTypedId<int>, ISoftDelete
    {
        public virtual eSimNao Ativo { get; set; }
        public virtual string Nome { get; set; }

    }
}
