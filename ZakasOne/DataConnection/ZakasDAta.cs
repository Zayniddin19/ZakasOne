using Microsoft.EntityFrameworkCore;
using ZakasOne.Model;

namespace ZakasOne.DataConnection
{
    public class ZakasData : DbContext
    {
        public ZakasData(DbContextOptions<ZakasData> options) : base(options) { }
        public DbSet<Zakas> Zakas { get; set; }
    }
}
