namespace DentalSystem.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using DentalSystem.Data;
    using DentalSystem.Data.Models;
    using Messages;
    using Microsoft.EntityFrameworkCore;

    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : PublicEntity
    {
        protected DataService(DbContext data, IPublisher publisher)
        {
            this.Data = data;
            this.Publisher = publisher;
        }

        protected DbContext Data { get; }

        protected IPublisher Publisher { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public void Add(TEntity entity)
            => this.Data.Add(entity);

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

        public async Task<TEntity> FindByReferenceId(Guid referenceId)
        {
            return await this.Data.Set<TEntity>().FirstOrDefaultAsync(e => e.ReferenceId == referenceId);
        }
    }
}
