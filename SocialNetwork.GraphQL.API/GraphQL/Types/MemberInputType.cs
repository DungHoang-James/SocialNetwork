using GraphQL.Types;

namespace SocialNetwork.GraphQL.API.GraphQL.Types
{
    public class MemberInputType : InputObjectGraphType
    {
        public MemberInputType()
        {
            Name = "memberInputType";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DateGraphType>>("birthDay");
            Field<NonNullGraphType<GenderEnumType>>("gender");
        }
    }
}