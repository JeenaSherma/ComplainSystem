using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintSystem.Repository.Interfaces
{

    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
       //Task<TEntity> GetQRInfoByMunicipalityId(int MunicipalityId);

    }

}
