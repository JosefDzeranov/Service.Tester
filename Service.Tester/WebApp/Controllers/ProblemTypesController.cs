using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Domain.Context;
using Service.Domain.Entities;
using Service.Domain.ExtraModels;
using WebApp.Utils;

namespace WebApp.Controllers
{
    public class ProblemTypesController : Controller
    {
        private readonly DatabaseContext _context;

        public ProblemTypesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProblemTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProblemTypes.ToListAsync());
        }

        // GET: ProblemTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemType = await _context.ProblemTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (problemType == null)
            {
                return NotFound();
            }

            return View(problemType);
        }

        // GET: ProblemTypes/Create
        public IActionResult Create()
        {
            // var names = EnumUtil.GetValues<ProblemTypes>();
            // ViewBag.Names = new SelectList(names, "Name", "FullName");
            return View();
        }

        // POST: ProblemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,FullName,Id")] ProblemType problemType)
        {
            if (ModelState.IsValid)
            {
                problemType.Id = Guid.NewGuid();
                _context.Add(problemType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problemType);
        }

        // GET: ProblemTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemType = await _context.ProblemTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (problemType == null)
            {
                return NotFound();
            }
            return View(problemType);
        }

        // POST: ProblemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,FullName,Id")] ProblemType problemType)
        {
            if (id != problemType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problemType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemTypeExists(problemType.Id))
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
            return View(problemType);
        }

        // GET: ProblemTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemType = await _context.ProblemTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (problemType == null)
            {
                return NotFound();
            }

            return View(problemType);
        }

        // POST: ProblemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var problemType = await _context.ProblemTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProblemTypes.Remove(problemType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemTypeExists(Guid id)
        {
            return _context.ProblemTypes.Any(e => e.Id == id);
        }
    }
}
