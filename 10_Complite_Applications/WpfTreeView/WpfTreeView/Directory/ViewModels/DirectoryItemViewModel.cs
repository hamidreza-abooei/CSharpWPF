
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfTreeView
{
    /// <summary>
    /// A view model for each directory item 
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region public properties
        /// <summary>
        /// The type of this item 
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// the full path to the item 
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// A list of all children contained inside this item 
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// indicates if this item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        /// <summary>
        /// Indicates if the current item is expanded or not 
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0; 
            }
            set
            {
                // if the UI tels us to expand...
                if (value == true)
                    // Find all children 
                    Expand();
                // if the UI tells us to close 
                else
                    this.ClearChildren();
            }
        }
        #endregion

        #region Commands
        
        /// <summary>
        /// The command to expand this item 
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor 
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fullPath">full path of this item</param>
        /// <param name="type">The type of item </param>
        public DirectoryItemViewModel(string fullPath , DirectoryItemType type)
        {
            // create commands 
            this.ExpandCommand = new RelayCommand(Expand);

            // set path and type 
            this.FullPath = fullPath;
            this.Type = type;

            // Setup the children as needed  
            this.ClearChildren();

        }
        #endregion


        #region Helper Methodes
        /// <summary>
        /// Remove all children from the list, adding a dummy item to show the expand icon if required 
        /// </summary>
        private void ClearChildren()
        {
            // Clear items 
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            // show the expand arrow if we are not a file 
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }
        #endregion 

        /// <summary>
        /// Expands this directory and finds all children 
        /// </summary>
        private void Expand()
        {
            // We can not expand a file 
            if (this.Type == DirectoryItemType.File){
                return;
            }
            // find all children 
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>( 
                                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));

        }
    }

}
