using crud_person_c_.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_person_c_.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}
    
    public DbSet<Person> People { get; set; }
}