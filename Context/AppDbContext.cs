using IT.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace IT.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get;set; }
    public DbSet<Admin> Admins { get;set; }
}
