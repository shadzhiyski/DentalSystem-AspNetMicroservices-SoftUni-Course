namespace DentalSystem.Scheduling.Services
{
    using System;
    using System.Threading.Tasks;
    using DentalSystem.Scheduling.Data.Models;
    using DentalSystem.Services.Data;

    public interface IRoomService : IDataService<Room>
    {
        Task<Room> Find(Guid id);
    }
}