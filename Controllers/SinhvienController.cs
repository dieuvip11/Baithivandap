using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TranHoangDieu_131;
using TranHoangDieu_131.Data;

namespace TranHoangDieu_131.Controllers
{
    public class SinhvienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinhvienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sinhvien
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sinhvien.Include(s => s.Lophoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sinhvien/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .Include(s => s.Lophoc)
                .FirstOrDefaultAsync(m => m.Masinhvien == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // GET: Sinhvien/Create
        public IActionResult Create()
        {
            ViewData["MaLop"] = new SelectList(_context.Lophoc, "MaLop", "MaLop");
            return View();
        }

        // POST: Sinhvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masinhvien,Tensinhvien,MaLop")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLop"] = new SelectList(_context.Lophoc, "MaLop", "MaLop", sinhvien.MaLop);
            return View(sinhvien);
        }

        // GET: Sinhvien/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            ViewData["MaLop"] = new SelectList(_context.Lophoc, "MaLop", "MaLop", sinhvien.MaLop);
            return View(sinhvien);
        }

        // POST: Sinhvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("Masinhvien,Tensinhvien,MaLop")] Sinhvien sinhvien)
        {
            if (id != sinhvien.Masinhvien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhvienExists(sinhvien.Masinhvien))
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
            ViewData["MaLop"] = new SelectList(_context.Lophoc, "MaLop", "MaLop", sinhvien.MaLop);
            return View(sinhvien);
        }

        // GET: Sinhvien/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .Include(s => s.Lophoc)
                .FirstOrDefaultAsync(m => m.Masinhvien == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // POST: Sinhvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var sinhvien = await _context.Sinhvien.FindAsync(id);
            if (sinhvien != null)
            {
                _context.Sinhvien.Remove(sinhvien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhvienExists(double id)
        {
            return _context.Sinhvien.Any(e => e.Masinhvien == id);
        }
    }
}
