using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmDemo.Models
{
    public class EmployeeService
    {
        private static List<Employee> ObjEmployeeList;
        public EmployeeService()
        {
                ObjEmployeeList = new List<Employee>()
                {
                    new Employee{Id=101 , Name = "Syed" , Age = 25}
                };


        }
        public List<Employee> GetAll()
        {
            return ObjEmployeeList;
        }

        public bool Add(Employee objNewEmployee)
        {
            // Age must be between 21 and 58
            if (objNewEmployee.Age<21 || objNewEmployee.Age > 58)
            {
                throw new ArgumentException("Invalid age limit for employee");
            }
            
            ObjEmployeeList.Add(objNewEmployee);
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

            return isDeleted;
        }

        public Employee Search(int id)
        {
            return ObjEmployeeList.FirstOrDefault(e => e.Id == id);
        }

        
    }
}
