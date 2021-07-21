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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.ReplyToComment).WithMany(x => x.TheCommentsThatRepliedToThisComment).HasForeignKey(x => x.ReplyToCommentId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
