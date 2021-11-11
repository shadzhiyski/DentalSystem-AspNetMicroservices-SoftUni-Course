namespace DentalSystem.Identity.Data.Models
{
    using System;
    using DentalSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IPublicEntity
    {
        public Guid ReferenceId { get; set; }
    }
}
