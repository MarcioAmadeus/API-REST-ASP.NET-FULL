using LIFE.JOY.Utils.Enums;
using LIFE.JOY.Utils.SoftDelete;
using SharpArch.Domain.DomainModel;
using System;
using System.Collections.Generic;

namespace LIFE.JOY.Domain.Models.Basic
{
    public class Acao : EntityWithTypedId<int>, ISoftDelete
    {
        public virtual eSimNao Ativo { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual string URL { get; set; }
        public virtual int Prioridade { get; set; }
        public virtual string Pai { get; set; }
        public virtual int PrioridadeInterna { get; set; }
        public virtual eSimNao VisivelNoMenu { get; set; }
    }
}
