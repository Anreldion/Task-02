using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Services;
using ProductManager.Core.Services.Interfaces;
using System;
using System.IO;

namespace ProductManager.Tests.Services
{
    [TestClass]
    public class FileServiceTest
    {
        private IFileService _service;
        private string _tempPath;
        private string _tempFile;
        private const string TestContent = "Test content";

        [TestInitialize]
        public void SetUp()
        {
            _service = new FileService();
            _tempPath = Path.GetTempPath();
            _tempFile = Path.Combine(_tempPath, Guid.NewGuid() + ".txt");
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        [TestMethod]
        public void Save_CreatesFileWithContent()
        {
            _service.Save(TestContent, _tempFile);
            var result = _service.TryRead(_tempFile, out var content);

            Assert.IsTrue(result);
            Assert.AreEqual(TestContent, content);
        }

        [TestMethod]
        public void Save_Throws_WhenContentIsNullOrEmpty()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _service.Save(null, _tempFile));
            Assert.ThrowsException<InvalidOperationException>(() => _service.Save(string.Empty, _tempFile));
        }

        [TestMethod]
        public void TryRead_ReturnsTrue_AndReadsContent_WhenFileExists()
        {
            _service.Save(TestContent, _tempFile);

            var success = _service.TryRead(_tempFile, out var content);

            Assert.IsTrue(success);
            Assert.AreEqual(TestContent, content);
        }

        [TestMethod]
        public void TryRead_ReturnsFalse_WhenFileDoesNotExist()
        {
            var success = _service.TryRead(_tempFile, out var content);

            Assert.IsFalse(success);
            Assert.IsNull(content);
        }

        [TestMethod]
        public void TryDelete_DeletesFile_WhenExists()
        {
            _service.Save(TestContent, _tempFile);

            var result = _service.TryDelete(_tempFile);

            Assert.IsTrue(result);
            Assert.IsFalse(File.Exists(_tempFile));
        }

        [TestMethod]
        public void TryDelete_ReturnsFalse_WhenFileDoesNotExist()
        {
            var result = _service.TryDelete(_tempFile);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Exists_ReturnsTrue_WhenFileExists()
        {
            _service.Save(TestContent, _tempFile);

            var result = _service.Exists(_tempFile);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Exists_ReturnsFalse_WhenFileDoesNotExist()
        {
            var result = _service.Exists(_tempFile);

            Assert.IsFalse(result);
        }
    }
}
