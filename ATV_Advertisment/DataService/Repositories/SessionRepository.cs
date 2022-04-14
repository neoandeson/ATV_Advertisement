using DataService.Infrastructure;
using DataService.Model;
using System.Configuration;
using System.Reflection;

namespace DataService.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {

    }
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository()
        {
        }

        public void ChangeConnectionString(string dbName)
        {
            string DBConn = "data source={0};initial catalog={1};user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework";
            DBConn = string.Format(DBConn, @"QUANGCAO01\SQLEXPRESSATV2", dbName, "sa", "Huyphong@123");

            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            ConnectionStringsSection connSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connSection.ConnectionStrings["ATVEntities"].ConnectionString = DBConn;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("AppSettings");
        }

        public void ChangeConnectionString(string enties, string dbName)
        {
            string dbConn = "data source={0};initial catalog={1};user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework";
            dbConn = string.Format(dbConn, @"QUANGCAO01\SQLEXPRESSATV2", dbName, "sa", "Huyphong@123");

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings[enties].ConnectionString = dbConn;
            config.ConnectionStrings.ConnectionStrings[enties].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
            config = null;
        }
    }
}
