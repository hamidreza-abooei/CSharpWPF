using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfTreeView
{
    
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {

        /// <summary>
        /// Get all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every Logical drive on the machine
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();

        }

        /// <summary>
        /// get the directories top-level content
        /// </summary>
        /// <param name="fullPath">the full path to the directory </param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // creat empty list
            var items = new List<DirectoryItem>();
            #region Get Folders
            // Try and get directories from the folder 
            // ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch
            {

            }
            
            #endregion
            #region Get Files
            
            // Try and get directories
            // ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file , Type = DirectoryItemType.File}));
                }
            }
            catch
            {

            }

            #endregion
            return items;
        }


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
