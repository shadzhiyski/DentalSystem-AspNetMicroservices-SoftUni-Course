namespace DentalSystem.Scheduling.Data
{
    using System.Reflection;
    using DentalSystem.Data;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class SchedulingDbContext : MessageDbContext
    {
        public SchedulingDbContext(
            DbContextOptions<SchedulingDbContext> options)
            : base(options)
        { }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<DentalTeam> DentalTeam { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
