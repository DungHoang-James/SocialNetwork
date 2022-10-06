using GraphQL.Types;
using SocialNetwork.GraphQL.API.Entities.Enums;

namespace SocialNetwork.GraphQL.API.GraphQL.Types
{
    public class GenderEnumType : EnumerationGraphType<GenderEnum>
    {
        public GenderEnumType()
        {
            Name = "GenderType";
        }
    }
}