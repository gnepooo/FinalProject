// ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<LearningResource> LearningResources { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<ForumReply> ForumReplies { get; set; }
        public DbSet<GroupProject> GroupProjects { get; set; }
        public DbSet<GroupMembership> GroupMemberships { get; set; }
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<StudyGroupMembership> StudyGroupMemberships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships, constraints, etc. here if needed
        }
    }
}
