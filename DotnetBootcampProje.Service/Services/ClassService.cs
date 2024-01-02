using DotnetBootcampProje.Core.Models;
using DotnetBootcampProje.Core.Repositories;
using DotnetBootcampProje.Core.Services;
using DotnetBootcampProje.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Service.Services
{
    public class ClassService : GenericService<Class>, IClassService
    {
        public ClassService(IGenericRepository<Class> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
