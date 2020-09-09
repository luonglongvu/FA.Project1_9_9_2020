using FA.Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Repository
{
    public class ClassAdminRepository : GenericRepository<ClassAdmin>, IClassAdminRepository
    {
        public ClassAdminRepository(TMSContext context) : base(context)
        {
        }

        public bool Exist(int id)
        {
            return _context.ClassAdmins.Any(t => t.ClassAdminId == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.ClassAdmins.AnyAsync(t => t.ClassAdminId == id);
        }
    }
}
