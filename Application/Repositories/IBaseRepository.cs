using Domain.Entities;

namespace Application.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
