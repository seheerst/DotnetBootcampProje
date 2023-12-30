using DotnetBootcampProje.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Repository.Seeds
{
    public class StudentSeed : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student { Id = 1, CreatedDate = DateTime.Now, Name = "Seher Selin", Number = "290", TeacherId = 1 },
                new Student { Id = 2, CreatedDate = DateTime.Now, Name = "Şevval Özdemir", Number = "100", TeacherId = 1 },
                new Student { Id = 3, CreatedDate = DateTime.Now, Name = "Ceren Soysal", Number = "100", TeacherId = 2 }
                );
        }
    }
}
