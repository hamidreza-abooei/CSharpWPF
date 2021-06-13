

using System.ComponentModel;

namespace WpfTreeView
{
    /// <summary>
    /// A base View Model that fires property changed events as needed 
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that is fired with any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }

}
