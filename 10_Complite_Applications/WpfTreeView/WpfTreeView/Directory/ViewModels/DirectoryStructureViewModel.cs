

using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTreeView 
{ 
    /// <summary>
    /// the view model for the application main Directory view 
    /// </summary>
    public class DirectoryStructureViewModel: BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// A list of all directories on the machine 
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor 
        /// </summary>
        public DirectoryStructureViewModel()
        {
            // Get the Logical Drivers
            var children = DirectoryStructure.GetLogicalDrives();
            // create the view Models from the data 
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
        #endregion 
    }
}
