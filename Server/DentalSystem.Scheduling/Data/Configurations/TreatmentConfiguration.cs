namespace DentalSystem.Scheduling.Data.Configurations
{
    using DentalSystem.Data;
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ReferenceId).HasValueGenerator<ReferenceIdGenerator>();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.DurationInMinutes).IsRequired();

            builder.Property(e => e.Name).HasMaxLength(64);

            builder.HasIndex(e => e.ReferenceId).IsUnique();
            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}