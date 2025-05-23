﻿using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using DAL.Interface;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComputerDTO comingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _computerService.AddAsync(comingDto);
            if(result)
                return Ok("Компьютер успешно добавлен");
            return BadRequest("Не удалось добавить компьютер");         
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var computers = await _computerService.GetAllWithComponentsStatusPendingAsync();
                return Ok(computers);
            }
            catch
            { 
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpGet("confirmed")]
        public async Task<IActionResult> GetAllWithStatusConfirmed()
        {
            try
            {
                var computers = await _computerService.GetAllWithComponentsStatusConfirmedAsync();
                return Ok(computers);
            }
            catch
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _computerService.DeleteAsync(id);
                if (result)
                    return NoContent();

                return BadRequest("Не удалось удалить компьютер");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> ConfirmComputer(int id, [FromBody] ConfirmComputerRequest request)
        {
            try
            {
                if (request == null || request.ComingId <= 0)
                {
                    return BadRequest("Необходимо указать корректный ID прихода");
                }

                var result = await _computerService.ConfirmComputer(id, request.ComingId);

                if (!result)
                {
                    return BadRequest("Ошибка подтверждения компьютера");
                }

                return Ok("Компьютер успешно подтвержден и привязан к приходу");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера", Details = ex.Message });
            }
        }
    }
}
