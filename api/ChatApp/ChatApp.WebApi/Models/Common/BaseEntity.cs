using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.WebApi.Models.Entities.Common
{
    public abstract class BaseEntity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
