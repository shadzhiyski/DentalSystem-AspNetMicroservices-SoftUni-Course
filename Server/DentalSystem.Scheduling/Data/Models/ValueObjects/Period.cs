using System;

namespace DentalSystem.Scheduling.Data.ValueObjects
{
    public record Period
    {
        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }
    }
}