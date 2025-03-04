﻿using App.Domain.Repositories;

namespace App.Domain.Services
{
    public class UserDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserDomainService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        // Kiểm tra tính duy nhất của Username
        public async Task<bool> IsUsernameUnique(string username)
        {
            return await _userRepository.GetByUsernameAsync(username) == null;
        }

        // Kiểm tra sự tồn tại của Role
        public bool RoleExists(string roleName)
        {
            return _roleRepository.GetByName(roleName) != null;
        }

        // Thay đổi vai trò của người dùng
        public async void ChangeUserRole(int userId, string newRole)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            if (!RoleExists(newRole))
                throw new Exception("Role not found");

            //user.Role = newRole;
            _userRepository.Update(user);
        }
    }
}
