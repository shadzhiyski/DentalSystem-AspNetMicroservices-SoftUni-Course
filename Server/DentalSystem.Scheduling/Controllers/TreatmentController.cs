namespace DentalSystem.Scheduling.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalSystem.Controllers;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Scheduling.Services;
    using Microsoft.AspNetCore.Mvc;

    public class TreatmentController : ApiController
    {
        private readonly ITreatmentService _treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<TreatmentOutputModel>> All() => await _treatmentService.GetAll();
    }
}