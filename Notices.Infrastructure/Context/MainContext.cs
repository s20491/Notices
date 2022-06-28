using Microsoft.EntityFrameworkCore;
using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Context;

public class MainContext : DbContext
{
    public DbSet<Notice> Notice { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<Recipient> Recipient { get; set; }
    public DbSet<Provider> Provider { get; set; }
    public DbSet<Address> Address { get; set; }
    
    public MainContext()
    {
    }
    public MainContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.Notices.db");
    }
    
}