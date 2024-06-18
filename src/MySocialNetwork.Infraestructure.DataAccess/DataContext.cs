using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;
using MySocialNetwork.Infraestructure.DataAccess.Mapping;

namespace MySocialNetwork.Infraestructure.DataAccess
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostCommentMap());
            modelBuilder.ApplyConfiguration(new PostInteractionMap());
            modelBuilder.ApplyConfiguration(new UserProfileMap());
            modelBuilder.ApplyConfiguration(new IdentityUserLoginMap());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleMap());
            modelBuilder.ApplyConfiguration(new IdentityUserTokenMap());
        }
    }
}
