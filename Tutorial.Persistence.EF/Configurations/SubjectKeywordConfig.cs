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
    public class SubjectKeywordConfig : IEntityTypeConfiguration<SubjectKeyword>
    {
        public void Configure(EntityTypeBuilder<SubjectKeyword> builder)
        {
            builder.HasKey(x => x.SubjectKeywordId);
            builder.Property(x => x.SubjectKeywordValue).HasMaxLength(500).IsRequired();
        }
    }
}
