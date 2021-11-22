namespace DentalSystem.Scheduling.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Models;
    using DentalSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;

    public class TreatmentService : DataService<Treatment>, ITreatmentService
    {
        private readonly IMapper _mapper;

        public TreatmentService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<TreatmentOutputModel>> GetAll() => await this._mapper
                .ProjectTo<TreatmentOutputModel>(this.All())
                .ToListAsync();
    }
}