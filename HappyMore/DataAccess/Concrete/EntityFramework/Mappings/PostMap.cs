using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.UserId).IsRequired();
           //  builder.HasOne<User>(a=>a.User).WithMany(c=>c.Posts).HasForeignKey(a=>a.UserId);
            builder.ToTable("Posts");
        }
    }
}
