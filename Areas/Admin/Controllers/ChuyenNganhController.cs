using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB5_HUYNHHUUNGHIA.Models;

namespace LAB5_HUYNHHUUNGHIA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChuyenNganhController : Controller
    {
        private readonly OpenlibraryContext _context;

        public ChuyenNganhController(OpenlibraryContext context)
        {
            _context = context;
        }

        // GET: Admin/Chuyennganhs
        public async Task<IActionResult> Index()
        {
              return _context.Chuyennganhs != null ? 
                          View(await _context.Chuyennganhs.ToListAsync()) :
                          Problem("Entity set 'OpenlibraryContext.Chuyennganhs'  is null.");
        }

        // GET: Admin/Chuyennganhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chuyennganhs == null)
            {
                return NotFound();
            }

            var chuyennganh = await _context.Chuyennganhs
                .FirstOrDefaultAsync(m => m.MaCn == id);
            if (chuyennganh == null)
            {
                return NotFound();
            }

            return View(chuyennganh);
        }

        // GET: Admin/Chuyennganhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Chuyennganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCn,TenCn")] Chuyennganh chuyennganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuyennganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chuyennganh);
        }

        // GET: Admin/Chuyennganhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chuyennganhs == null)
            {
                return NotFound();
            }

            var chuyennganh = await _context.Chuyennganhs.FindAsync(id);
            if (chuyennganh == null)
            {
                return NotFound();
            }
            return View(chuyennganh);
        }

        // POST: Admin/Chuyennganhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCn,TenCn")] Chuyennganh chuyennganh)
        {
            if (id != chuyennganh.MaCn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuyennganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuyennganhExists(chuyennganh.MaCn))
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
            return View(chuyennganh);
        }

        // GET: Admin/Chuyennganhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chuyennganhs == null)
            {
                return NotFound();
            }

            var chuyennganh = await _context.Chuyennganhs
                .FirstOrDefaultAsync(m => m.MaCn == id);
            if (chuyennganh == null)
            {
                return NotFound();
            }

            return View(chuyennganh);
        }

        // POST: Admin/Chuyennganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chuyennganhs == null)
            {
                return Problem("Entity set 'OpenlibraryContext.Chuyennganhs'  is null.");
            }
            var chuyennganh = await _context.Chuyennganhs.FindAsync(id);
            if (chuyennganh != null)
            {
                _context.Chuyennganhs.Remove(chuyennganh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuyennganhExists(int id)
        {
          return (_context.Chuyennganhs?.Any(e => e.MaCn == id)).GetValueOrDefault();
        }
    }
}
