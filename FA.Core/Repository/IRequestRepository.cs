using FA.Core.Model;
using FA.Project.Model;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace FA.Core.Repository
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<bool> ExistAsync(int id);
    }
}
