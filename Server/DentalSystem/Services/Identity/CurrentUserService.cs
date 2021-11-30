namespace DentalSystem.Services.Identity
{
    using System;
    using System.Security.Claims;
    using Infrastructure;
    using Microsoft.AspNetCore.Http;

    using static DentalSystem.Infrastructure.InfrastructureConstants;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = this.user.FindFirstValue(ClaimTypes.NameIdentifier);
            ReferenceId = Guid.Parse(this.user.FindFirstValue(UserReferenceIdLabel) ?? Guid.Empty.ToString());
        }

        public string UserId { get; }

        public Guid ReferenceId { get; }

        public bool IsAdministrator => this.user.IsAdministrator();
    }
}
