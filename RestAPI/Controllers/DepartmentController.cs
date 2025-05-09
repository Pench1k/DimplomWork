using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateDto departmentCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var departmentDto = new DepartmentDTO
            {
                Name =  departmentCreateDto.Name,
                DeanOfficeId = departmentCreateDto.DeanOfficeId,
            };

            var createdDepartment = await _departmentService.AddAsync(departmentDto);
            if (!createdDepartment)
                return BadRequest("Не удалось добавить запись.");
            return Ok("Запись добавлена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new DepartmentDTO
                {
                    Id = id,
                    Name = updateModel.Name,
                    DeanOfficeId = updateModel.DeanOfficeId,
                };

                var result = await _departmentService.UpdateAsync(dto);
                if (!result)
                    return BadRequest("Не удалось обновить запись.");

                return Ok("Запись обновлена");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ошибка при обновлении записи.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }
    }
}
