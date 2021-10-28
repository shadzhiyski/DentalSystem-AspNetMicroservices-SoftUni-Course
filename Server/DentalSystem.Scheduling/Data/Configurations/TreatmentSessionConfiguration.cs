namespace DentalSystem.Scheduling.Data.Configurations
{
    using DentalSystem.Data;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Data.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TreatmentSessionConfiguration : IEntityTypeConfiguration<TreatmentSession>
    {
        public void Configure(EntityTypeBuilder<TreatmentSession> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ReferenceId).HasValueGenerator<ReferenceIdGenerator>();
            builder.HasIndex(e => e.ReferenceId).IsUnique();

            builder.HasOne(e => e.Patient);
            builder.Property(e => e.PatientId).IsRequired();

            builder.HasOne(e => e.DentalTeam);
            builder.Property(e => e.DentalTeamId).IsRequired();

            builder.HasOne(e => e.Treatment);
            builder.Property(e => e.TreatmentId).IsRequired();

            builder
                .OwnsOne(e => e.Period)
                .Property(p=>p.Start)
                .HasColumnName(nameof(Period.Start));
            builder
                .OwnsOne(e => e.Period)
                .Property(p=>p.End)
                .HasColumnName(nameof(Period.End));

            builder
                .Property(e => e.Status)
                .HasDefaultValue(TreatmentSessionStatus.Requested);
        }
    }
}