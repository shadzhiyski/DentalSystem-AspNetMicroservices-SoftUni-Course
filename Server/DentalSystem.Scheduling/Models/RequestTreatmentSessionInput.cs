namespace DentalSystem.Scheduling.Models
{
    using System;

    public record RequestTreatmentSessionInput
    {
        public Guid? DentalTeamReferenceId { get; init; }

        public Guid? PatientReferenceId { get; init; }

        public Guid? TreatmentReferenceId { get; init; }

        public DateTimeOffset? Start { get; init; }

        public DateTimeOffset? End { get; init; }
    }
}