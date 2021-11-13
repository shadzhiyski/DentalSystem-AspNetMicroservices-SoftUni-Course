namespace DentalSystem.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;
    using static Constants;

    public class AuthorizeDentistAttribute : AuthorizeAttribute
    {
        public AuthorizeDentistAttribute() => this.Roles = DentistRoleName;
    }
}
