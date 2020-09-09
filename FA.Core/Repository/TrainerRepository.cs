using FA.Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Repository
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(TMSContext context) : base(context)
        {
        }

        public bool Exist(int id)
        {
            return _context.Trainers.Any(t => t.TrainerId == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Trainers.AnyAsync(t => t.TrainerId == id);
        }
    }
}
