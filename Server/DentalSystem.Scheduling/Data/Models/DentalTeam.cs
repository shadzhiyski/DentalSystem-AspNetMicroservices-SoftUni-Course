namespace DentalSystem.Scheduling.Data.Models
{
    using System;
    using DentalSystem.Data.Models;

    public class DentalTeam : PublicEntity
    {
        public string Name { get; set; }

        public Guid RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}