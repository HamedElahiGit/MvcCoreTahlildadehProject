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
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(X => X.LastName).HasMaxLength(200).IsRequired();
            builder.Property(X => X.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(X => X.Mobile).HasMaxLength(13).IsRequired();
            builder.Property(X => X.Phone).HasMaxLength(13).IsRequired();
            builder.HasMany(x => x.Enrollments).WithOne(x => x.Student).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
