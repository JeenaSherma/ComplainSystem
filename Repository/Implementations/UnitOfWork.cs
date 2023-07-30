using ComplaintSystem.Repository.Implementations;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.DbContext;
using System.Collections;

namespace ComplaintSystem.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {   
            private bool _disposed;
            private Hashtable _repositories;
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
            {
            this._context = context;
        }
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
            {
                if (_repositories == null)
                {
                    _repositories = new Hashtable();
                }

                var type = typeof(TEntity).Name;

                if (!_repositories.ContainsKey(type))
                {
                    var repositoryType = typeof(Repository<>);
                    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                    _repositories.Add(type, repositoryInstance);
                }

                return (IRepository<TEntity>)_repositories[type];
            }

            public async Task<int> SaveChangesAsync()
            {
                return await _context.SaveChangesAsync();
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }

                    _disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
}
