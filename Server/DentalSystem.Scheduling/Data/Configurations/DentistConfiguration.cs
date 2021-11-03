namespace DentalSystem.Scheduling.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using DentalSystem.Data;

    public class DentistConfiguration : IEntityTypeConfiguration<Dentist>
    {
        public void Configure(EntityTypeBuilder<Dentist> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ReferenceId).HasValueGenerator<ReferenceIdGenerator>();
            builder.HasIndex(e => e.ReferenceId).IsUnique();

            builder.Property(e => e.UserId).IsRequired();
            builder.HasIndex(e => e.UserId).IsUnique(true);

            builder.HasOne(e => e.Team);
            builder.Property(e => e.TeamId).IsRequired();
        }
    }
}