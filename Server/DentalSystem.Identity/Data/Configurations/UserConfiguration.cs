namespace DentalSystem.Infrastructure.Identity.Persistence.Configurations
{
    using DentalSystem.Data;
    using DentalSystem.Identity.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.ReferenceId).HasValueGenerator<ReferenceIdGenerator>();
        }
    }
}