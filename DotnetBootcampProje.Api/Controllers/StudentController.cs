using AutoMapper;
using DotnetBootcampProje.Core.Dtos;
using DotnetBootcampProje.Core.Models;
using DotnetBootcampProje.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBootcampProje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentController(IMapper mapper, IStudentService studentService)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var students = await _studentService.GetAllAsync();
            var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());
            return CreateActionResult(CustomResponseDto<List<StudentDto>>.Success(200, studentsDto));
        }

        [HttpGet("{id}")]
        // Get api/team/3
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _studentService.GetById(id);
            var entityDto = _mapper.Map<StudentDto>(entity);
            return CreateActionResult(CustomResponseDto<StudentDto>.Success(200, entityDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(StudentDto studentDto)
        {
            var entity = await _studentService.AddAsync(_mapper.Map<Student>(studentDto));
            var entityDto = _mapper.Map<StudentDto>(entity);
            return CreateActionResult(CustomResponseDto<StudentDto>.Success(201, entityDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentDto studentDto)
        {
            await _studentService.UpdateAsync(_mapper.Map<Student>(studentDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var entity = await _studentService.GetById(id);
            await _studentService.RemoveAsync(entity);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
