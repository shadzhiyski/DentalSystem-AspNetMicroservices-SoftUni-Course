using System;

namespace DentalSystem.Services.Identity
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        Guid ReferenceId { get; }

        bool IsAdministrator { get; }
    }
}
