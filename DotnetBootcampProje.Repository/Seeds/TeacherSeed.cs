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
    public class TeacherSeed : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(
                new Teacher { Id = 1, Name = "Ali Yılmaz", CreatedDate = DateTime.Now, Phone= "5555555", Email = "ali@test.com", ClassId = 1, Password= "12345"},
                new Teacher { Id = 2, Name = "Gizem Tosun", CreatedDate = DateTime.Now, Phone= "5555555", Email = "gizem@test.com", ClassId = 2, Password = "12345" },
                new Teacher { Id = 3, Name = "Ayşe kaya", CreatedDate = DateTime.Now, Phone= "5555555", Email = "ayse@test.com", ClassId= 3, Password = "12345" }

                );
        }
    }
}
