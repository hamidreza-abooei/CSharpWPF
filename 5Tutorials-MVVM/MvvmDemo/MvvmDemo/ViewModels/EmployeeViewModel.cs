using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using MvvmDemo.Models;
using MvvmDemo.Commands;
using System.Collections.ObjectModel;

namespace MvvmDemo.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
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
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
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
            EmployeesList = new ObservableCollection<Employee>( ObjEmployeeService.GetAll());
        }
        #endregion

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
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
                var isSaved = ObjEmployeeService.Add(CurrentEmployee);
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
                var ObjEmployee = ObjEmployeeService.Search(currentEmployee.Id);
                if (ObjEmployee != null)
                {
                    currentEmployee.Name = ObjEmployee.Name;
                    currentEmployee.Age = ObjEmployee.Age;
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

    }
}
