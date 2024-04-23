namespace TestAuto.Infrastructure.Services.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateEntity(TEntity entity);
        Task<TEntity> GetEntity(int id);
        Task<IEnumerable<TEntity>> GetAllEntity();
        Task UpdateEntity(TEntity entity);
        Task DeleteEntity(int id);
    }
}
