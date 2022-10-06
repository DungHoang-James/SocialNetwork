using GraphQL.Types;
using SocialNetwork.GraphQL.API.GraphQL.Mutations;
using SocialNetwork.GraphQL.API.GraphQL.Queries;

namespace SocialNetwork.GraphQL.API.GraphQL.Schemas
{
    public class MemberSchema : Schema
    {
        public MemberSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<MemberQuery>();
            Mutation = provider.GetRequiredService<MemberMutation>();
        }
    }
}