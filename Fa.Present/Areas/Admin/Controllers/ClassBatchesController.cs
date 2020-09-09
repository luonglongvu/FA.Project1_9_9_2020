using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.Project.Model;
using FA.Core.Services;

namespace Fa.Present.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassBatchesController : Controller
    {
        private readonly TMSContext _context;
        private readonly ITraineeServices _traineeServices;

        public ClassBatchesController(TMSContext context, ITraineeServices traineeServices)
        {
            _context = context;
            _traineeServices = traineeServices;
        }

        // GET: Admin/ClassBatches
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassBatches.ToListAsync());
        }

        // GET: Admin/ClassBatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var classBatch = await _context.ClassBatches
            //    .FirstOrDefaultAsync(m => m.ClassId == id);

            //if (classBatch == null)
            //{
            //    return NotFound();
            //}

            //return View(classBatch);
            var tMSContext = _context.Trainees.Include(t => t.ClassBatch).Where(t => t.ClassBatchId == id);
            return View(await tMSContext.ToListAsync());
        }

        // GET: Admin/ClassBatches/Details/listAddtrainee
        public async Task<IActionResult> listAddtrainee(int? id)
        {
            var tMSContext = _context.Trainees.Include(t => t.ClassBatch).Where(t => t.ClassBatchId != id);
            return View(await tMSContext.ToListAsync());
        }

        // POST: Admin/ClassBatches/listAddtrainee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> listAddtrainee([Bind("FullName,DateOfBirth,Gender,PhoneNumber,Email,Account,Status,Skill,ForeignLanguage,Level,AllocationStatus")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainee);   
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Admin/ClassBatches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ClassBatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,ClassName,ClassCode,GroupMail,StartDate,EndDate,Location,DetailLocation,Status,Remarks,AuditTrail,isDeleted")] ClassBatch classBatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classBatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classBatch);
        }

        // GET: Admin/ClassBatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classBatch = await _context.ClassBatches.FindAsync(id);
            if (classBatch == null)
            {
                return NotFound();
            }
            return View(classBatch);
        }

        // POST: Admin/ClassBatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,ClassName,ClassCode,GroupMail,StartDate,EndDate,Location,DetailLocation,Status,Remarks,AuditTrail,isDeleted")] ClassBatch classBatch)
        {
            if (id != classBatch.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classBatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassBatchExists(classBatch.ClassId))
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
            return View(classBatch);
        }

        // GET: Admin/ClassBatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classBatch = await _context.ClassBatches
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (classBatch == null)
            {
                return NotFound();
            }

            return View(classBatch);
        }

        // POST: Admin/ClassBatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classBatch = await _context.ClassBatches.FindAsync(id);
            _context.ClassBatches.Remove(classBatch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/ClassBatches/DeleteTrainee
        public async Task<IActionResult> DeleteTrainee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees
                .Include(t => t.ClassBatch)
                .FirstOrDefaultAsync(m => m.TraineeId == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Admin/ClassBatches/DeleteTrainee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTrainee(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            _context.Trainees.Remove(trainee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Admin/ClassBatches/EditTrainee
        public async Task<IActionResult> EditTrainee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trainee = await _context.Trainees.FindAsync(id);
            //var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            ViewData["ClassBatchId"] = new SelectList(_context.ClassBatches, "ClassId", "AuditTrail", trainee.ClassBatchId);
            return View(trainee);
        }

        // POST: Admin/ClassBatches/EditTrainee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrainee(int id,[Bind("Account,Status,AllocationStatus,ClassBatchId")] Trainee trainee)
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
                    //_context.Update(trainee);
                    //await _context.SaveChangesAsync();
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

        private bool ClassBatchExists(int id)
        {
            return _context.ClassBatches.Any(e => e.ClassId == id);
        }
        private bool TraineeExists(int id)
        {
            return _context.Trainees.Any(e => e.TraineeId == id);
        }
    }
}
