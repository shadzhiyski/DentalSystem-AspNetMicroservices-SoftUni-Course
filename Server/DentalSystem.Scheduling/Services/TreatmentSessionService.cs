namespace DentalSystem.Scheduling.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Services.Data;
    using DentalSystem.Services.Messages;
    using Microsoft.EntityFrameworkCore;

    public class TreatmentSessionService : DataService<TreatmentSession>, ITreatmentSessionService
    {
        private readonly IMapper _mapper;

        public TreatmentSessionService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientTreatmentSessionsOutputModel>> GetDentistTreatmentSessions(Guid dentistId, PatientTreatmentSessionsQuery query)
        {
            var dentists = this.Data.Set<Dentist>();
            var dataQuery = this
                .All()
                .Join(
                    dentists,
                    ts => ts.DentalTeamId,
                    d => d.TeamId,
                    (ts, d) => new { TreatmentSession = ts, DentistId = d.Id }
                )
                .Where(r => r.DentistId == dentistId)
                .Select(r => r.TreatmentSession);

            return await this._mapper
                .ProjectTo<PatientTreatmentSessionsOutputModel>(dataQuery)
                .ToListAsync();
        }

        public async Task<IEnumerable<PatientTreatmentSessionsOutputModel>> GetPatientTreatmentSessions(Guid patientId, PatientTreatmentSessionsQuery query)
        {
            var dataQuery = this
                .All()
                .Where(r => r.PatientId == patientId);

            return await this._mapper
                .ProjectTo<PatientTreatmentSessionsOutputModel>(dataQuery)
                .ToListAsync();
        }
    }
}