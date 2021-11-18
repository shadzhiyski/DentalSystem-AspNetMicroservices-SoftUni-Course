namespace DentalSystem.Scheduling.Data.Models
{
    using System;
    using DentalSystem.Data.Models;

    public class Patient : IPublicEntity
    {
        public Guid Id { get; set; }

        public Guid ReferenceId { get; set; }

        public string Email { get; set; }
    }
}