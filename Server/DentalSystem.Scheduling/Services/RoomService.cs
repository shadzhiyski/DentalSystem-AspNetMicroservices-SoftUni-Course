namespace DentalSystem.Scheduling.Services
{
    using System;
    using System.Threading.Tasks;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;

    public class RoomService : DataService<Room>, IRoomService
    {
        public RoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Room> Find(Guid id) =>
            await UnitOfWork.Data
                .Set<Room>()
                .FirstOrDefaultAsync(r => r.Id == id);
    }
}