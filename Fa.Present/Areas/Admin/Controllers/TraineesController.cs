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
    public class TraineesController : Controller
    {
        private readonly TMSContext _context;
        private readonly ITraineeServices _traineeServices;
        public TraineesController(TMSContext context,ITraineeServices traineeServices)
        {
            _context = context;
            _traineeServices = traineeServices;
        }

        // GET: Admin/Trainees
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

            Expression<Func<Trainee, bool>> filter = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = c => c.Account.Contains(searchString);
            }

            Func<IQueryable<Trainee>, IOrderedQueryable<Trainee>> orderBy = null;

            switch (sortOrder)
            {
                case "name_desc":
                    orderBy = q => q.OrderByDescending(c => c.Account);
                    break;
                default:
                    orderBy = q => q.OrderBy(c => c.Account);
                    break;
            }

            var trainees = await _traineeServices.GetAsync(filter: filter, orderBy: orderBy, pageIndex: pageIndex ?? 1, pageSize: pageSize);

            return View(trainees);
        }

        // GET: Admin/Trainees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trainee = await _traineeServices.GetByIdAsync((int)id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Admin/Trainees/Create
        public IActionResult Create()
        {
            ViewData["ClassBatchId"] = new SelectList(_context.ClassBatches, "ClassId", "AuditTrail");
            return View();
        }

        // POST: Admin/Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraineeId,DateOfBirth,Gender,PhoneNumber,FamilyPhoneNumber,Email,ExternalEmail,Account,OnboardDate,Status,Remarks,University,Faculty,Skill,ForeignLanguage,Level,CV,AllocationStatus,AuditTrail,isDelete,ClassBatchId")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassBatchId"] = new SelectList(_context.ClassBatches, "ClassId", "AuditTrail", trainee.ClassBatchId);
            return View(trainee);
        }

        // GET: Admin/Trainees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            ViewData["ClassBatchId"] = new SelectList(_context.ClassBatches, "ClassId", "AuditTrail", trainee.ClassBatchId);
            return View(trainee);
        }

        // POST: Admin/Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraineeId,DateOfBirth,Gender,PhoneNumber,FamilyPhoneNumber,Email,ExternalEmail,Account,OnboardDate,Status,Remarks,University,Faculty,Skill,ForeignLanguage,Level,CV,AllocationStatus,AuditTrail,isDelete,ClassBatchId")] Trainee trainee)
        {
            if (id != trainee.TraineeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _traineeServices.UpdateAsync(trainee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.TraineeId))
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
            ViewData["ClassBatchId"] = new SelectList(_context.ClassBatches, "ClassId", "AuditTrail", trainee.ClassBatchId);
            return View(trainee);
        }

        // GET: Admin/Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Admin/Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            _context.Trainees.Remove(trainee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
            return _context.Trainees.Any(e => e.TraineeId == id);
        }
    }
}
