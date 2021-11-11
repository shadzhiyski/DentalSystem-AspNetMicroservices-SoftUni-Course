namespace DentalSystem.Scheduling.Services
{
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;

    public class DentistService : DataService<Dentist>, IDentistService
    {
        public DentistService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}