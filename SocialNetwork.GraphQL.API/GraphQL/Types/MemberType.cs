using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using SocialNetwork.GraphQL.API.Entities;
using SocialNetwork.GraphQL.API.Repositories;

namespace SocialNetwork.GraphQL.API.GraphQL.Types
{
    public class MemberType : ObjectGraphType<Member>
    {
        public MemberType(IDataLoaderContextAccessor accessor, IPostRepository postRepository)
        {
            Field(u => u.Id).Description("Identity of member");
            Field(u => u.Name).Description("Name of member");
            Field(u => u.BirthDay).Description("Member's day of birth");
            Field<GenderEnumType>("Gender").Description("Member gender");
            Field(u => u.IsDelete).Description("Indicate whether or not member is delete");
            Field<ListGraphType<PostType>>("posts")
            .Description("List post of member")
            .Resolve(context =>
            {
                var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, Post>(
                    "getPostsByMemberId", postRepository.GetPostsForMembersAsync);

                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}