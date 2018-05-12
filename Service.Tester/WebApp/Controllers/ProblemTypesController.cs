using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Domain.Context;
using Service.Domain.Entities;

namespace WebApp.Controllers
{
    public class ProblemTypesController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public ProblemTypesController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: ProblemTypes
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.ProblemTypes.ToListAsync());
        }

        // GET: ProblemTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemType = await _dbContext.ProblemTypes
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
                _dbContext.Add(problemType);
                await _dbContext.SaveChangesAsync();
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

            var problemType = await _dbContext.ProblemTypes.SingleOrDefaultAsync(m => m.Id == id);
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
                    _dbContext.Update(problemType);
                    await _dbContext.SaveChangesAsync();
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

            var problemType = await _dbContext.ProblemTypes
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
            var problemType = await _dbContext.ProblemTypes.SingleOrDefaultAsync(m => m.Id == id);
            _dbContext.ProblemTypes.Remove(problemType);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool ProblemTypeExists(Guid id)
        {
            return _dbContext.ProblemTypes.Any(e => e.Id == id);
        }
    }
}
