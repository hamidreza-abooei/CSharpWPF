using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using MVVMDemoDBTest.Models;

namespace MVVMDemoDBTest.Database
{
    public class SQLiteDataAccess
    {
        public static List<Employee> LoadEmployee()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                var output = cnn.Query<Employee>("select * from employee", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveEmployee(Employee ObjEmployee)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into employee (id, Name , Age) values (@id, @Name, @Age)", ObjEmployee);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
