using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Data;

public class DbContext: Microsoft.EntityFrameworkCore.DbContext
{
    protected DbContext()
    {
    }

    public DbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
           new Item(){Id = 1,Name="Infinity Edge",Weight=1},
           new Item(){Id = 2,Name="Fork",Weight=2}
           
        });
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack(){Amount = 4,CharacterId = 1,ItemId =1},
            new Backpack(){Amount = 1,CharacterId = 2,ItemId =2},
            
        });
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character(){CurrentWeight = 4,FirstName = "Draven",Id = 1,LastName = "Noxus",MaxWeight = 6},
            new Character(){CurrentWeight = 2,FirstName = "Udyr",Id = 2,LastName = "Freljord",MaxWeight = 12}
            
        });
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle(){CharacterId = 1,TitleId =1,AcquiredAt = new DateTime(2000,12,12)},
            new CharacterTitle(){CharacterId = 2,TitleId =2,AcquiredAt = new DateTime(2000,12,13)}
        });
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title(){Id = 1,Name="The Strongest"},
            new Title(){Id = 2,Name="Even stronger"}
        });

    }
}