using System;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangeAsync();
        int SaveChange();
    }
}
