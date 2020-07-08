using ATV_Advertisment.Common;
using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IUserService
    {
        User GetLogin(string username, string password);
        void UpdateLastLogin(string username);
        bool ChangePassword(int id, string username, string newPassword);
        Dictionary<int, string> Getoptions();
        bool CheckExistUserName(string username);
        bool CreateUser(string username, string fullName);
    }

    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
        }

        public bool ChangePassword(int id, string username, string newPassword)
        {
            bool result = false;
            var user = _userRepository.Get(u => u.Username == username).FirstOrDefault();
            if(user != null)
            {
                HashHelper hashHelper = new HashHelper();
                user.Password = hashHelper.HashPassword(newPassword);
                user.LastUpdateDate = Utilities.GetServerDateTimeNow();
                user.LastUpdateBy = id;
                _userRepository.Update(user);
                result = true;
            }

            return result;
        }

        public bool CheckExistUserName(string username)
        {
            bool result = false;
            var user = _userRepository.Get(u => u.Username == username).FirstOrDefault();
            if(user != null)
            {
                result = true;
            }

            return result;
        }

        public bool CreateUser(string username, string fullName)
        {
            bool result = false;
            HashHelper hashHelper = new HashHelper();
            string password = hashHelper.HashPassword("1234");
            Role role = _roleRepository.Get(r => r.Name == "staff").FirstOrDefault();
            if(role != null)
            {
                User user = new User()
                {
                    Name = fullName,
                    Code = fullName.Substring(0, 4),
                    CreateDate = Utilities.GetServerDateTimeNow(),
                    LastUpdateBy = Common.Session.GetId(),
                    Password = password,
                    StatusId = Constants.CommonStatus.ACTIVE,
                    RoleId = role.Id,
                    LastUpdateDate = Utilities.GetServerDateTimeNow(),
                    Username = username
                };

                _userRepository.Add(user);
                result = true;
            }
            return result;
        }

        public User GetLogin(string username, string password)
        {
            HashHelper hashHelper = new HashHelper();
            return _userRepository.GetAll()
                .Where(u => u.Username == username &&
                            u.StatusId == CommonStatus.ACTIVE &&
                            hashHelper.VerifyHashedPassword(u.Password, password))
                .FirstOrDefault();
        }

        public Dictionary<int, string> Getoptions()
        {
            var options = _userRepository.GetAll().ToDictionary(x => x.Id, x => x.Username);
            return options;
        }

        public void UpdateLastLogin(string username)
        {
            _userRepository.Get(u => u.Username == username).FirstOrDefault()
                .LastLoginTime = DateTime.Now;
        }
    }
}
