using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IRoleService
    {
    }

    public class RoleService : IRoleService
    {
        private readonly RoleRepository _RoleRepository;

        public RoleService()
        {
            _RoleRepository = new RoleRepository();
        }
    }
}
