namespace DentalSystem.Dealers.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalSystem.Controllers;
    using DentalSystem.Services.Identity;
    using Microsoft.AspNetCore.Mvc;
    using DentalSystem.Scheduling.Services;
    using DentalSystem.Scheduling.Models;
    using System;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Data.ValueObjects;
    using DentalSystem.Infrastructure;
    using Microsoft.AspNetCore.Authorization;

    public class TreatmentSessionController : ApiController
    {
        private readonly ITreatmentService _treatmentService;
        private readonly ITreatmentSessionService _treatmentSessions;
        private readonly IDentalTeamService _dentalTeams;
        private readonly IPatientService _patients;
        private readonly ICurrentUserService _currentUser;

        public TreatmentSessionController(
            ITreatmentService treatmentService,
            ITreatmentSessionService treatmentSessions,
            IDentalTeamService dentalTeams,
            IPatientService patients,
            ICurrentUserService currentUser)
        {
            _treatmentService = treatmentService;
            _treatmentSessions = treatmentSessions;
            _dentalTeams = dentalTeams;
            _patients = patients;
            _currentUser = currentUser;
        }

        [HttpPost("/treatmentSession/request")]
        [AuthorizePatient]
        public async Task<IActionResult> MakeRequest(RequestTreatmentSessionInput input)
        {
            var dentalTeam = await _dentalTeams.FindByReferenceId(input.DentalTeamReferenceId.Value);
            var patient = await _patients.FindByReferenceId(input.PatientReferenceId.Value);
            var treatment = await _treatmentService.FindByReferenceId(input.TreatmentReferenceId.Value);

            var treatmentSession = new TreatmentSession()
            {
                DentalTeamId = dentalTeam?.Id ?? Guid.Empty,
                PatientId = patient?.Id ?? Guid.Empty,
                TreatmentId = treatment?.Id ?? Guid.Empty,
                Status = TreatmentSessionStatus.Requested,
                Period = new Period{ Start = input.Start.Value, End = input.End.Value }
            };

            _treatmentSessions.Add(treatmentSession);

            await _treatmentSessions.Save();

            return Ok();
        }

        [HttpGet("/treatmentSession")]
        [Authorize]
        public async Task<TreatmentSessionsOutputModel> Get(
            [FromQuery] Guid referenceId)
        {
            var result = await _treatmentSessions.Get(referenceId);

            return result;
        }

        [HttpGet("/treatmentSession/patient")]
        [AuthorizePatient]
        public async Task<IEnumerable<TreatmentSessionsOutputModel>> Patient(
            [FromQuery] TreatmentSessionsQuery query)
        {
            var result = await _treatmentSessions.GetPatientTreatmentSessions(_currentUser.ReferenceId, query);

            return result;
        }

        [HttpGet("/treatmentSession/dentalTeam")]
        [AuthorizeDentist]
        public async Task<IEnumerable<TreatmentSessionsOutputModel>> DentalTeam(
            [FromQuery] TreatmentSessionsQuery query)
        {
            var result = await _treatmentSessions.GetDentistTreatmentSessions(_currentUser.ReferenceId, query);

            return result;
        }

        [HttpPost("/treatmentSession/accept")]
        [AuthorizeDentist]
        public async Task<IActionResult> Accept(
            [FromQuery] Guid referenceId)
        {
            var treatmentSession = await _treatmentSessions.Find(referenceId);
            if (treatmentSession == default)
            {
                return BadRequest("Treatment session does not exist.");
            }

            treatmentSession.Status = TreatmentSessionStatus.Accepted;

            await _treatmentSessions.Save();

            return Ok();
        }

        [HttpPost("/treatmentSession/reject")]
        [AuthorizeDentist]
        public async Task<IActionResult> Reject(
            [FromQuery] Guid referenceId)
        {
            var treatmentSession = await _treatmentSessions.Find(referenceId);
            if (treatmentSession == default)
            {
                return BadRequest("Treatment session does not exist.");
            }

            treatmentSession.Status = TreatmentSessionStatus.Rejected;

            await _treatmentSessions.Save();

            return Ok();
        }

        [HttpGet("/treatmentSession/all")]
        [AuthorizeAdministrator]
        public async Task<IEnumerable<TreatmentSessionViewOutputModel>> All(
            [FromQuery] TreatmentSessionsQuery query)
        {
            var result = await _treatmentSessions.GetAllTreatmentSessions(query);

            return result;
        }
    }
}
