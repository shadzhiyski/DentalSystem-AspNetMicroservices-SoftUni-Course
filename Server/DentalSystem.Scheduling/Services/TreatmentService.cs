namespace DentalSystem.Scheduling.Services
{
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;

    public class TreatmentService : DataService<Treatment>, ITreatmentService
    {
        public TreatmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}