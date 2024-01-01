using AutoMapper;
using DotnetBootcampProje.Core.Dtos;
using DotnetBootcampProje.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
