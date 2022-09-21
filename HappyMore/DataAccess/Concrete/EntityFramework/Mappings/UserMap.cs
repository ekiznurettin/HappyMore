using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.UserId);
            builder.Property(a => a.UserId).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.Surname).HasMaxLength(50);
            builder.Property(a => a.Mail).IsRequired();
            builder.Property(a => a.Mail).HasMaxLength(75);
            builder.Property(a => a.Address).HasMaxLength(150);
            builder.Property(a => a.Bio).HasMaxLength(500);
            builder.Property(a => a.Phone).HasMaxLength(13);
            builder.Property(a => a.Instagram).HasMaxLength(50);
            builder.Property(a => a.Hobiler).HasMaxLength(500);
            builder.Property(a => a.ProfileImage).HasMaxLength(250);
            builder.Property(a => a.Gender).HasMaxLength(2);
            builder.Property(a => a.Relation).HasMaxLength(100);
            builder.Property(a => a.Province).HasMaxLength(250);
            builder.Property(a => a.Job).HasMaxLength(250);
            builder.Property(a => a.Lat).HasColumnType("DECIMAL(18,12)");
            builder.Property(a => a.Lng).HasColumnType("DECIMAL(18,12)");

            builder.ToTable("Users");
        }
    }
}
