using System.Data;
using cw9.Entites;
using Microsoft.EntityFrameworkCore;

namespace cw9.Data_Access;

public class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost; database=EfToDoApp; User ID=sa;Password=123456;TrustServerCertificate=True;Encrypt=True");
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }
}