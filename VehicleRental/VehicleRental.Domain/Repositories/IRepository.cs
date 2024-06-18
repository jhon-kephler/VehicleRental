using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        T GetByPlate(string plate);
        T GetByDocument(string document);
        T GetByCnh(string cnh);
        Task<List<T>> FindByConditionAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression);
    }
}
