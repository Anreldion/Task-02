using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Services;
using ProductManager.Core.Services.Interfaces;
using System;
using System.IO;

namespace ProductManager.Tests.Services
{
    [TestClass]
    public class FolderServiceTests
    {
        private IFolderService _service;
        private string _tempDir;

        [TestInitialize]
        public void SetUp()
        {
            _service = new FolderService();
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists(_tempDir))
                Directory.Delete(_tempDir, recursive: true);
        }

        [TestMethod]
        public void Create_CreatesDirectory_WhenNotExists()
        {
            // Act
            _service.Create(_tempDir);

            // Assert
            Assert.IsTrue(_service.Exists(_tempDir));
        }

        [TestMethod]
        public void Create_Throws_WhenPathIsNullOrEmpty()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _service.Create(null));
            Assert.ThrowsException<InvalidOperationException>(() => _service.Create(string.Empty));
        }

        [TestMethod]
        public void TryDelete_DeletesDirectory_WhenExists()
        {
            // Arrange
            Directory.CreateDirectory(_tempDir);

            // Act
            var deleted = _service.TryDelete(_tempDir);

            // Assert
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void TryDelete_ReturnsFalse_WhenDirectoryDoesNotExist()
        {
            // Act
            var deleted = _service.TryDelete(_tempDir);

            // Assert
            Assert.IsFalse(deleted);
        }

        [TestMethod]
        public void Exists_ReturnsTrue_WhenDirectoryExists()
        {
            // Arrange
            Directory.CreateDirectory(_tempDir);

            // Act
            var exists = _service.Exists(_tempDir);

            // Assert
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void Exists_ReturnsFalse_WhenDirectoryDoesNotExist()
        {
            // Act
            var exists = _service.Exists(_tempDir);

            // Assert
            Assert.IsFalse(exists);
        }
    }
}
