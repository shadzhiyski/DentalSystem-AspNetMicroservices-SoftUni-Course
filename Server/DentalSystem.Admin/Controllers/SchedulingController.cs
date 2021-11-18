namespace DentalSystem.Admin.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Services.Scheduling;

    public class SchedulingController : AdministrationController
    {
        private readonly ITreatmentSessionService _treatmentSessions;
        private readonly IMapper _mapper;

        public SchedulingController(ITreatmentSessionService treatmentSessions, IMapper mapper)
        {
            _treatmentSessions = treatmentSessions;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
            => View(await _treatmentSessions.All());
    }
}
