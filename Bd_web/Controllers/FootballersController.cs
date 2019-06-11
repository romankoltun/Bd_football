using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bd_web;
using Bd_web.Models;

namespace Bd_web.Controllers
{
    public class FootballersController : Controller
    {
        private readonly Context_app _context;

        public FootballersController()
        {
            _context = new Context_app();
        }

        // GET: Footballers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Footballers.ToListAsync());
        }

        // GET: Footballers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballer == null)
            {
                return NotFound();
            }

            return View(footballer);
        }

        // GET: Footballers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Footballers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amplya")] Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footballer);
        }

        // GET: Footballers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballers.FindAsync(id);
            if (footballer == null)
            {
                return NotFound();
            }
            return View(footballer);
        }

        // POST: Footballers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amplya")] Footballer footballer)
        {
            if (id != footballer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballerExists(footballer.Id))
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
            return View(footballer);
        }

        // GET: Footballers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballer == null)
            {
                return NotFound();
            }

            return View(footballer);
        }

        // POST: Footballers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            _context.Footballers.Remove(footballer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballerExists(int id)
        {
            return _context.Footballers.Any(e => e.Id == id);
        }
    }
}
