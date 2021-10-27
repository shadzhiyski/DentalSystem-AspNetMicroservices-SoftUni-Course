namespace DentalSystem.Scheduling.Data.Models
{
    using System;

    public class Patient
    {
        public Guid Id { get; set; }

        public Guid ReferenceId { get; set; }

        public string UserId { get; set; }
    }
}