namespace DentalSystem.Services.Data
{
    using System.Threading.Tasks;
    using DentalSystem.Services.Messages;
    using Microsoft.EntityFrameworkCore;

    public interface IUnitOfWork
    {
        DbContext Data { get; }

        IPublisher Publisher { get; }

        Task Save(params object[] messages);
    }
}