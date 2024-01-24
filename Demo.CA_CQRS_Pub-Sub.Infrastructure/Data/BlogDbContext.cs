using Demo.CA_CQRS_Pub_Sub.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo.CA_CQRS_Pub_Sub.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}