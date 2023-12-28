using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Core.Models
{
    public class Teacher: BaseModel
    {
        public string Name { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<Student> Student { get; set; }

    }
}
