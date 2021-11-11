namespace DentalSystem.Data.Models
{
    using System;

    public interface IPublicEntity
    {
        public Guid ReferenceId { get; set; }
    }
}