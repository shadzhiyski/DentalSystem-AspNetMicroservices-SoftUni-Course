namespace DentalSystem.Notifications.Messages
{
    using System.Threading.Tasks;
    using DentalSystem.Messages.Identity;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Services;
    using MassTransit;

    public class PatientRegisteredConsumer : IConsumer<PatientRegisteredMessage>
    {
        private readonly IPatientService _patientService;

        public PatientRegisteredConsumer(IPatientService patientService)
            => _patientService = patientService;

        public async Task Consume(ConsumeContext<PatientRegisteredMessage> context)
        {
            _patientService.Add(new Patient
            {
                UserId = context.Message.ReferenceId,
            });

            await _patientService.Save();
        }
    }
}
