using Microsoft.EntityFrameworkCore;
using PF_LAB3_BSIT31E1_Joshua_Villafuerte.Models;

public class GreedDbContext : DbContext
{
    public GreedDbContext(DbContextOptions<GreedDbContext> options)
        : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }
}
