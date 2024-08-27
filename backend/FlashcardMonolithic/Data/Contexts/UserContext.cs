using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class UserContext : DbContext
{
    public DbSet<User> User { get; set; }

    public DbSet<Admin> Admin { get; set; }

    public DbSet<Deck> Deck { get; set; }

    public DbSet<Flashcard> Flashcard { get; set; }

    public UserContext(DbContextOptions options) : base(options)
    {
    }

    

    
}
