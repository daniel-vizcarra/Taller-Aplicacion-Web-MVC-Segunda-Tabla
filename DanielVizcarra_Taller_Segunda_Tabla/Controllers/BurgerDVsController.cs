using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanielVizcarra_EjercicioCF.Data;
using DanielVizcarra_EjercicioCF.Models;

namespace DanielVizcarra_EjercicioCF.Controllers
{
    public class BurgerDVsController : Controller
    {
        private readonly DanielVizcarra_EjercicioCFContext _context;

        public BurgerDVsController(DanielVizcarra_EjercicioCFContext context)
        {
            _context = context;
        }

        // GET: BurgerDVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BurgerDV.ToListAsync());
        }

        // GET: BurgerDVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burgerDV = await _context.BurgerDV
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burgerDV == null)
            {
                return NotFound();
            }

            return View(burgerDV);
        }

        // GET: BurgerDVs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BurgerDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,WithCheese,Precio")] BurgerDV burgerDV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burgerDV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burgerDV);
        }

        // GET: BurgerDVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burgerDV = await _context.BurgerDV.FindAsync(id);
            if (burgerDV == null)
            {
                return NotFound();
            }
            return View(burgerDV);
        }

        // POST: BurgerDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio")] BurgerDV burgerDV)
        {
            if (id != burgerDV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burgerDV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurgerDVExists(burgerDV.Id))
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
            return View(burgerDV);
        }

        // GET: BurgerDVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burgerDV = await _context.BurgerDV
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burgerDV == null)
            {
                return NotFound();
            }

            return View(burgerDV);
        }

        // POST: BurgerDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burgerDV = await _context.BurgerDV.FindAsync(id);
            if (burgerDV != null)
            {
                _context.BurgerDV.Remove(burgerDV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurgerDVExists(int id)
        {
            return _context.BurgerDV.Any(e => e.Id == id);
        }
    }
}
