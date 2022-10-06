using Microsoft.EntityFrameworkCore;
using SocialNetwork.GraphQL.API.DatabaseContext;
using SocialNetwork.GraphQL.API.Entities;

namespace SocialNetwork.GraphQL.API.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialNetworkDbContext _dbContext;

        public PostRepository(SocialNetworkDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Post>> GetPostsByMemberId(int memberId)
        {
            return await _dbContext.Posts.Where(p => p.MemberId == memberId).ToListAsync();
        }

        public async Task<ILookup<int, Post>> GetPostsForMembersAsync(IEnumerable<int> memberIds)
        {
            var posts = await _dbContext.Posts.Where(p => memberIds.Contains(p.MemberId)).ToListAsync();
            return posts.ToLookup(p => p.MemberId);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}