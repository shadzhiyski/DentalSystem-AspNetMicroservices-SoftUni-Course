namespace DentalSystem.Scheduling.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Services.Data;

    public interface ITreatmentSessionService : IDataService<TreatmentSession>
    {
        Task<TreatmentSession> Find(Guid referenceId);

        Task<TreatmentSessionsOutputModel> Get(
            Guid referenceId);

        Task<IEnumerable<TreatmentSessionsOutputModel>> GetPatientTreatmentSessions(
            Guid patientReferenceId, TreatmentSessionsQuery query);

        Task<IEnumerable<TreatmentSessionsOutputModel>> GetDentistTreatmentSessions(
            Guid dentistReferenceId, TreatmentSessionsQuery query);

        Task<IEnumerable<TreatmentSessionViewOutputModel>> GetAllTreatmentSessions(TreatmentSessionsQuery query);
    }
}