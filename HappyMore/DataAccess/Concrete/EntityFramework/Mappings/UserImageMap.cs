using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserImageMap : IEntityTypeConfiguration<UserImage>
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.ImageUrl).IsRequired();
            builder.Property(a => a.ImageUrl).HasMaxLength(150);
            builder.Property(a => a.UserKey).IsRequired();
            builder.ToTable("UserImages");
        }
    }
}
