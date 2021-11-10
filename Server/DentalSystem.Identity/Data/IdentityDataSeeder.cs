namespace DentalSystem.Identity.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using DentalSystem.Data;
    using DentalSystem.Messages.Identity;
    using DentalSystem.Services.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Models;

    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationSettings applicationSettings;
        private readonly IdentitySettings identitySettings;

        public IdentityDataSeeder(
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<ApplicationSettings> applicationSettings,
            IOptions<IdentitySettings> identitySettings)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.applicationSettings = applicationSettings.Value;
            this.identitySettings = identitySettings.Value;
        }

        public void SeedData()
        {
            if (!this.roleManager.Roles.Any())
            {
                Task
                    .Run(async () =>
                    {
                        var adminRole = new IdentityRole(Constants.AdministratorRoleName);

                        await this.roleManager.CreateAsync(adminRole);

                        var adminUser = new User
                        {
                            UserName = "admin@dcs.com",
                            Email = "admin@dcs.com",
                            SecurityStamp = "RandomSecurityStamp"
                        };

                        await this.userManager.CreateAsync(adminUser, this.identitySettings.AdminPassword);

                        await this.userManager.AddToRoleAsync(adminUser, Constants.AdministratorRoleName);

                        var dentistRole = new IdentityRole(Constants.DentistRoleName);
                        await this.roleManager.CreateAsync(dentistRole);

                        var patientRole = new IdentityRole(Constants.PatientRoleName);
                        await this.roleManager.CreateAsync(patientRole);
                    })
                    .GetAwaiter()
                    .GetResult();
            }

            if (this.applicationSettings.SeedInitialData)
            {
                Task
                    .Run(async () =>
                    {
                        if (await this.userManager.FindByIdAsync(DataSeederConstants.DefaultDentistUserId) != null)
                        {
                            return;
                        }

                        var dentistUser = new User
                        {
                            Id = DataSeederConstants.DefaultDentistUserId,
                            UserName = "dentalcare_dentist@dcs.com",
                            Email = "dentalcare_dentist@dcs.com"
                        };

                        await this.userManager.CreateAsync(dentistUser, DataSeederConstants.DefaultDentistUserPassword);

                        await this.userManager.AddToRoleAsync(dentistUser, Constants.DentistRoleName);

                        var dentistRegisteredMessage = new DentistRegisteredMessage
                        {
                            DentalTeamName = Constants.DefaultDentalTeamName,
                            ReferenceId = dentistUser.Id,
                        };

                        await unitOfWork.Save(dentistRegisteredMessage);
                    })
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
