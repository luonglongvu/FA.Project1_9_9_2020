using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Services
{
    public interface IClassAdminServices : IBaseService<ClassAdmin>
    {
        Task<bool> ExistAsync(int id);
    }
}
