namespace DentalSystem.Scheduling.Services
{
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;
    using DentalSystem.Services.Messages;
    using Microsoft.EntityFrameworkCore;

    public class PatientService : DataService<Patient>, IPatientService
    {
        public PatientService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
    }
}