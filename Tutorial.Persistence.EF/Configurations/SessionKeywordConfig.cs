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
    public class SessionKeywordConfig : IEntityTypeConfiguration<SessionKeyword>
    {
        public void Configure(EntityTypeBuilder<SessionKeyword> builder)
        {
            builder.HasKey(x => x.SessionKeywordId);
            builder.Property(x => x.SessionKeywordValue).HasMaxLength(500).IsRequired();
        }
    }
}
