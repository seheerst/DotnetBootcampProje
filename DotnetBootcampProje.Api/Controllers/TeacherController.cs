using AutoMapper;
using DotnetBootcampProje.Core.Dtos;
using DotnetBootcampProje.Core.Dtos.Authentication;
using DotnetBootcampProje.Core.Models;
using DotnetBootcampProje.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBootcampProje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ITeacherService _teacherService;

        public TeacherController(IMapper mapper, ITeacherService teacherService)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var teachers = await _teacherService.GetAllAsync();
            var teacherDto = _mapper.Map<List<TeacherDto>>(teachers.ToList());
            return CreateActionResult(CustomResponseDto<List<TeacherDto>>.Success(200, teacherDto));
        }

        [HttpGet("{id}")]
        // Get api/team/3
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _teacherService.GetById(id);
            var entityDto = _mapper.Map<TeacherDto>(entity);
            return CreateActionResult(CustomResponseDto<TeacherDto>.Success(200, entityDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(TeacherDto teacherDto)
        {
            await _teacherService.UpdateAsync(_mapper.Map<Teacher>(teacherDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var entity = await _teacherService.GetById(id);
            await _teacherService.RemoveAsync(entity);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp(AuthRequestDto authDto)
        {
            var teacher = _teacherService.SignUp(authDto);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            return CreateActionResult(CustomResponseDto<TeacherDto>.Success(201, teacherDto));
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthRequestDto authDto)
        {
            var result = _teacherService.Login(authDto);
            if (result.Teacher != null)
                return CreateActionResult(CustomResponseDto<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(CustomResponseDto<AuthResponseDto>.Success(401, result));
        }

    }
}
