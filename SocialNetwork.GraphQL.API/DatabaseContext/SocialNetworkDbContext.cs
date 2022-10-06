using Microsoft.EntityFrameworkCore;
using SocialNetwork.GraphQL.API.Entities;

namespace SocialNetwork.GraphQL.API.DatabaseContext
{
    public class SocialNetworkDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Post> Posts { get; set; }

        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(m =>
            {
                m.ToTable(nameof(Member));
            });

            modelBuilder.Entity<Post>(p =>
            {
                p.ToTable(nameof(Post));
                p.HasOne(post => post.Member).WithMany().HasForeignKey(post => post.MemberId);
            });
        }
    }
}