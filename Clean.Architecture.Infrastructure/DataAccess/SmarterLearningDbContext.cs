using Microsoft.EntityFrameworkCore;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Infrastructure.DataAccess
{
    public class SmarterLearningDbContext: DbContext
    {
        public SmarterLearningDbContext(DbContextOptions<SmarterLearningDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Learner> Learners { get; set; }
        public DbSet<LearnerResponse> LearnerResponses { get; set; }
        public DbSet<FailoverEntry> FailoverEntries { get; set; }
    }
}
