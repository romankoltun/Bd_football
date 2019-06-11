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
    public class PersonalEnumsController : Controller
    {
        private readonly Context_app _context;

        public PersonalEnumsController()
        {
            _context = new Context_app();
        }

        // GET: PersonalEnums
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalEnums.ToListAsync());
        }

        // GET: PersonalEnums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalEnum = await _context.PersonalEnums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalEnum == null)
            {
                return NotFound();
            }

            return View(personalEnum);
        }

        // GET: PersonalEnums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalEnums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proffesion")] PersonalEnum personalEnum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalEnum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalEnum);
        }

        // GET: PersonalEnums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalEnum = await _context.PersonalEnums.FindAsync(id);
            if (personalEnum == null)
            {
                return NotFound();
            }
            return View(personalEnum);
        }

        // POST: PersonalEnums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proffesion")] PersonalEnum personalEnum)
        {
            if (id != personalEnum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalEnum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalEnumExists(personalEnum.Id))
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
            return View(personalEnum);
        }

        // GET: PersonalEnums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalEnum = await _context.PersonalEnums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalEnum == null)
            {
                return NotFound();
            }

            return View(personalEnum);
        }

        // POST: PersonalEnums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalEnum = await _context.PersonalEnums.FindAsync(id);
            _context.PersonalEnums.Remove(personalEnum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalEnumExists(int id)
        {
            return _context.PersonalEnums.Any(e => e.Id == id);
        }
    }
}
