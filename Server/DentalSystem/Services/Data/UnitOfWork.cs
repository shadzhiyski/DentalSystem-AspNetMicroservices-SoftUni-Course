using System.Linq;
using System.Threading.Tasks;
using DentalSystem.Data;
using DentalSystem.Data.Models;
using DentalSystem.Services.Messages;
using Microsoft.EntityFrameworkCore;

namespace DentalSystem.Services.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext data, IPublisher publisher)
        {
            this.Data = data;
            this.Publisher = publisher;
        }

        public DbContext Data { get; }

        public IPublisher Publisher { get; }

        public async Task Save(params object[] messages)
        {
            var dataMessages = messages
                .ToDictionary(data => data, data => new Message(data));

            if (this.Data is IMessageDbContext)
            {
                foreach (var (_, message) in dataMessages)
                {
                    this.Data.Add(message);
                }
            }

            await this.Data.SaveChangesAsync();

            if (this.Data is IMessageDbContext)
            {
                foreach (var (data, message) in dataMessages)
                {
                    await this.Publisher.Publish(data);

                    message.MarkAsPublished();

                    await this.Data.SaveChangesAsync();
                }
            }
        }
    }
}