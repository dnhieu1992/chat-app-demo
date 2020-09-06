using ChatApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Infrastructure.Repositories
{
    public interface IConversationRepository : IBaseRepository<Conversation>
    {

    }
    public class ConversationRepostitory : BaseRepository<Conversation>, IConversationRepository
    {
        public ConversationRepostitory(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
