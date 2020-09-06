using ChatApp.WebApi.Models;

namespace ChatApp.WebApi.Infrastructure.Repositories
{
    public interface IMessageRepository : IBaseRepository<Messages>
    {

    }
    public class MessageRepository : BaseRepository<Messages>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
