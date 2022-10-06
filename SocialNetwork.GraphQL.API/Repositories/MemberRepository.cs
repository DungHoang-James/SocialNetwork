using Microsoft.EntityFrameworkCore;
using SocialNetwork.GraphQL.API.DatabaseContext;
using SocialNetwork.GraphQL.API.Entities;

namespace SocialNetwork.GraphQL.API.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly SocialNetworkDbContext _dbContext;

        public MemberRepository(SocialNetworkDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _dbContext.Members.ToListAsync();
        }

        public async Task<Member> GetMemberById(int id)
        {
            return await _dbContext.Members.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void CreateMember(Member member)
        {
            _dbContext.Add(member);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}