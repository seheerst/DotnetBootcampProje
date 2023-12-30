using DotnetBootcampProje.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Repository.Confugurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);

            //Primary Key Otomatik olarak 1'er 1'er artsın.
            builder.Property(t => t.Id)
                .UseIdentityColumn();

            //TeamName alanı için maksimum uzunluu belirleme ve bu alanı zorunlu hale getirme
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            //Tablo ismini belirleme ( Opsiyon) 
            builder.ToTable("Classes");
        }
    }
}
