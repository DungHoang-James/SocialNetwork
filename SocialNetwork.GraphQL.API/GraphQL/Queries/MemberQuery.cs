using GraphQL;
using GraphQL.Types;
using SocialNetwork.GraphQL.API.Entities;
using SocialNetwork.GraphQL.API.Entities.Enums;
using SocialNetwork.GraphQL.API.GraphQL.Types;
using SocialNetwork.GraphQL.API.Repositories;

namespace SocialNetwork.GraphQL.API.GraphQL.Queries
{
    public class MemberQuery : ObjectGraphType
    {
        public MemberQuery(IMemberRepository memberRepository)
        {
            Field<ListGraphType<MemberType>>("members")
            .ResolveAsync(async context =>
            {
                return await memberRepository.GetMembersAsync();
            });

            Field<MemberType>("member")
            .Argument<NonNullGraphType<IdGraphType>>("id")
            .ResolveAsync(async context =>
            {
                int id = context.GetArgument<int>("id");
                return await memberRepository.GetMemberById(id);
            });
        }
    }
}