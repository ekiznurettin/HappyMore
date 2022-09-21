using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public partial class HappyMoreContext : DbContext
    {
        public HappyMoreContext()
        {
        }

        public HappyMoreContext(DbContextOptions<HappyMoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserImage> UserImages{ get; set; }
        public virtual DbSet<OperationClaim> OperationClaims{ get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims{ get; set; }
        public virtual DbSet<Post> Posts{ get; set; }
        public virtual DbSet<Favorite> Favorites{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Server=Ekiz;Database=HappyMoreDb;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=94.73.151.2;Database=u0251038_Moredb; Uid=u0251038_user634;Pwd=PBib23U3XYop55U;");
                optionsBuilder.UseSqlServer("Server=78.135.111.47;Database=HappyMoreDb; Uid=TicaretUser;Pwd=zf35AXFy%A*D");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserImageMap());
            modelBuilder.ApplyConfiguration(new OperationClaimsMap());
            modelBuilder.ApplyConfiguration(new UserOperationClaimsMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new FavoriteMap());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
