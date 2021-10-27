namespace DentalSystem.Scheduling.Data.Configurations
{
    using DentalSystem.Data;
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ReferenceId).HasValueGenerator<ReferenceIdGenerator>();

            builder.Property(e => e.UserId).IsRequired();

            builder.HasIndex(e => e.UserId).IsUnique();
            builder.HasIndex(e => e.ReferenceId).IsUnique();
        }
    }
}