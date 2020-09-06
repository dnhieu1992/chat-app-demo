using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.WebApi.Models.Entities.Common
{
    public abstract class MasterDataEntity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsActived { get; set; }
        public bool IsDeleted { get; set; }
    }
}
