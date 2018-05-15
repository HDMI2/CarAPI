using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ViewComponents
{
    public class CarsViewComponent: ViewComponent
    {
        private CarRentalDBContext _ctx;

        public CarsViewComponent(CarRentalDBContext ctx)
        {
            this._ctx = ctx;
            if (_ctx.CarSet.Count() == 0)
            {
                _ctx.CarSet.Add(new Car { Id = 1, BrandName = "DMC", ModelName = "Delorian", YearOfConstruction = 1975 });
                _ctx.SaveChanges();
            }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View( await _ctx.CarSet.ToListAsync());
        }
    }
}
