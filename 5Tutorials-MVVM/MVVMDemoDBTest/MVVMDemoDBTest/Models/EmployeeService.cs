using MVVMDemoDBTest.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDemoDBTest.Models
{
    class EmployeeService
    {

        private static List<Employee> ObjEmployeeList;
        public EmployeeService()
        {
            ObjEmployeeList = new List<Employee>();
            //{
            //    new Employee { Id = 101, Name = "syed", Age = 25 }
            //};
            ObjEmployeeList = SQLiteDataAccess.LoadEmployee();
            //MessageBox.Show("I am here");

        }
        public List<Employee> GetAll()
        {
            List<Employee> ObjEmployeeList = new List<Employee>();
            ObjEmployeeList = SQLiteDataAccess.LoadEmployee();
            return ObjEmployeeList;
        }

        public bool Add(Employee objNewEmployee)
        {
            // Age must be between 21 and 58
            if (objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
            {
                throw new ArgumentException("Invalid age limit for employee");
            }

            //ObjEmployeeList.Add(objNewEmployee);
            SQLiteDataAccess.SaveEmployee(objNewEmployee);

            return true;
        }

        public bool Update(Employee ObjEmployeeToUpdate)
        {
            bool isUpdated = false;

            for (int index = 0; index < ObjEmployeeList.Count; index++)
            {
                if (ObjEmployeeList[index].Id == ObjEmployeeToUpdate.Id)
                {
                    ObjEmployeeList[index].Name = ObjEmployeeToUpdate.Name;
                    ObjEmployeeList[index].Age = ObjEmployeeToUpdate.Age;
                    isUpdated = true;
                    break;
                }
            }
            SQLiteDataAccess.UpdateEmployee(ObjEmployeeToUpdate);
            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for (int index = 0; index < ObjEmployeeList.Count; index++)
            {
                if (ObjEmployeeList[index].Id == id)
                {
                    ObjEmployeeList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }
            SQLiteDataAccess.RemoveEmployee(id);

            return isDeleted;
        }

        public Employee Search(int id)
        {
            ObjEmployeeList = SQLiteDataAccess.LoadEmployee();
            //MessageBox.Show(ObjEmployeeList.FirstOrDefault(e => e.Id == id).ToString());
            return ObjEmployeeList.FirstOrDefault(e => e.Id == id);
        }


    }
}
