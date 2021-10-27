namespace DentalSystem.Scheduling.Data.Models
{
    using System;

    public class Dentist
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid TeamId { get; set; }

        public virtual DentalTeam Team { get; set; }
    }
}