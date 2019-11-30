using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_Hocsinh.Models;

namespace QL_Hocsinh.Controllers
{
    public class MonHocsController : Controller
    {
        private readonly KetQuaHocTap _context;

        public MonHocsController(KetQuaHocTap context)
        {
            _context = context;
        }

        // GET: MonHocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MonHocs.ToListAsync());
        }

        // GET: MonHocs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // GET: MonHocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonHocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenMon,SoTinChi")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            return View(monHoc);
        }

        // POST: MonHocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,TenMon,SoTinChi")] MonHoc monHoc)
        {
            if (id != monHoc.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonHocExists(monHoc.ID))
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
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var monHoc = await _context.MonHocs.FindAsync(id);
            _context.MonHocs.Remove(monHoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonHocExists(string id)
        {
            return _context.MonHocs.Any(e => e.ID == id);
        }
    }
}
