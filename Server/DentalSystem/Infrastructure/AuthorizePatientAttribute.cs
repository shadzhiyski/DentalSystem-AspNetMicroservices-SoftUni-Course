namespace DentalSystem.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;
    using static Constants;

    public class AuthorizePatientAttribute : AuthorizeAttribute
    {
        public AuthorizePatientAttribute() => this.Roles = PatientRoleName;
    }
}
