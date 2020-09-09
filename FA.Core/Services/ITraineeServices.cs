using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Services
{
   public  interface ITraineeServices : IBaseService<Trainee>
    {
        Task<bool> ExistAsync(int id);
    }
}
