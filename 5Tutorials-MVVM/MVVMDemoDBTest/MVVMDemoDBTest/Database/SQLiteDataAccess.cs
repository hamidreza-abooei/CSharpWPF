using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using MVVMDemoDBTest.Models;
using System.Data.SQLite;
using Dapper;
using MVVMDemoDBTest.Views;
using System.Windows;

namespace MVVMDemoDBTest.Database
{
    public class SQLiteDataAccess
    {
        public static List<Employee> LoadEmployee()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //MessageBox.Show(LoadConnectionString());
                cnn.Open();
                var output = cnn.Query<Employee>("select * from MyEmployee", new DynamicParameters());
                //MessageBox.Show(output.ToList().ToString());
                return output.ToList();

            }
        }
        public static void SaveEmployee(Employee ObjEmployee)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into MyEmployee (id, Name , Age) values (@id, @Name, @Age)", ObjEmployee);
            }
        }
        public static void UpdateEmployee(Employee NewEmployee)
        {
            using (IDbConnection cnn = new SQLiteConnection())
            {
                cnn.ConnectionString = LoadConnectionString();
                cnn.Open();
                using (SQLiteCommand command = new SQLiteCommand((SQLiteConnection)cnn))
                {
                    command.CommandText =
                        "update MyEmployee set Name = :name, Age = :age where ID=:id";
                    command.Parameters.Add("name", DbType.String).Value = NewEmployee.Name;
                    command.Parameters.Add("age", DbType.Int32).Value = NewEmployee.Age;
                    command.Parameters.Add("id", DbType.Int32).Value = NewEmployee.Id;
                    command.ExecuteNonQuery();
                }

            }
        }

        public static void RemoveEmployee(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection())
            {
                cnn.ConnectionString = LoadConnectionString();
                cnn.Open();
                using (SQLiteCommand command = new SQLiteCommand((SQLiteConnection)cnn))
                {
                    command.CommandText =
                        "Delete from MyEmployee where ID=:id";
                    command.Parameters.Add("id", DbType.Int32).Value = id;
                    command.ExecuteNonQuery();
                }

            }
        }

        

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
