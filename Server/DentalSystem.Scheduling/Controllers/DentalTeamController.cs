namespace DentalSystem.Scheduling.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalSystem.Controllers;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Scheduling.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DentalTeamController : ApiController
    {
        private readonly IDentalTeamService _dentalTeamService;

        public DentalTeamController(IDentalTeamService dentalTeamService)
        {
            _dentalTeamService = dentalTeamService;
        }

        [HttpGet("/dentalTeam/all")]
        [Authorize]
        public async Task<IEnumerable<DentalTeamOutputModel>> GetAll()
        {
            var result = await _dentalTeamService.GetAll();

            return result;
        }
    }
}