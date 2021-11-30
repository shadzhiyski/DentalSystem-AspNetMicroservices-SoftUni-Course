namespace DentalSystem.Scheduling.Models
{
    using System;
    using DentalSystem.Models;
    using DentalSystem.Scheduling.Data.Models;

    public class DentalTeamOutputModel : IMapFrom<DentalTeam>
    {
        public Guid ReferenceId { get; set; }

        public string Name { get; set; }
    }
}