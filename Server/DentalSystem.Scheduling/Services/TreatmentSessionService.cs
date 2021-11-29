namespace DentalSystem.Scheduling.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Services;
    using DentalSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;

    public class TreatmentSessionService : DataService<TreatmentSession>, ITreatmentSessionService
    {
        private readonly IMapper _mapper;

        public TreatmentSessionService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<TreatmentSession> Find(Guid referenceId) =>
            await this
                .All()
                .FirstOrDefaultAsync(ts => ts.ReferenceId == referenceId);

        public async Task<PatientTreatmentSessionsOutputModel> Get(Guid referenceId)
        {
            var treatmentSession = await this
                .All()
                .FirstOrDefaultAsync(ts => ts.ReferenceId == referenceId);
            return this._mapper
                .Map<PatientTreatmentSessionsOutputModel>(treatmentSession);
        }

        public async Task<IEnumerable<PatientTreatmentSessionsOutputModel>> GetDentistTreatmentSessions(Guid dentistReferenceId, TreatmentSessionsQuery query)
        {
            var dentists = this.Data.Set<Dentist>();
            var dataQuery = this
                .All()
                .Join(
                    dentists,
                    ts => ts.DentalTeamId,
                    d => d.TeamId,
                    (ts, d) => new { TreatmentSession = ts, DentistReferenceId = d.ReferenceId }
                )
                .Where(r => r.DentistReferenceId == dentistReferenceId)
                .Select(r => r.TreatmentSession);

            return await this._mapper
                .ProjectTo<PatientTreatmentSessionsOutputModel>(dataQuery)
                .ToListAsync();
        }

        public async Task<IEnumerable<PatientTreatmentSessionsOutputModel>> GetPatientTreatmentSessions(Guid patientReferenceId, TreatmentSessionsQuery query)
        {
            var dataQuery = this
                .All()
                .Where(r => r.Patient.ReferenceId == patientReferenceId);

            return await this._mapper
                .ProjectTo<PatientTreatmentSessionsOutputModel>(dataQuery)
                .ToListAsync();
        }

        public async Task<IEnumerable<TreatmentSessionViewOutputModel>> GetAllTreatmentSessions(TreatmentSessionsQuery query)
        {
            var dataQuery = this.All();

            return await this._mapper
                .ProjectTo<TreatmentSessionViewOutputModel>(dataQuery)
                .ToListAsync();
        }
    }
}