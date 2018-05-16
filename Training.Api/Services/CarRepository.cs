using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Api.Models;

namespace Training.Api.Services
{
    public class CarRepository : ICarRepository
    {
        private CarAPIContext _context;

        public CarRepository(CarAPIContext context)
        {
            _context = context;
        }

        public void Add(Car entity)
        {
            if (entity==null) { throw new ArgumentNullException(nameof(entity),  "Car-Entity ist null"); }
            _context.Add(entity);
        }

        public async Task<Car> FindByIdAsync(int id)
        {
            return await _context.CarSet.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.CarSet.ToListAsync();

        }

        public Task<IEnumerable<Car>> GetCarsWithDiscount()
        {
            throw new NotImplementedException();
        }

        public void Remove(Car entity)
        {
            _context.CarSet.Remove(entity);
        }

        public async Task<bool> SaveAll(Car entity)
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task SaveAll()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Car entity)
        {
            if (entity == null) return false;
            await _context.CarSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
