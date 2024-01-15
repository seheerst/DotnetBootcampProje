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
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public string Password { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
