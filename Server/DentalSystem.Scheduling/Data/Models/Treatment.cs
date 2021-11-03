namespace DentalSystem.Scheduling.Data.Models
{
    using System;
    using DentalSystem.Data.Models;

    public class Treatment : PublicEntity
    {
        public string Name { get; set; }

        public int DurationInMinutes { get; set; }
    }
}