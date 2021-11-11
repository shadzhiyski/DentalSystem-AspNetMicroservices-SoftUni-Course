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
        Task<IEnumerable<PatientTreatmentSessionsOutputModel>> GetPatientTreatmentSessions(
            Guid patientId, PatientTreatmentSessionsQuery query);

        Task<IEnumerable<PatientTreatmentSessionsOutputModel>> GetDentistTreatmentSessions(
            Guid dentistId, PatientTreatmentSessionsQuery query);
    }
}