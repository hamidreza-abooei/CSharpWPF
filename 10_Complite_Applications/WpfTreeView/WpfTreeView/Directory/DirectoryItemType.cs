using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    /// <summary>
    /// The type of directory item
    /// </summary>
    public enum DirectoryItemType
    {
        /// <summary>
        /// A logical drive
        /// </summary>
        Drive,
        /// <summary>
        /// A physical file
        /// </summary>
        File,
        /// <summary>
        /// A folder
        /// </summary>
        Folder
    }
}
