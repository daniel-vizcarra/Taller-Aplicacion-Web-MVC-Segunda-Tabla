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
    public class PromoDVsController : Controller
    {
        private readonly DanielVizcarra_EjercicioCFContext _context;

        public PromoDVsController(DanielVizcarra_EjercicioCFContext context)
        {
            _context = context;
        }

        // GET: PromoDVs
        public async Task<IActionResult> Index()
        {
            var danielVizcarra_EjercicioCFContext = _context.PromoDV.Include(p => p.Burger);
            return View(await danielVizcarra_EjercicioCFContext.ToListAsync());
        }

        // GET: PromoDVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoDV = await _context.PromoDV
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (promoDV == null)
            {
                return NotFound();
            }

            return View(promoDV);
        }

        // GET: PromoDVs/Create
        public IActionResult Create()
        {
            ViewData["BurgerID"] = new SelectList(_context.BurgerDV, "Id", "Name");
            return View();
        }

        // POST: PromoDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoID,Descripcion,FechaPromo,BurgerID")] PromoDV promoDV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoDV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurgerID"] = new SelectList(_context.BurgerDV, "Id", "Name", promoDV.BurgerID);
            return View(promoDV);
        }

        // GET: PromoDVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoDV = await _context.PromoDV.FindAsync(id);
            if (promoDV == null)
            {
                return NotFound();
            }
            ViewData["BurgerID"] = new SelectList(_context.BurgerDV, "Id", "Name", promoDV.BurgerID);
            return View(promoDV);
        }

        // POST: PromoDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoID,Descripcion,FechaPromo,BurgerID")] PromoDV promoDV)
        {
            if (id != promoDV.PromoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoDV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoDVExists(promoDV.PromoID))
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
            ViewData["BurgerID"] = new SelectList(_context.BurgerDV, "Id", "Name", promoDV.BurgerID);
            return View(promoDV);
        }

        // GET: PromoDVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoDV = await _context.PromoDV
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (promoDV == null)
            {
                return NotFound();
            }

            return View(promoDV);
        }

        // POST: PromoDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoDV = await _context.PromoDV.FindAsync(id);
            if (promoDV != null)
            {
                _context.PromoDV.Remove(promoDV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoDVExists(int id)
        {
            return _context.PromoDV.Any(e => e.PromoID == id);
        }
    }
}
