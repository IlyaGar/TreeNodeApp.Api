using Microsoft.EntityFrameworkCore;
using TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Models;
using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Models;

namespace TreeNodeApp.DataAccess.Repository.Interface.Context
{
    public class TreeNodeDbContext : DbContext
    {
        public DbSet<TreeNode> TreeModels { get; set; }
        public DbSet<JournalException> JournalExceptions { get; set; }

        public TreeNodeDbContext(DbContextOptions<TreeNodeDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
