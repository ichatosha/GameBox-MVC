using GameBox.Models;

namespace GameBox.Data
{
    public class inherDbContext : DbContext
    {
        public inherDbContext(DbContextOptions<inherDbContext> options) : base(options)
        {
        }

        // Tabels 
        public DbSet<Game> Games { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<GameDevices> GameDevices { get; set; }
        public DbSet<Category> Categories { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category {Id =1, Name = "Sports"},
                    new Category {Id =2, Name = "Action"},
                    new Category {Id =3, Name = "Adventure"},
                    new Category {Id =4, Name = "Racing"},
                    new Category {Id =5, Name = "ski-Fi"},
                    

                });

            modelBuilder.Entity<Devices>()
                .HasData(new Devices[]
                {
                    new Devices {Id =1 , Name = "Playstation" , Icon = "bi bi-playstation"},
                    new Devices {Id =2 , Name = "XBOX"        , Icon = "bi bi-xbox"},
                    new Devices {Id =3 , Name = "PC"          , Icon = "bi bi-pc"},
                    new Devices {Id =4 , Name = "Nintendo"    , Icon = "bi bi-nintendo-switch"}
                });

            modelBuilder.Entity<GameDevices>()
                .HasKey(x => new { x.GameId, x.DeviceId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
