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
    public class KeywordConfig : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.HasMany(x => x.SubjectKeywords).WithOne(x => x.Keyword).HasForeignKey(x => x.KeywordId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.SessionKeywords).WithOne(x => x.Keyword).HasForeignKey(x => x.KeywordId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
