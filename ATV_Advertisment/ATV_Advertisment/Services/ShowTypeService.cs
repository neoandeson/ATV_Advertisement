using ATV_Advertisment.Common;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IShowTypeService
    {
        ShowType GetById(int id);
        List<ShowType> GetAll();
        Dictionary<int, string> Getoptions();
        int DeleteShowType(int id);
        int AddShowType(ShowType input);
        int EditShowType(ShowType input);
    }

    public class ShowTypeService : IShowTypeService
    {
        private readonly ShowTypeRepository _ShowTypeRepository;

        public ShowTypeService()
        {
            _ShowTypeRepository = new ShowTypeRepository();
        }

        public int AddShowType(ShowType input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                //TODO: Define if seperative ShowType
                //bool isExisted = _ShowTypeRepository.Exist(t => t.Length == input.Length);
                //if (!isExisted)
                input.StatusId = CommonStatus.ACTIVE;
                input.CreateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateBy = Common.Session.GetId();
                _ShowTypeRepository.Add(input);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        /// <summary>
        /// Onyly mark as cancel 
        /// must not print on schedule
        /// optional when print report
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteShowType(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var ShowType = _ShowTypeRepository.GetById(id);
            if (ShowType != null)
            {
                ShowType.StatusId = CommonStatus.CANCEL;

                ShowType.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ShowType.LastUpdateBy = Common.Session.GetId();
                _ShowTypeRepository.Update(ShowType);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditShowType(ShowType input)
        {
            int result = CRUDStatusCode.ERROR;
            var ShowType = _ShowTypeRepository.GetById(input.Id);
            if (ShowType != null)
            {
                //TODO: Define if seperative ShowType
                //bool isExisted = _ShowTypeRepository.Exist(t => t. == input.Length);
                //if (!isExisted)
                ShowType.Type = input.Type;
                ShowType.Description = input.Description;

                ShowType.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ShowType.LastUpdateBy = Common.Session.GetId();
                _ShowTypeRepository.Update(ShowType);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<ShowType> GetAll()
        {
            return _ShowTypeRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public ShowType GetById(int id)
        {
            return _ShowTypeRepository.GetById(id);
        }

        public Dictionary<int, string> Getoptions()
        {
            var options = _ShowTypeRepository.GetAll().ToDictionary(x => x.Id, x => x.Type);
            return options;
        }
    }
}
