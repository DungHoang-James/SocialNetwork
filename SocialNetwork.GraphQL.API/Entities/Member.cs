using SocialNetwork.GraphQL.API.Entities.Enums;

namespace SocialNetwork.GraphQL.API.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public GenderEnum Gender { get; set; }
        public bool IsDelete { get; set; }
    }
}