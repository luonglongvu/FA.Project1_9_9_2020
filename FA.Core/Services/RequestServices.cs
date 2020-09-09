using FA.Core.Model;
using FA.Core.Repository;
using FA.Project.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Services
{
    public class RequestServices : BaseService<Request>, IRequestServices
    {
        private readonly IRequestRepository _requestRepository;

        public RequestServices(IGenericRepository<Request> repository, IRequestRepository requestRepository) : base(repository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _requestRepository.ExistAsync(id);
        }
    }
}
