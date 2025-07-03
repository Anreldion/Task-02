using System.IO;

namespace ClassLibrary.Services.Interfaces
{
    /// <summary>
    /// Provides operations for working with directories.
    /// </summary>
    public interface IFolderService
    {
        /// <summary>
        /// Checks if a directory exists at the given path.
        /// </summary>
        bool Exists(string path);

        /// <summary>
        /// Creates a directory at the given path. Returns the DirectoryInfo object.
        /// </summary>
        DirectoryInfo Create(string path);

        /// <summary>
        /// Attempts to delete the directory at the given path.
        /// </summary>
        bool TryDelete(string path, bool recursive = true);
    }

}
