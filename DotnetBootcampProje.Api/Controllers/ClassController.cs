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
    public class ClassController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IClassService _classService;

        public ClassController(IMapper mapper, IClassService classService)
        {
            _classService = classService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var classes = await _classService.GetAllAsync();
            var classDtos = _mapper.Map<List<ClassDto>>(classes.ToList());
            return CreateActionResult(CustomResponseDto<List<ClassDto>>.Success(200, classDtos));
        }

        [HttpGet("{id}")]
        // Get api/team/3
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _classService.GetById(id);
            var entityDto = _mapper.Map<ClassDto>(entity);
            return CreateActionResult(CustomResponseDto<ClassDto>.Success(200, entityDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ClassDto classDto)
        {
            var entity = await _classService.AddAsync(_mapper.Map<Class>(classDto));
            var entityDto = _mapper.Map<ClassDto>(entity);
            return CreateActionResult(CustomResponseDto<ClassDto>.Success(201, entityDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClassDto classDto)
        {
            await _classService.UpdateAsync(_mapper.Map<Class>(classDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var entity = await _classService.GetById(id);
            await _classService.RemoveAsync(entity);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
