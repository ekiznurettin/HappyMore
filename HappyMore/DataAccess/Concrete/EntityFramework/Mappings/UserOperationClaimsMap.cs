using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserOperationClaimsMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.OperationClaimId).IsRequired();
            builder.ToTable("UserOperationClaims");
        }
    }
}
