namespace DentalSystem.Notifications.Messages
{
    using System;
    using System.Threading.Tasks;
    using DentalSystem.Messages.Identity;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Scheduling.Services;
    using MassTransit;

    public class DentistRegisteredConsumer : IConsumer<DentistRegisteredMessage>
    {
        private readonly IDentistService _dentistService;
        private readonly IDentalTeamService _dentalTeamService;
        private readonly IRoomService _roomService;

        public DentistRegisteredConsumer(
            IDentistService dentistService,
            IDentalTeamService dentalTeamService,
            IRoomService roomService)
        {
            _dentistService = dentistService;
            _dentalTeamService = dentalTeamService;
            _roomService = roomService;
        }

        public async Task Consume(ConsumeContext<DentistRegisteredMessage> context)
        {
            var dentalTeam = await _dentalTeamService.FindByName(context.Message.DentalTeamName);

            var room = await _roomService.Find(dentalTeam?.RoomId ?? Guid.Empty);
            if (room == default)
            {
                room = new Room() { Name = $"{context.Message.DentalTeamName}_Room" };
                _roomService.Add(room);

                await _roomService.Save();
            }

            dentalTeam ??= new DentalTeam()
            {
                RoomId = room.Id,
                Name = context.Message.DentalTeamName
            };

            _dentalTeamService.Add(dentalTeam);

            await _dentistService.Save();

            var dentist = new Dentist
            {
                ReferenceId = context.Message.ReferenceId,
                TeamId = dentalTeam.Id
            };

            _dentistService.Add(dentist);

            await _dentistService.Save();
        }
    }
}