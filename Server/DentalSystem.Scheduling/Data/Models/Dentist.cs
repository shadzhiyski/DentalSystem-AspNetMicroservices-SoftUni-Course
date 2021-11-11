namespace DentalSystem.Scheduling.Data.Models
{
    using System;
    using DentalSystem.Data.Models;

    public class Dentist : IPublicEntity
    {
        public Guid Id { get; set; }

        public Guid ReferenceId { get; set; }

        public string UserId { get; set; }

        public Guid TeamId { get; set; }

        public virtual DentalTeam Team { get; set; }
    }
}