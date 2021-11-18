
namespace DentalSystem.Messages.Identity
{
    using System;

    public class PatientRegisteredMessage
    {
        public Guid ReferenceId { get; set; }

        public string Email { get; set; }
    }
}