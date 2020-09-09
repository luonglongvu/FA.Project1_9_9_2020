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
    public class Requests1Controller : Controller
    {
        private readonly TMSContext _context;

        public Requests1Controller(TMSContext context)
        {
            _context = context;
        }

        // GET: Admin/Requests1
        public async Task<IActionResult> Index()
        {
            var tMSContext = _context.Requests.Include(r => r.Trainee);
            return View(await tMSContext.ToListAsync());
        }

        // GET: Admin/Requests1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Trainee)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Admin/Requests1/Create
        public IActionResult Create()
        {
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "Account");
            return View();
        }

        // POST: Admin/Requests1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,Requesttype,Reason,StartDate,EndDate,ComimmingTime,LeavingTime,ExpectedApproval,ApprovedTime,Status,AuditTrail,isDelete,TraineeId,ApproverId")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "Account", request.TraineeId);
            return View(request);
        }

        // GET: Admin/Requests1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "Account", request.TraineeId);
            return View(request);
        }

        // POST: Admin/Requests1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,Requesttype,Reason,StartDate,EndDate,ComimmingTime,LeavingTime,ExpectedApproval,ApprovedTime,Status,AuditTrail,isDelete,TraineeId,ApproverId")] Request request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestId))
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
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "Account", request.TraineeId);
            return View(request);
        }

        // GET: Admin/Requests1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Trainee)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Admin/Requests1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestId == id);
        }
    }
}
