using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Core.Models
{
    public class Class: BaseModel
    {
        public string Name { get; set; }
        public ICollection<Teacher> Teacher { get; set; }
    }
}
