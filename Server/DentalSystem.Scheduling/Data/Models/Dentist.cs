namespace DentalSystem.Scheduling.Data.Models
{
    using System;
    using DentalSystem.Data.Models;

    public class Dentist : PublicEntity
    {
        public string UserId { get; set; }

        public Guid TeamId { get; set; }

        public virtual DentalTeam Team { get; set; }
    }
}