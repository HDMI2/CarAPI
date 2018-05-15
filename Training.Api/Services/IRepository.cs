using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Api.Models;

namespace Training.Api.Services
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindByIdAsync(int id);

        void Add(T entity);
        void Remove(T entity);

        Task<bool> SavaAll(T entity);

    }

    public interface ICarRepository: IRepository<Car>
    {
        Task<IEnumerable<Car>> GetCarsWithDiscount();

    }

}
