namespace DentalSystem.Data.Models
{
    using System;

    public class PublicEntity : IEntity
    {
        public Guid ReferenceId { get; set; }
    }
}