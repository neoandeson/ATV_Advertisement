using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IRoleHasMenuItemService
    {
    }

    public class RoleHasMenuItemService : IRoleHasMenuItemService
    {
        private readonly RoleHasMenuItemRepository _RoleHasMenuItemRepository;

        public RoleHasMenuItemService()
        {
            _RoleHasMenuItemRepository = new RoleHasMenuItemRepository();
        }
    }
}
