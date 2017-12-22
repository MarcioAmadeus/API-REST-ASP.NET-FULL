using LEGITIM.DISTRIBUIDORA.Data.Mappings.Basic;
using LEGITIM.DISTRIBUIDORA.Utils;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace LEGITIM.DISTRIBUIDORA.Data
{
    public class MappingHelper
    {
        public static HbmMapping GetIdentityMappings(List<Type> entities)
        {
            var mapper = new ConventionModelMapper();

            // 1. Antes de mapear as propriedades, verificar atributos;
            mapper.BeforeMapProperty += (insp, prop, map) =>
            {
                var stringLength = prop.LocalMember.GetAttribute<StringLengthAttribute>();
                if (stringLength != null)
                    map.Length(stringLength.MaximumLength);

                var required = prop.LocalMember.GetAttribute<RequiredAttribute>();
                if (required != null)
                    map.NotNullable(true);

                var name = prop.LocalMember.GetAttribute<ColumnAttribute>();
                if (name != null)
                    map.Column(name.Name);
            };

            // 2. Antes de mapear as many-to-one e one-to-many, verificar Ids;
            mapper.BeforeMapManyToOne += (insp, prop, map) =>
            {
                map.Column(prop.LocalMember.GetPropertyOrFieldType().Name + "Id");
                map.Cascade(Cascade.Persist);
            };

            mapper.BeforeMapBag += (insp, prop, map) =>
            {
                map.Key(km => km.Column(prop.GetContainerEntity(insp).Name + "Id"));
                map.Cascade(Cascade.All.Include(Cascade.DeleteOrphans));
                map.BatchSize(10);
            };

            // 3. Match
            Func<Type, bool, bool> matchRootEntity =
                (type, wasDeclared) => typeof(EntityWithTypedId<int>).Equals(type.BaseType)
                                    || typeof(EntityWithTypedId<string>).Equals(type.BaseType);

            mapper.IsEntity((type, wasDeclared) => entities.Contains(type));
            mapper.IsRootEntity(matchRootEntity);
            mapper.IsComponent((type, declared) => entities.Contains(type));

            mapper.MapAllEnumsToStrings();

            List<Type> mappings =
                Assembly.GetAssembly(typeof(AlunoMap))
                    .GetExportedTypes()
                    .Where(t => t.BaseType.IsGenericType &&
                            (t.BaseType.GetGenericTypeDefinition().Equals(typeof(ClassMapping<>)) ||
                             t.BaseType.GetGenericTypeDefinition().Equals(typeof(SubclassMapping<>)) ||
                             t.BaseType.GetGenericTypeDefinition().Equals(typeof(JoinedSubclassMapping<>)) ||
                             t.BaseType.GetGenericTypeDefinition().Equals(typeof(UnionSubclassMapping<>))))
                    .ToList();

            mapper.AddMappings(mappings);

            return mapper.CompileMappingFor(entities);
        }
    }
}