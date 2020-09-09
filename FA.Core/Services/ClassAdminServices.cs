using FA.Core.Model;
using FA.Core.Repository;
using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Services
{
    public class ClassAdminServices : BaseService<ClassAdmin>, IClassAdminServices
    {
        private readonly IClassAdminRepository _classAdminRepository;

        public ClassAdminServices(IGenericRepository<ClassAdmin> repository, IClassAdminRepository classAdminRepository) : base(repository)
        {
            _classAdminRepository = classAdminRepository;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _classAdminRepository.ExistAsync(id);
        }
    }
}
