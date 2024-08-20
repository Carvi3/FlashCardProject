using FlashCardAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAPI.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Deck> Deck { get; set; }

        public DbSet<Flashcard> Flashcard { get; set; }

        
    }
}
