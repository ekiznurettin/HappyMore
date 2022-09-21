using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class OperationClaimsMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.ToTable("OperationClaims");
        }
    }
}
