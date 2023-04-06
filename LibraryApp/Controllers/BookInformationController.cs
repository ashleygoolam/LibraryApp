using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class BookInformationController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookInformationController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BookInformation
        public async Task<IActionResult> Index()
        {
              return _context.BookInformation != null ? 
                          View(await _context.BookInformation.ToListAsync()) :
                          Problem("Entity set 'LibraryDbContext.BookInformation'  is null.");
        }

        // GET: BookInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookInformation == null)
            {
                return NotFound();
            }

            var bookInformationEntity = await _context.BookInformation
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookInformationEntity == null)
            {
                return NotFound();
            }

            return View(bookInformationEntity);
        }

        // GET: BookInformation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Author,Publisher,Type,CurrentAmount,TotalAmount,Description,DateCreated")] BookInformationEntity bookInformationEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookInformationEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookInformationEntity);
        }

        // GET: BookInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookInformation == null)
            {
                return NotFound();
            }

            var bookInformationEntity = await _context.BookInformation.FindAsync(id);
            if (bookInformationEntity == null)
            {
                return NotFound();
            }
            return View(bookInformationEntity);
        }

        // POST: BookInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Author,Publisher,Type,CurrentAmount,TotalAmount,Description,DateCreated")] BookInformationEntity bookInformationEntity)
        {
            if (id != bookInformationEntity.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookInformationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookInformationEntityExists(bookInformationEntity.BookId))
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
            return View(bookInformationEntity);
        }

        // GET: BookInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookInformation == null)
            {
                return NotFound();
            }

            var bookInformationEntity = await _context.BookInformation
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookInformationEntity == null)
            {
                return NotFound();
            }

            return View(bookInformationEntity);
        }

        // POST: BookInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookInformation == null)
            {
                return Problem("Entity set 'LibraryDbContext.BookInformation'  is null.");
            }
            var bookInformationEntity = await _context.BookInformation.FindAsync(id);
            if (bookInformationEntity != null)
            {
                _context.BookInformation.Remove(bookInformationEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookInformationEntityExists(int id)
        {
          return (_context.BookInformation?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
