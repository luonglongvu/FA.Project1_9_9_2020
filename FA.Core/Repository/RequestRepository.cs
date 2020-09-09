using FA.Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(TMSContext context) : base(context)
        {
        }

        public bool Exist(int id)
        {
            return _context.Requests.Any(t => t.RequestId == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Requests.AnyAsync(t => t.RequestId == id);
        }
    }
}
