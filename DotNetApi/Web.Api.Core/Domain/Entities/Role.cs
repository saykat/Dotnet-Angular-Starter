using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Web.Api.Core.Shared;

namespace Web.Api.Core.Domain.Entities
{
    public class Role: BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<PermissionMap> PermissionMaps { get; set; }
    }
}