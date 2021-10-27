namespace DentalSystem.Scheduling.Data.Models
{
    using System;

    public class Room
    {
        public Guid Id { get; set; }

        public Guid ReferenceId { get; set; }

        public string Name { get; set; }
    }
}