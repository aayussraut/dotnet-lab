using Microsoft.AspNetCore.Mvc;
using _11_crud_efcore.Data;
using _11_crud_efcore.Models;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Index()
        {
            return View(_context.Phonebook.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhonebookModel phonebookdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phonebookdata);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phonebookdata);
        }

        // GET: PhonebookModels/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            var phonebookdata = _context.Phonebook.Find(id);
            if (phonebookdata == null)
            {
                return NotFound();
            }
            return View(phonebookdata);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PhonebookModel phonebookdata)
        {

            if (ModelState.IsValid)
            {

                _context.Phonebook.Update(phonebookdata);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(phonebookdata);
        }

        // GET: PhonebookModels/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            var phonebookModel = _context.Phonebook.Find(id);
            if (phonebookModel == null)
            {
                return NotFound();
            }

            return View(phonebookModel);
        }

        // POST: PhonebookModels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PhonebookModel phonebookdata)
        {
            _context.Phonebook.Remove(phonebookdata);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
