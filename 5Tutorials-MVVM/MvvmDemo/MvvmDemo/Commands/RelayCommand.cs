using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MvvmDemo.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action DoWork;
        public RelayCommand(Action work)
        {
            DoWork = work;
        }
        public bool CanExecute(object parameter)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            DoWork();
            //throw new NotImplementedException();
        }

        
    }
}
