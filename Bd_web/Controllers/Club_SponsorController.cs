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
    public class Club_SponsorController : Controller
    {
        private readonly Context_app _context;

        public Club_SponsorController()
        {
            _context = new Context_app();
        }

        // GET: Club_Sponsor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Club_Sponsors.ToListAsync());
        }

        // GET: Club_Sponsor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club_Sponsor = await _context.Club_Sponsors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club_Sponsor == null)
            {
                return NotFound();
            }

            return View(club_Sponsor);
        }

        // GET: Club_Sponsor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Club_Sponsor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Club_Sponsor club_Sponsor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(club_Sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(club_Sponsor);
        }

        // GET: Club_Sponsor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club_Sponsor = await _context.Club_Sponsors.FindAsync(id);
            if (club_Sponsor == null)
            {
                return NotFound();
            }
            return View(club_Sponsor);
        }

        // POST: Club_Sponsor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Club_Sponsor club_Sponsor)
        {
            if (id != club_Sponsor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(club_Sponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Club_SponsorExists(club_Sponsor.Id))
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
            return View(club_Sponsor);
        }

        // GET: Club_Sponsor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club_Sponsor = await _context.Club_Sponsors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club_Sponsor == null)
            {
                return NotFound();
            }

            return View(club_Sponsor);
        }

        // POST: Club_Sponsor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var club_Sponsor = await _context.Club_Sponsors.FindAsync(id);
            _context.Club_Sponsors.Remove(club_Sponsor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Club_SponsorExists(int id)
        {
            return _context.Club_Sponsors.Any(e => e.Id == id);
        }
    }
}
