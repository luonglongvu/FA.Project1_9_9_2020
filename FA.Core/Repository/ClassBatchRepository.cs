using FA.Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Repository
{
    public class ClassBatchRepository : GenericRepository<ClassBatch>, IClassBatchRepository
    {
        public ClassBatchRepository(TMSContext context) : base(context)
        {
        }

        public bool Exist(int id)
        {
            return _context.ClassBatches.Any(t => t.ClassId == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.ClassBatches.AnyAsync(t => t.ClassId == id);
        }
    }
}
