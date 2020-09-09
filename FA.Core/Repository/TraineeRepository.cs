using FA.Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Repository
{
    public class TraineeRepository : GenericRepository<Trainee>, ITraineeRepository
    {
        public TraineeRepository(TMSContext context) : base(context)
        {
        }

        public bool Exist(int id)
        {
            return _context.Trainees.Any(t => t.TraineeId == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Trainees.AnyAsync(t => t.TraineeId == id);
        }
    }
}
