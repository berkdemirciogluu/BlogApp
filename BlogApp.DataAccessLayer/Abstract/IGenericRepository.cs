using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);        
        void Add(T entity);        
        void Update(T entity);        
        void Delete(T entity);

        //Task<T> AddAsync(T entity);
        //Task<T> UpdateAsync(T entity);
        //Task<T> GetByIdAsync(int id);
        //Task<T> DeleteAsync(T entity);

    }
}
