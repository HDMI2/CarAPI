using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebApi.Models;

namespace CarWebApi.Services
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindByIdAsync(int id);

        void Add(T entity);
        void Remove(T entity);
        Task<bool> Update(T entity);

        Task<bool> SaveAll(T entity);

    }

    public interface ICarRepository: IRepository<Car>
    {
        Task<IEnumerable<Car>> GetCarsWithDiscount();
        Task SaveAll();
    }

}
