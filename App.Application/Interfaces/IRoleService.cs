﻿using App.Application.DTOs;
using System.Collections.Generic;

namespace App.Application.Interfaces
{
    public interface IRoleService
    {
        // Lấy danh sách tất cả các vai trò
        IEnumerable<RoleDto> GetAllRoles();

        // Lấy thông tin vai trò theo ID
        RoleDto GetRoleById(int roleId);

        // Tạo mới một vai trò
        void CreateRole(string roleName);

        // Cập nhật thông tin một vai trò
        void UpdateRole(int roleId, string roleName);

        // Xóa một vai trò
        void DeleteRole(int roleId);
    }
}
