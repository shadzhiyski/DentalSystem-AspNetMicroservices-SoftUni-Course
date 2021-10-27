namespace DentalSystem.Scheduling.Data.Configurations
{
    using DentalSystem.Data;
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ReferenceId).HasValueGenerator<ReferenceIdGenerator>();

            builder.Property(e => e.Name).IsRequired();

            builder.HasIndex(e => e.ReferenceId).IsUnique();
        }
    }
}