namespace DentalSystem.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IDataService<TEntity> : IUnitOfWork
        where TEntity : class
    {
        void Add(TEntity entity);

        Task<TEntity> FindByReferenceId(Guid referenceId);
    }
}
