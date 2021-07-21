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
    public class TutorConfig : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(X => X.LastName).HasMaxLength(200).IsRequired();
            builder.Property(X => X.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(X => X.Mobile).HasMaxLength(13).IsRequired();
            builder.Property(X => X.Phone).HasMaxLength(13).IsRequired();
            builder.HasMany(x => x.Courses).WithOne(x => x.Tutor).HasForeignKey(x => x.TutorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
