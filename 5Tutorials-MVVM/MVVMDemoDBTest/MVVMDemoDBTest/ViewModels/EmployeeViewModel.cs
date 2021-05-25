using MVVMDemoDBTest.Commands;
using MVVMDemoDBTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemoDBTest.Views;
using System.Windows;

namespace MVVMDemoDBTest.ViewModels
{
    class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        #endregion

        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            //MessageBox.Show("I am EmployeeViewModel");
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }
        #region DisplayOperation
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }
        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>(ObjEmployeeService.GetAll());
            //EmployeeView.UpdateTest(EmployeesList.ToString());
        }
        #endregion

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee");  }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }


        #region SaveOperation
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                //MessageBox.Show("I am in save command");
                Employee newEmployee = new Employee();
                newEmployee.Id = CurrentEmployee.Id;
                newEmployee.Name = CurrentEmployee.Name;
                newEmployee.Age = CurrentEmployee.Age;
                var isSaved = ObjEmployeeService.Add(newEmployee);
                //ObjEmployeeService.
                LoadData();
                if (isSaved)
                    Message = "Employee saved";
                else
                    Message = "Save operation failed.";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
        #region SearchOperation
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }
        public void Search()
        {
            try
            {
                //MessageBox.Show("I am in search command");
                var ObjEmployee = ObjEmployeeService.Search(currentEmployee.Id);
                //MessageBox.Show("this is in Employee view Model "+ObjEmployee.ToString());
                if (ObjEmployee != null)
                {
                    //MessageBox.Show(CurrentEmployee.Name);
                    //CurrentEmployee.Name = ObjEmployee.Name;
                    //MessageBox.Show(CurrentEmployee.Name);
                    //CurrentEmployee.Age = ObjEmployee.Age;
                    CurrentEmployee = ObjEmployee;
                    Message = "Employee found.";
                }
                else
                {
                    Message = "Employee Not found";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;

            }
        }
        #endregion
        #region UpdateOperation
        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }
        public void Update()
        {
            try
            {
                var IsUpdated = ObjEmployeeService.Update(CurrentEmployee);
                if (IsUpdated)
                {
                    Message = "Employee updated";
                    LoadData();
                }
                else
                {
                    Message = "Update Operation Failed";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion
        #region DeleteOperation


        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var IsDeleted = ObjEmployeeService.Delete(currentEmployee.Id);
                if (IsDeleted)
                {
                    Message = "Employee Deleted";
                    LoadData();
                }
                else
                {
                    Message = "Delete Operation Faild";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion
    }
}
