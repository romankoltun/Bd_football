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
    public class ProfitsController : Controller
    {
        private readonly Context_app _context;

        public ProfitsController()
        {
            _context = new Context_app();
        }
        public IActionResult Ticket()
        {
            var match = _context.Matches.ToList()[0];
            string hh = match.Ticet_string;
            string[] s1 = hh.Split(';');
            string[] s2 = s1[1].Split('.');
         
            ViewBag.Ticket = s2;
            ViewBag.Match = _context.Matches;

            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Type");
            ViewData["Matchs"] = new SelectList(_context.Matches, "Id", "Name_M");
            ViewBag.sector = 0;
            ViewBag.SelectMatch = 0;
            return View();
        }
        //[HttpPost]
        //public IActionResult Sponsor( Profit profit)
        //{
        //    profit.Id==4
        //    return View();
        //}
        public async Task<IActionResult> Sponsor()
        {
            var context_app = _context.Profits.Include(p => p.ShopeType).Where(p => p.ShopeTypeId==4);
            return View(await context_app.ToListAsync());
        }
        public async Task<IActionResult> Transfer()
        {
            var context_app = _context.Profits.Include(p => p.ShopeType).Where(p => p.ShopeTypeId == 5);
            return View(await context_app.ToListAsync());
        }
        public async Task<IActionResult> Ticketz()
        {
            var context_app = _context.Profits.Include(p => p.ShopeType).Where(p => p.ShopeTypeId == 1);
            return View(await context_app.ToListAsync());
        }

        [HttpPost]
        public IActionResult Ticket(int matchId, string sector)
        {
            var match = _context.Matches.First(p => p.Id ==matchId);
            string hh = match.Ticet_string;
            string[] s1 = hh.Split(';');
            string[] s2 = s1[int.Parse(sector)-1].Split('.');

            ViewBag.Ticket = s2;
            ViewBag.Match = _context.Matches.ToList() ;
            ViewBag.sector = sector;
            ViewBag.SelectMatch = matchId;
            ViewBag.SelectMatchName = match.Name_M;
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Type");
            ViewData["Matchs"] = new SelectList(_context.Matches, "Id", "Name_M");

            return View();
        }

        public IActionResult CreateTicket()
        {

            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Type");
            ViewData["Match"] = new SelectList(_context.Matches, "Id", "Name_M");


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTicket([Bind("Id,Name_P,ShopeTypeId,Money_p,Date")] Profit profit,string sector,string row,string seat,string stringMatchId)
        {
            if (ModelState.IsValid)
            {
                int MatchId = int.Parse(stringMatchId);
                _context.Add(profit);

                await _context.SaveChangesAsync();
                if (profit.ShopeTypeId == 1)
                {
                    int Sector = int.Parse(sector);
                    var match = _context.Matches.First(p => p.Id == MatchId);
                    string s = match.Ticet_string;
                    string[] s1 = s.Split(';');
                    string[] ss = s1[0].Split('.');

                    string[] s2 = s1[Sector - 1].Split('.');
                    int i = (int.Parse(seat));
                    string newStr = "1";

                    s2[int.Parse(row)-1] = s2[0].Substring(0, i-1) + newStr + s2[0].Substring(i, s2[0].Length - i);

                    s1[Sector - 1] = string.Join('.', s2);
                    string jj = string.Join(';', s1);
                    match.Ticet_string = jj;
                    _context.Update(match);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Name", profit.ShopeTypeId);
            return View(profit);
        }
        // GET: Profits
        public async Task<IActionResult> Index()
        {
            var context_app = _context.Profits.Include(p => p.ShopeType).OrderByDescending(p=>p.Id);
            ViewBag.Sum = Money();
            return View(await context_app.ToListAsync());
        }
        public async Task<IActionResult> SortByDate()
        {
            var res = await _context.Profits.Include(c => c.ShopeType).OrderBy(c => c.Date).ToListAsync();
            return View("Index", res);
        }
        public double Money()
        {
            var profits = _context.Profits.ToList();
            var costs = _context.Costs_s.ToList();
            double Sum = 0;
            foreach (var el in profits)
            {
                Sum += el.Money_p;
            }
            foreach (var el in costs)
            {
                Sum -= el.Money_C;
            }
            return Sum;
        }
        //public ActionResult WithDate(DateTime date1, DateTime date2)
        //{
        //    var el = _context.Profits.Include(c => c.ShopeType).Where(p => p.Date > date1 && p.Date < date2);
        //    return View("Index", el);
        //}

        public ActionResult WithDateSponsor(DateTime date1, DateTime date2)
        {
            var el = _context.Profits.Include(c => c.ShopeType).Where(p => p.Date > date1 && p.Date < date2 && p.ShopeTypeId==4);
            return View("Sponsor", el);
        }
        public ActionResult WithDateTransfer(DateTime date1, DateTime date2)
        {
            var el = _context.Profits.Include(c => c.ShopeType).Where(p => p.Date > date1 && p.Date < date2 && p.ShopeTypeId == 5);
            return View("Transfer", el);
        }
        public ActionResult WithDateTicketz(DateTime date1, DateTime date2)
        {
            var el = _context.Profits.Include(c => c.ShopeType).Where(p => p.Date > date1 && p.Date < date2 && p.ShopeTypeId == 1);
            return View("Ticketz", el);
        }

        // GET: Profits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profit = await _context.Profits
                .Include(p => p.ShopeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profit == null)
            {
                return NotFound();
            }

            return View(profit);
        }

        // GET: Profits/Create
        public IActionResult Create()
        {
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Type");
            return View();
        }

        // POST: Profits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_P,ShopeTypeId,Money_p,Date")] Profit profit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Id", profit.ShopeTypeId);
            return View(profit);
        }

        // GET: Profits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profit = await _context.Profits.FindAsync(id);
            if (profit == null)
            {
                return NotFound();
            }
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Id", profit.ShopeTypeId);
            return View(profit);
        }

        // POST: Profits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_P,ShopeTypeId,Money_p,Date")] Profit profit)
        {
            if (id != profit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfitExists(profit.Id))
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
            ViewData["ShopeTypeId"] = new SelectList(_context.Shops, "Id", "Id", profit.ShopeTypeId);
            return View(profit);
        }

        // GET: Profits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profit = await _context.Profits
                .Include(p => p.ShopeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profit == null)
            {
                return NotFound();
            }

            return View(profit);
        }

        // POST: Profits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profit = await _context.Profits.FindAsync(id);
            _context.Profits.Remove(profit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfitExists(int id)
        {
            return _context.Profits.Any(e => e.Id == id);
        }
    }
}
