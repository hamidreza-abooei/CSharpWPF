
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Cunstructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region On Loaded
        /// <summary>
        /// when the application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get every Logical drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // Create a new item for it 
                var item = new TreeViewItem()
                {
                    // Set the header 
                    Header = drive,
                    // And the full path
                    Tag = drive

                };  

               
                // Add a dummy item
                item.Items.Add(null);

                //Listen out for item being expanded 
                item.Expanded += Folder_Expanded;

                // Add it to the main tree-view
                FolderView.Items.Add(item);
            }
        }


        #endregion

        #region Folder Expanded
        /// <summary>
        /// when a folder is expanded, find the sub folders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region initial checks
            var item = (TreeViewItem)sender;

            // if the item only contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;
            // Clear dummy data
            item.Items.Clear();

            // Get the full path
            var fullPath = (string)item.Tag;
            #endregion
            #region Get Folders

            // Create a blank list for directories
            var directories = new List<string>();
            // Try and get directories
            // ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch
            {

            }
            // for each directory...
            directories.ForEach(directoryPath =>
            {
                // Create Directory Item
                var subItem = new TreeViewItem()
                {
                    // set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    // And tag as full path
                    Tag = directoryPath
                };
                // Add dummy item se we can expand folder 
                subItem.Items.Add(null);
                //handle expanding 
                subItem.Expanded += Folder_Expanded;
                // Add this Item to the parent
                item.Items.Add(subItem);
            });
            #endregion
            #region Get Files
            // Create a blank list for directories
            var files = new List<string>();
            // Try and get directories
            // ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }
            }
            catch
            {

            }
            // for each file...
            files.ForEach(filePath =>
            {
                // Create file Item
                var subItem = new TreeViewItem()
                {
                    // set header as file name
                    Header = GetFileFolderName(filePath),
                    // And tag as full path
                    Tag = filePath
                };
                
                // Add this Item to the parent
                item.Items.Add(subItem);
            });
            #endregion
        }

        #endregion

        #region Helper
        /// <summary>
        /// find the file or folder name from a full path
        /// </summary>
        /// <param name="path">the full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // if we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            // make all slashed back slash
            var normalizedPath = path.Replace('/', '\\');
            // find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // if we dont find a backslash, return the path itself
            if (lastIndex <= -1)
                return path;

            // return the name after the last backslash
            return path.Substring(lastIndex + 1);

        }
        #endregion


    }
}
