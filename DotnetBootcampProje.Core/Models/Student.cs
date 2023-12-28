using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Core.Models
{
    public class Student: BaseModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set;}
    }
}
