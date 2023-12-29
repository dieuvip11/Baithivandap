using Microsoft.EntityFrameworkCore;

namespace TranHoangDieu_131.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    }
}