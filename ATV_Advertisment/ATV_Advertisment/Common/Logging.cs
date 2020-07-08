using ATV_Advertisment.Services;

namespace ATV_Advertisment.Common
{
    public static class Logging
    {
        public static void LogBusiness(string content, int type)
        {
            BusinessLogService businessLogService = new BusinessLogService();
            businessLogService.Log(new DataService.Model.BusinessLog() {
                Content = content,
                ActorId = Session.GetId(),
                TypeId = type,
                DateAct = Utilities.GetServerDateTimeNow()
            });
        }

        public static void LogSystem(string content, int type)
        {
            SystemLogService systemLogService = new SystemLogService();
            systemLogService.Log(new DataService.Model.SystemLog()
            {
                Content = content,
                Date = Utilities.GetServerDateTimeNow(),
                TypeId = type
            });
        }
    }
}
