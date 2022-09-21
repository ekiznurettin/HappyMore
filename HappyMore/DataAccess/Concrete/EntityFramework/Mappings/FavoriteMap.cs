using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class FavoriteMap : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Liked).IsRequired();
            builder.Property(a => a.Liked).HasMaxLength(150);
            builder.Property(a => a.Liking).IsRequired();
            builder.Property(a => a.Liking).HasMaxLength(150);
            builder.ToTable("Favorites");
        }
    }
}
