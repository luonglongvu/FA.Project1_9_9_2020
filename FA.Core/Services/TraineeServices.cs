using FA.Core.Model;
using FA.Core.Repository;
using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Services
{
   public  class TraineeServices : BaseService<Trainee>, ITraineeServices
    {
        private readonly ITraineeRepository _traineeRepository;

        public TraineeServices(IGenericRepository<Trainee> repository, ITraineeRepository traineeRepository) : base(repository)
        {
            _traineeRepository = traineeRepository;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _traineeRepository.ExistAsync(id);
        }
    }
}
