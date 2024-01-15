using DotnetBootcampProje.Core.Models;
using DotnetBootcampProje.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Repository.Repositories
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(AppDbContext context) : base(context)
        {
        }
    }
}
