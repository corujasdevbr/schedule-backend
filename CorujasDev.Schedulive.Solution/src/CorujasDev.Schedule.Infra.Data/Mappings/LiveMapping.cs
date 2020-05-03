using CorujasDev.Schedulive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorujasDev.Schedule.Infra.Data.Mappings
{
    public class LiveMapping : IEntityTypeConfiguration<LiveDomain>
    {
        public void Configure(EntityTypeBuilder<LiveDomain> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("Lives");

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(x => x.Thumbnail)
                .HasColumnName("Thumbnail")
                .HasColumnType("VARCHAR(350)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("Text")
                .IsRequired();

            builder.Property(x => x.Place)
                .HasColumnName("Place")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(x => x.DateTime)
                .HasColumnName("DateTime")
                .HasColumnType("DateTime2(7)")
                .IsRequired();

            builder.HasOne<CategoryDomain>(c => c.Category)
                .WithMany(l => l.Lives)
                .HasForeignKey(c => c.CategoryId);

            builder.Property(c => c.CreatedDate).IsRequired().HasColumnName("CreatedDate");
            builder.Property(c => c.UpdateDate).IsRequired().HasColumnName("UpdateDate");
        }
    }
}
