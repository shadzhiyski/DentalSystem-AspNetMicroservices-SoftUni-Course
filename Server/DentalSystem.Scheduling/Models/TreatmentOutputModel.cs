namespace DentalSystem.Scheduling.Models
{
    using System;
    using DentalSystem.Models;
    using DentalSystem.Scheduling.Data.Models;

    public class TreatmentOutputModel : IMapFrom<Treatment>
    {
        public Guid ReferenceId { get; set; }

        public string Name { get; set; }

        public int DurationInMinutes { get; set; }
    }
}