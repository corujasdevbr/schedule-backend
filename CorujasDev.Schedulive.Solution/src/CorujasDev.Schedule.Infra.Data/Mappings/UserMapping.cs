using CorujasDev.Schedulive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorujasDev.Schedule.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserDomain>
    {
        public void Configure(EntityTypeBuilder<UserDomain> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("Users");

            builder.Property(x => x.FirstName)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(x => x.TypeUser)
                .HasColumnName("TypeUser")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(c => c.CreatedDate).IsRequired().HasColumnName("CreatedDate");
            builder.Property(c => c.UpdateDate).IsRequired().HasColumnName("UpdateDate");
        }
    }
}
