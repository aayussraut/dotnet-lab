using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _11_crud_efcore.Data;
using _11_crud_efcore.Models;

namespace _11_crud_efcore.Controllers
{
    public class PhonebookModelsController : Controller
    {
        private readonly AppDbContext _context;

        public PhonebookModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PhonebookModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.PhonebookModel.ToListAsync());
        }

        // GET: PhonebookModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhonebookModel == null)
            {
                return NotFound();
            }

            var phonebookModel = await _context.PhonebookModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phonebookModel == null)
            {
                return NotFound();
            }

            return View(phonebookModel);
        }

        // GET: PhonebookModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhonebookModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Number")] PhonebookModel phonebookModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phonebookModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phonebookModel);
        }

        // GET: PhonebookModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhonebookModel == null)
            {
                return NotFound();
            }

            var phonebookModel = await _context.PhonebookModel.FindAsync(id);
            if (phonebookModel == null)
            {
                return NotFound();
            }
            return View(phonebookModel);
        }

        // POST: PhonebookModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Number")] PhonebookModel phonebookModel)
        {
            if (id != phonebookModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phonebookModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhonebookModelExists(phonebookModel.Id))
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
            return View(phonebookModel);
        }

        // GET: PhonebookModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhonebookModel == null)
            {
                return NotFound();
            }

            var phonebookModel = await _context.PhonebookModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phonebookModel == null)
            {
                return NotFound();
            }

            return View(phonebookModel);
        }

        // POST: PhonebookModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhonebookModel == null)
            {
                return Problem("Entity set 'AppDbContext.PhonebookModel'  is null.");
            }
            var phonebookModel = await _context.PhonebookModel.FindAsync(id);
            if (phonebookModel != null)
            {
                _context.PhonebookModel.Remove(phonebookModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhonebookModelExists(int id)
        {
          return _context.PhonebookModel.Any(e => e.Id == id);
        }
    }
}
