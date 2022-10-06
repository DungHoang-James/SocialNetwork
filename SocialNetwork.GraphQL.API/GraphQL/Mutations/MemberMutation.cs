using GraphQL;
using GraphQL.Types;
using SocialNetwork.GraphQL.API.Entities;
using SocialNetwork.GraphQL.API.GraphQL.Types;
using SocialNetwork.GraphQL.API.Repositories;

namespace SocialNetwork.GraphQL.API.GraphQL.Mutations
{
    public class MemberMutation : ObjectGraphType
    {
        public MemberMutation(IMemberRepository memberRepository)
        {
            Field<MemberType>("createMember")
            .Argument<NonNullGraphType<MemberInputType>>("memberInput")
            .ResolveAsync(async context =>
            {
                var member = context.GetArgument<Member>("memberInput");
                memberRepository.CreateMember(member);
                await memberRepository.SaveAsync();
                return member;
            });
        }
    }
}