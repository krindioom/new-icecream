using Microsoft.EntityFrameworkCore;

namespace NewIceCream.DAL
{
    public class IceCreamDbContext : DbContext
    {
        public IceCreamDbContext(DbContextOptions<IceCreamDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
