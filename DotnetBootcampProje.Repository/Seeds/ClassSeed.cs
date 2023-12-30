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
    public class ClassSeed : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasData(
            new Class { Id = 1, Name = "1.Sınıf", CreatedDate = DateTime.Now },
            new Class { Id = 2, Name = "2.Sınıf", CreatedDate = DateTime.Now },
            new Class { Id = 3, Name = "3.Sınıf", CreatedDate = DateTime.Now }
            );
    }
}
}
