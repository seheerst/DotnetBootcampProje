using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetBootcampProje.Core.Models;

namespace DotnetBootcampProje.Repository.Confugurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);

            //1-1 artması 
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Number).IsRequired().HasMaxLength(250);

            //Tablo ismi için
            builder.ToTable("Students");
        }
    }
    
}
