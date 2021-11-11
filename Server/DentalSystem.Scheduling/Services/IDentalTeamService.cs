namespace DentalSystem.Scheduling.Services
{
    using System.Threading.Tasks;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;

    public interface IDentalTeamService : IDataService<DentalTeam>
    {
        Task<DentalTeam> FindByName(string name);
    }
}