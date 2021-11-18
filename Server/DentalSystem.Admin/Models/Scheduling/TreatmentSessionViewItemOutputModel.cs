namespace DentalSystem.Admin.Models.Scheduling
{
    using System;

    public class TreatmentSessionViewItemOutputModel
    {
        public string PatientEmail { get; set; }

        public string DentalTeamName { get; set; }

        public string TreatmentName { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public string Status { get; set; }
    }
}