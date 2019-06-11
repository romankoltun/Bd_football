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
    public class СostsController : Controller
    {
        private readonly Context_app _context;

        public СostsController()
        {
            _context = new Context_app();
        }

        // GET: Сosts
        public async Task<IActionResult> Index()
        {
            var context_app = _context.Costs_s.Include(с => с.ShopeType);
            return View(await context_app.ToListAsync());
        }
        public async Task<IActionResult> SortByDate()
        {
            var res = await _context.Costs_s.Include(c => c.ShopeType).OrderBy(c => c.Date).ToListAsync();
            return View("Index",res);
        }
        public ActionResult WithDate(DateTime date1, DateTime date2)
        {
            var el = _context.Costs_s.Include(с => с.ShopeType).Where(p=> p.Date > date1 && p.Date < date2);
            return View("Index", el);
        }
        public async Task<IActionResult> Salary()
        {
            var context_app = _context.Costs_s.Include(p => p.ShopeType).Where(p => p.ShopeTypeId == 3);
            return View(await context_app.ToListAsync());
        }
        public ActionResult WithDateSalary(DateTime date1, DateTime date2)
        {
            var el = _context.Costs_s.Include(c => c.ShopeType).Where(p => p.Date > date1 && p.Date < date2 && p.ShopeTypeId == 3);
            return View("Transfer", el);
        }
        // GET: Сosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var сosts = await _context.Costs_s
                .Include(с => с.ShopeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сosts == null)
            {
                return NotFound();
            }

            return View(сosts);
        }

        // GET: Сosts/Create
        public IActionResult Create()
        {
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Type");
            return View();
        }

        // POST: Сosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_C,ShopeTypeId,Money_C,Date")] Сosts costs)
        {
            if (ModelState.IsValid)
            {

                _context.Add(costs);

                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Name", costs.ShopeTypeId);
            return View(costs);
        }
        struct Pair
        {
            public int Id;
            public string Name;
            public Pair(int a, string b)
            {
                Id = a;
                Name = b;

            }
        }
       

        // GET: Сosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var сosts = await _context.Costs_s.FindAsync(id);
            if (сosts == null)
            {
                return NotFound();
            }
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Id", сosts.ShopeTypeId);
            return View(сosts);
        }

        // POST: Сosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_C,ShopeTypeId,Money_C,Date")] Сosts сosts)
        {
            if (id != сosts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(сosts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!СostsExists(сosts.Id))
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
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Id", сosts.ShopeTypeId);
            return View(сosts);
        }

        // GET: Сosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var сosts = await _context.Costs_s
                .Include(с => с.ShopeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сosts == null)
            {
                return NotFound();
            }

            return View(сosts);
        }

        // POST: Сosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var сosts = await _context.Costs_s.FindAsync(id);
            _context.Costs_s.Remove(сosts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool СostsExists(int id)
        {
            return _context.Costs_s.Any(e => e.Id == id);
        }
    }
}
