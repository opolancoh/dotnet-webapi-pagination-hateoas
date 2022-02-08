using Microsoft.EntityFrameworkCore;
using DotNetWebApiPaginationHateoas.Data.Entities;


namespace DotNetWebApiPaginationHateoas.Data
{
    public class HobbyDbContext : DbContext
    {
        public HobbyDbContext(DbContextOptions<HobbyDbContext> options)
        : base(options) { }
        public DbSet<Hobby> Hobbies { get; set; }
    }
}