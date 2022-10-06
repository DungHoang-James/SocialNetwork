namespace SocialNetwork.GraphQL.API.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public int MemberId { get; set; }

        public Member Member { get; set; }
    }
}