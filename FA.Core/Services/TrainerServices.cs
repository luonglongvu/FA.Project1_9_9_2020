using FA.Core.Model;
using FA.Core.Repository;
using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Services
{
   public  class TrainerServices : BaseService<Trainer>, ITrainerServices
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerServices(IGenericRepository<Trainer> repository, ITrainerRepository trainerRepository) : base(repository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _trainerRepository.ExistAsync(id);
        }
    }
}
