using CorujasDev.Schedulive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorujasDev.Schedule.Infra.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<CategoryDomain>
    {
        public void Configure(EntityTypeBuilder<CategoryDomain> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("Categories");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(c => c.CreatedDate).IsRequired().HasColumnName("CreatedDate");
            builder.Property(c => c.UpdateDate).IsRequired().HasColumnName("UpdateDate");
        }
    }
}
