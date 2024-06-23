using ClubMembershipApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ClubMembershipApp.Data
{
    public class ClubMembershipDbContext : DbContext
    {
        public DbSet<UserDTO> UsersDTO { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
