namespace DentalSystem.Scheduling.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Services.Data;

    public interface ITreatmentService : IDataService<Treatment>
    {
        Task<IEnumerable<TreatmentOutputModel>> GetAll();
    }
}