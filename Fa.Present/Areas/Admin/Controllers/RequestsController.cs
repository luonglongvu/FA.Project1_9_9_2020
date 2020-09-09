using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.Project.Model;
using FA.Core.Services;
using System.Linq.Expressions;

namespace Fa.Present.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestsController : Controller
    {
        private readonly TMSContext _context;
        private readonly IRequestServices _requestServices;
        public RequestsController(TMSContext context,IRequestServices requestServices)
        {
            _context = context;
            _requestServices = requestServices;

        }

        // GET: Admin/Requests
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageIndex = 1, int pageSize = 10)
        {

            ViewData["CurrentPageSize"] = pageSize;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            Expression<Func<Request, bool>> filter = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = c => c.Reason.Contains(searchString);
            }

            Func<IQueryable<Request>, IOrderedQueryable<Request>> orderBy = null;

            switch (sortOrder)
            {
                case "name_desc":
                    orderBy = q => q.OrderByDescending(c => c.Reason);
                    break;
                default:
                    orderBy = q => q.OrderBy(c => c.Reason);
                    break;
            }

            var requests = await _requestServices.GetAsync(filter: filter, orderBy: orderBy, pageIndex: pageIndex ?? 1, pageSize: pageSize);

            return View(requests);

            //var tMSContext = _context.Requests.Include(r => r.Trainee);
            //return View(await tMSContext.ToListAsync());
        }

        // GET: Admin/Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var request = await _requestServices.GetByIdAsync((int)id);
            //var request = await _context.Requests
            //    .Include(r => r.Trainee)
            //    .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Admin/Requests/Create
        public IActionResult Create()
        {
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "Account");
            return View();
        }

        // POST: Admin/Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,RequestType,Reason,StartDate,EndDate,ComimmingTime,LeavingTime,ExpectedApproval,ApprovedTime,Status,AuditTrail,isDelete,TraineeId,ApproverId")] Request request)
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

        // GET: Admin/Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var flower = await _context.Flowers.FindAsync(id);
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "Account", request.TraineeId);
            return View(request);
        }

        // POST: Admin/Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,RequestType,Reason,StartDate,EndDate,ComimmingTime,LeavingTime,ExpectedApproval,ApprovedTime,Status,AuditTrail,isDelete,TraineeId,ApproverId")] Request request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _requestServices.UpdateAsync(request);
                    //_context.Update(request);
                    //await _context.SaveChangesAsync();
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

        // GET: Admin/Requests/Delete/5
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

        // POST: Admin/Requests/Delete/5
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
