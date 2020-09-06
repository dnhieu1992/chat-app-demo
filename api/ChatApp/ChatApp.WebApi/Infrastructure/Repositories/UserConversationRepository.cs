using ChatApp.WebApi.Models;

namespace ChatApp.WebApi.Infrastructure.Repositories
{
    public interface IUserConversationRepository : IBaseRepository<UserConversation>
    {

    }
    public class UserConversationRepository : BaseRepository<UserConversation>, IUserConversationRepository
    {
        public UserConversationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
