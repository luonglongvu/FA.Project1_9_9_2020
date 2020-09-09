using FA.Core.Model;
using FA.Core.Repository;
using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Services
{
    public class ClassBatchServices : BaseService<ClassBatch>, IClassBatchServices
    {
        private readonly IClassBatchRepository _classBatchRepository;

        public ClassBatchServices(IGenericRepository<ClassBatch> repository, IClassBatchRepository classBatchRepository) : base(repository)
        {
            _classBatchRepository = classBatchRepository;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _classBatchRepository.ExistAsync(id);
        }
    }
}
