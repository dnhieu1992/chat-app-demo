using ChatApp.WepApi.Models.Identity;
using System;

namespace ChatApp.WebApi.Models.Entities.Common
{
    public abstract class AuditEntity
    {
        public DateTime InsertedAt { get; set; }
        public Guid InsertedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public virtual ApplicationUser InsertedUser { get; set; }
        public virtual ApplicationUser UpdatedUser { get; set; }
    }
}
