using System;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Api.Core.Shared;

namespace Web.Api.Core.Domain.Entities
{
    public class PermissionMap : BaseEntity
    {
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public Guid PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }
    }
}