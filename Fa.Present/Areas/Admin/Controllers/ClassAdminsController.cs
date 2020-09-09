using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.Project.Model;

namespace Fa.Present.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassAdminsController : Controller
    {
        private readonly TMSContext _context;

        public ClassAdminsController(TMSContext context)
        {
            _context = context;
        }

        // GET: Admin/ClassAdmins
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassAdmins.ToListAsync());
        }

        // GET: Admin/ClassAdmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classAdmin = await _context.ClassAdmins
                .FirstOrDefaultAsync(m => m.ClassAdminId == id);
            if (classAdmin == null)
            {
                return NotFound();
            }

            return View(classAdmin);
        }

        // GET: Admin/ClassAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ClassAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassAdminId,FullName,DateOfBirth,Gender,PhoneNumber,Email,Account,Status,AuditTrail,isDelete")] ClassAdmin classAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classAdmin);
        }

        // GET: Admin/ClassAdmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classAdmin = await _context.ClassAdmins.FindAsync(id);
            if (classAdmin == null)
            {
                return NotFound();
            }
            return View(classAdmin);
        }

        // POST: Admin/ClassAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassAdminId,FullName,DateOfBirth,Gender,PhoneNumber,Email,Account,Status,AuditTrail,isDelete")] ClassAdmin classAdmin)
        {
            if (id != classAdmin.ClassAdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassAdminExists(classAdmin.ClassAdminId))
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
            return View(classAdmin);
        }

        // GET: Admin/ClassAdmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classAdmin = await _context.ClassAdmins
                .FirstOrDefaultAsync(m => m.ClassAdminId == id);
            if (classAdmin == null)
            {
                return NotFound();
            }

            return View(classAdmin);
        }

        // POST: Admin/ClassAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classAdmin = await _context.ClassAdmins.FindAsync(id);
            _context.ClassAdmins.Remove(classAdmin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassAdminExists(int id)
        {
            return _context.ClassAdmins.Any(e => e.ClassAdminId == id);
        }
    }
}
