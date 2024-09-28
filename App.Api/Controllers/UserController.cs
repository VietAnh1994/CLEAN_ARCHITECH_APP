﻿using Microsoft.AspNetCore.Mvc;
using App.Application.Interfaces;   // Sử dụng các interface từ Application layer
using App.Application.DTOs;        // Sử dụng các Data Transfer Object từ Application layer
using ApiLoginRequest = App.Api.Models.LoginRequest; // Alias cho LoginRequest từ App.Api.Models
using App.Api.Models; // Alias cho LoginRequest từ App.Api.Models
using Microsoft.AspNetCore.Identity.Data; // Đảm bảo không dùng tên LoginRequest từ Microsoft.AspNetCore.Identity.Data
using Microsoft.AspNetCore.Authorization;
namespace App.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        // Inject UserService vào Controller
        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }


        // Lấy thông tin người dùng theo Id
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound(new { Message = "User not found" });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // Cập nhật thông tin người dùng
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            try
            {
                var userDto = new UserDto
                {
                    FullName = request.FullName,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                };

                _userService.UpdateUser(id, userDto);
                return Ok(new { Message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // Xóa người dùng theo Id
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok(new { Message = "User deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        
    }
}
