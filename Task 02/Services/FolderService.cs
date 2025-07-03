using ClassLibrary.Services.Interfaces;
using ClassLibrary.Utilities;
using System.IO;

namespace ClassLibrary.Services
{
    /// <summary>
    /// Provides operations for managing folders, including creation, deletion, and existence checking.
    /// </summary>
    public class FolderService : IFolderService
    {
        /// <summary>
        /// Creates a directory at the specified path if it does not exist.
        /// </summary>
        /// <param name="path">The path where the directory should be created.</param>
        /// <returns>A <see cref="DirectoryInfo"/> representing the created or existing directory.</returns>
        public DirectoryInfo Create(string path)
        {
            Guard.NotNull(path, nameof(path));
            Guard.NotEmpty(path, nameof(path));

            return Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Attempts to delete the directory at the specified path.
        /// </summary>
        /// <param name="path">The path of the directory to delete.</param>
        /// <param name="recursive">Whether to delete subdirectories and files.</param>
        /// <returns><c>true</c> if the directory was deleted; otherwise, <c>false</c>.</returns>
        public bool TryDelete(string path, bool recursive = true)
        {
            if (!Exists(path)) return false;

            Directory.Delete(path, recursive);
            return true;
        }

        /// <summary>
        /// Determines whether a directory exists at the specified path.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns><c>true</c> if the directory exists; otherwise, <c>false</c>.</returns>
        public bool Exists(string path)
        {
            Guard.NotNull(path, nameof(path));
            Guard.NotEmpty(path, nameof(path));

            return Directory.Exists(path);
        }
    }
}