using ChatApp.WebApi.Models.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Properties
        private ApplicationDbContext _dbContext;
        private IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public UnitOfWork(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion
        #region Methods
        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> SaveChangeAsync()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
               // ClaimsPrincipal principal = new ClaimsPrincipal();
                var currentUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (currentUser != null)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            ((AuditEntity)entry.Entity).InsertedAt = DateTime.UtcNow;
                            ((AuditEntity)entry.Entity).InsertedBy = Guid.Parse(currentUser.Value);
                            ((AuditEntity)entry.Entity).LastUpdatedDate = DateTime.UtcNow;
                            ((AuditEntity)entry.Entity).LastUpdatedBy = Guid.Parse(currentUser.Value);
                            break;
                        case EntityState.Modified:
                            ((AuditEntity)entry.Entity).LastUpdatedDate = DateTime.UtcNow;
                            ((AuditEntity)entry.Entity).LastUpdatedBy = Guid.Parse(currentUser.Value);
                            break;
                    }
                }
            }
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        #endregion
    }
}
