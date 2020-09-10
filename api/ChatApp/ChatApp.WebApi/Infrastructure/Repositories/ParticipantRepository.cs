using ChatApp.WebApi.Models;

namespace ChatApp.WebApi.Infrastructure.Repositories
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {

    }
    public class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
