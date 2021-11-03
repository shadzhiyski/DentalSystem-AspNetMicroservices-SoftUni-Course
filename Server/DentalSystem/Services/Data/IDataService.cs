namespace DentalSystem.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IDataService<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        Task Save(params object[] messages);

        Task<TEntity> FindByReferenceId(Guid referenceId);
    }
}
