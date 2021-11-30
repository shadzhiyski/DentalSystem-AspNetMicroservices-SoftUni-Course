namespace DentalSystem.Scheduling.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Services.Data;

    public interface IDentalTeamService : IDataService<DentalTeam>
    {
        Task<DentalTeam> FindByName(string name);

        Task<IEnumerable<DentalTeamOutputModel>> GetAll();
    }
}