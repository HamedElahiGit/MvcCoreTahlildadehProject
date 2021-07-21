using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;

namespace Tutorial.Persistence.EF.Configurations
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SessionNo).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(400).IsRequired();
            builder.Property(x => x.SessionTitle).HasMaxLength(300).IsRequired();
            builder.HasMany(x => x.SessionKeywords).WithOne(x => x.Session).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(x => x.Images).WithOne(x => x.Session).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(x => x.Files).WithOne(x => x.Session).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
