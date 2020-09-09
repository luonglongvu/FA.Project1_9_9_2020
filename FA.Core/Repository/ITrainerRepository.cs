using FA.Core.Model;
using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Repository
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        Task<bool> ExistAsync(int id);
    }
}
