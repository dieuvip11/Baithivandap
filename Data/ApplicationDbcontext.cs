using Microsoft.EntityFrameworkCore;
using TranHoangDieu_131;

namespace TranHoangDieu_131.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Lophoc>Lophoc {get;set;}
        public DbSet<TranHoangDieu_131.Sinhvien> Sinhvien { get; set; } = default!;
    }
}