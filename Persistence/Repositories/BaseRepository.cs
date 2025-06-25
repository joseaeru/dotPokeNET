using Persistence.Context;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        protected readonly DotPokeNETContext Context;

        public BaseRepository(DotPokeNETContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            Context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
