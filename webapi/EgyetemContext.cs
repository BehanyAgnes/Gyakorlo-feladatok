using DiakokWebApi.Model;
using Microsoft.EntityFrameworkCore;



    namespace DiakokWebApi.Data
    {
        public class EgyetemContext : DbContext
        {
            public EgyetemContext(DbContextOptions<EgyetemContext> options) : base(options)
            {

            }

        public DbSet<Diak> Diakok { get; set; }

        public DbSet<Kurzus>Kurzusok  { get; set; }
        }
    }

