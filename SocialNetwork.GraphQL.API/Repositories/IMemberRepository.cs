using SocialNetwork.GraphQL.API.Entities;

namespace SocialNetwork.GraphQL.API.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberById(int id);
        void CreateMember(Member member);
        Task<int> SaveAsync();
    }
}