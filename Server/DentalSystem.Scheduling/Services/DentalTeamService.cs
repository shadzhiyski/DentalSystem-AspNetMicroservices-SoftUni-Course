namespace DentalSystem.Scheduling.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;

    public class DentalTeamService : DataService<DentalTeam>, IDentalTeamService
    {
        private readonly IMapper _mapper;

        public DentalTeamService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<DentalTeam> FindByName(string name)
        {
            return await UnitOfWork.Data.Set<DentalTeam>()
                .FirstOrDefaultAsync(dt => dt.Name == name);
        }

        public async Task<IEnumerable<DentalTeamOutputModel>> GetAll()
        {
            var result = UnitOfWork.Data.Set<DentalTeam>();

            return await _mapper.ProjectTo<DentalTeamOutputModel>(result)
                .ToListAsync();
        }
    }
}