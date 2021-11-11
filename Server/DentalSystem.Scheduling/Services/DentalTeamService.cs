namespace DentalSystem.Scheduling.Services
{
    using System.Threading.Tasks;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;

    public class DentalTeamService : DataService<DentalTeam>, IDentalTeamService
    {
        public DentalTeamService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public async Task<DentalTeam> FindByName(string name)
        {
            return await UnitOfWork.Data.Set<DentalTeam>()
                .FirstOrDefaultAsync(dt => dt.Name == name);
        }
    }
}