using Microsoft.EntityFrameworkCore;
using WebApiKhanhPhong.Models;

namespace WebApiKhanhPhong.DbContext
{
    public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}