namespace DentalSystem.Messages.Identity
{
    using System;

    public class DentistRegisteredMessage
    {
        public string DentalTeamName { get; set; }

        public Guid ReferenceId { get; set; }

        public string Email { get; set; }
    }
}