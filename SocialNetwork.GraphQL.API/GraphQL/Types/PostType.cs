using GraphQL.Types;
using SocialNetwork.GraphQL.API.Entities;

namespace SocialNetwork.GraphQL.API.GraphQL.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(p => p.Id).Description("Identity of a post");
            Field(p => p.Content).Description("Content of post");
        }
    }
}