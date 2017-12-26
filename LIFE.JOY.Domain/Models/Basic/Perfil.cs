using LIFE.JOY.Utils.Enums;
using LIFE.JOY.Utils.SoftDelete;
using SharpArch.Domain.DomainModel;
using System;
using System.Collections.Generic;

namespace LIFE.JOY.Domain.Models.Basic
{
    public class Perfil : EntityWithTypedId<int>, ISoftDelete
    {
        public virtual eSimNao Ativo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Acao> Acoes { get; set; }
    }
}
