using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarApiDBFirst.Models;

namespace CarApiDBFirst.Controllers
{
    public class CarSetsController : Controller
    {
        private readonly CarAPIContext _context;

        public CarSetsController(CarAPIContext context)
        {
            _context = context;
        }

        // GET: CarSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarSet.ToListAsync());
        }

        // GET: CarSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carSet = await _context.CarSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carSet == null)
            {
                return NotFound();
            }

            return View(carSet);
        }

        // GET: CarSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandName,ModelName,YearOfConstruction,Idnummer")] CarSet carSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carSet);
        }

        // GET: CarSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carSet = await _context.CarSet.FindAsync(id);
            if (carSet == null)
            {
                return NotFound();
            }
            return View(carSet);
        }

        // POST: CarSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandName,ModelName,YearOfConstruction,Idnummer")] CarSet carSet)
        {
            if (id != carSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarSetExists(carSet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carSet);
        }

        // GET: CarSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carSet = await _context.CarSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carSet == null)
            {
                return NotFound();
            }

            return View(carSet);
        }

        // POST: CarSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carSet = await _context.CarSet.FindAsync(id);
            _context.CarSet.Remove(carSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarSetExists(int id)
        {
            return _context.CarSet.Any(e => e.Id == id);
        }
    }
}
