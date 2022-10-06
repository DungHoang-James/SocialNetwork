using SocialNetwork.GraphQL.API.Entities;

namespace SocialNetwork.GraphQL.API.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsByMemberId(int memberId);
        Task<ILookup<int, Post>> GetPostsForMembersAsync(IEnumerable<int> memberId);
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPostById(int id);
    }
}