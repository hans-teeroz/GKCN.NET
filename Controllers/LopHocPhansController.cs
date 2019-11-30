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
    public class LopHocPhansController : Controller
    {
        private readonly KetQuaHocTap _context;

        public LopHocPhansController(KetQuaHocTap context)
        {
            _context = context;
        }

        // GET: LopHocPhans
        public async Task<IActionResult> Index()
        {
            var ketQuaHocTap = _context.LopHocPhans.Include(l => l.Khoa).Include(l => l.MonHoc);
            return View(await ketQuaHocTap.ToListAsync());
        }

        // GET: LopHocPhans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans
                .Include(l => l.Khoa)
                .Include(l => l.MonHoc)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Create
        public IActionResult Create()
        {
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "ID", "TenKhoa");
            ViewData["MonHocID"] = new SelectList(_context.MonHocs, "ID", "TenMon");
            return View();
        }

        // POST: LopHocPhans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NamHoc,HocKi,Mon,DiemGK,DiemCK,KhoaID,MonHocID")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "ID", "ID", lopHocPhan.KhoaID);
            ViewData["MonHocID"] = new SelectList(_context.MonHocs, "ID", "ID", lopHocPhan.MonHocID);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "ID", "ID", lopHocPhan.KhoaID);
            ViewData["MonHocID"] = new SelectList(_context.MonHocs, "ID", "ID", lopHocPhan.MonHocID);
            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,NamHoc,HocKi,Mon,DiemGK,DiemCK,KhoaID,MonHocID")] LopHocPhan lopHocPhan)
        {
            if (id != lopHocPhan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocPhanExists(lopHocPhan.ID))
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
            ViewData["KhoaID"] = new SelectList(_context.Khoas, "ID", "ID", lopHocPhan.KhoaID);
            ViewData["MonHocID"] = new SelectList(_context.MonHocs, "ID", "ID", lopHocPhan.MonHocID);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans
                .Include(l => l.Khoa)
                .Include(l => l.MonHoc)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);
            _context.LopHocPhans.Remove(lopHocPhan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocPhanExists(string id)
        {
            return _context.LopHocPhans.Any(e => e.ID == id);
        }
    }
}
