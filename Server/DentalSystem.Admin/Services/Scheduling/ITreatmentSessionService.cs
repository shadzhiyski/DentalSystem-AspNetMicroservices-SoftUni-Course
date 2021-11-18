namespace DentalSystem.Admin.Services.Scheduling
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalSystem.Admin.Models.Scheduling;
    using Refit;

    public interface ITreatmentSessionService
    {
        [Get("/treatmentSession/all")]
        Task<IEnumerable<TreatmentSessionViewItemOutputModel>> All();
    }
}