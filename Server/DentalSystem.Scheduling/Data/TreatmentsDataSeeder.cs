namespace DentalSystem.Identity.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using DentalSystem.Scheduling.Data;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;
    using Microsoft.Extensions.Options;

    public class TreatmentsDataSeeder : IDataSeeder
    {
        private readonly SchedulingDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationSettings _applicationSettings;

        public TreatmentsDataSeeder(
            SchedulingDbContext db,
            IUnitOfWork unitOfWork,
            IOptions<ApplicationSettings> applicationSettings)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _applicationSettings = applicationSettings.Value;
        }

        public void SeedData()
        {
            if (_applicationSettings.SeedInitialData)
            {
                if (!_db.Set<Treatment>().Any())
                {
                    foreach (var treatment in GetTreatments())
                    {
                        _db.Set<Treatment>().Add(treatment);
                    }

                    _unitOfWork.Save()
                        .GetAwaiter()
                        .GetResult();
                }
            }
        }

        private IEnumerable<Treatment> GetTreatments()
            => new List<Treatment>
            {
                new Treatment() { Name = "Bonding", DurationInMinutes = 45 },
                new Treatment() { Name = "Crowns and Caps", DurationInMinutes = 60 },
                new Treatment() { Name = "Filling And Repair", DurationInMinutes = 45 },
                new Treatment() { Name = "Extraction", DurationInMinutes = 60 },
                new Treatment() { Name = "Bridges and Implants", DurationInMinutes = 120 },
                new Treatment() { Name = "Braces", DurationInMinutes = 60 },
                new Treatment() { Name = "Teeth Whitening", DurationInMinutes = 45 },
                new Treatment() { Name = "Examination", DurationInMinutes = 30 },
            };
    }
}
