﻿using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ATV_Advertisment.Services
{
    public interface IMenuItemService
    {
        List<MenuItem> GetAllByRole(string roleName);
    }

    public class MenuItemService : IMenuItemService
    {
        private readonly MenuItemRepository _menuItemRepository;
        private readonly RoleRepository _roleRepository;
        private readonly RoleHasMenuItemRepository _roleHasMenuItemRepository;

        public MenuItemService()
        {
            _menuItemRepository = new MenuItemRepository();
            _roleRepository = new RoleRepository();
            _roleHasMenuItemRepository = new RoleHasMenuItemRepository();
        }

        public List<MenuItem> GetAllByRole(string roleName)
        {
            int roleId = _roleRepository.Get(r => r.Name == roleName).FirstOrDefault().Id;
            IEnumerable<int> menuIds = _roleHasMenuItemRepository.Get(rhm => rhm.RoleId == roleId).Select(rhm => rhm.MenuItemId);

            return _menuItemRepository.GetAll().Where(m => menuIds.Contains(m.Id)).ToList();
        }
    }
}
