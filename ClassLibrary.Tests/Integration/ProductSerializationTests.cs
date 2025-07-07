using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Products;
using ProductManager.Core.Services;
using ProductManager.Core.Services.Interfaces;
using ProductManager.Tests.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductManager.Tests.Integration
{
    [TestClass]
    public class ProductSerializationTests
    {
        private IParser _parser;
        private IFileService _fileService;
        private string _tempPath;
        private string _tempFile;
        private IFolderService _folderService;
        private string _tempDir;

        [TestInitialize]
        public void Setup()
        {
            _parser = new Parser();
            _fileService = new FileService();
            _folderService = new FolderService();

            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            _tempPath = Path.GetTempPath();
            _tempFile = Path.Combine(_tempPath, Guid.NewGuid() + ".txt");
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists(_tempDir))
                Directory.Delete(_tempDir, recursive: true);
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        [TestMethod]
        public void SaveAndLoadProduct_ShouldReturnEqualProduct()
        {
            var original = TestData.Standard;
            var json = _parser.Serialize(new List<Product> { original });
            _fileService.Save(json, _tempFile);

            _fileService.TryRead(_tempFile, out var content);
            var result = _parser.Deserialize(content).First();

            Assert.IsTrue(original.Equals(result));
        }
        [TestMethod]
        public void SaveProductToFile_ShouldCreateFileOnDisk()
        {
            var product = TestData.Standard;
            var json = _parser.Serialize(new List<Product> { product });

            _fileService.Save(json, _tempFile);

            Assert.IsTrue(File.Exists(_tempFile));
        }

        [TestMethod]
        public void DeleteProductFile_ShouldRemoveFileFromDisk()
        {
            var product = TestData.Standard;
            var json = _parser.Serialize(new List<Product> { product });
            _fileService.Save(json, _tempFile);

            var deleted = _fileService.TryDelete(_tempFile);

            Assert.IsTrue(deleted);
            Assert.IsFalse(File.Exists(_tempFile));
        }

        [TestMethod]
        public void DeserializeCorruptedJson_ShouldThrowException()
        {
            var corruptedJson = "{ \"invalid\": true, "; // невалидный JSON
            _fileService.Save(corruptedJson, _tempFile);

            _fileService.TryRead(_tempFile, out var content);

            Assert.ThrowsException<Newtonsoft.Json.JsonReaderException>(() =>
            {
                _parser.Deserialize(content).ToList();
            });
        }

        [TestMethod]
        public void SaveMultipleProductsAndReload_ShouldPreserveData()
        {
            var products = new List<Product>
            {
                TestData.Standard,
                TestData.QuantityTwo,
                TestData.Expensive
            };

            var json = _parser.Serialize(products);
            _fileService.Save(json, _tempFile);
            _fileService.TryRead(_tempFile, out var content);
            var loaded = _parser.Deserialize(content).ToList();

            Assert.AreEqual(products.Count, loaded.Count);
            foreach (var expected in products)
            {
                Assert.IsTrue(loaded.Any(actual => actual.Equals(expected)));
            }
        }

        [TestMethod]
        public void CreateAndDeleteFolder_ShouldBehaveAsExpected()
        {
            var result = _folderService.Create(_tempDir);
            Assert.IsTrue(Directory.Exists(result.FullName));

            var deleted = _folderService.TryDelete(_tempDir, recursive: true);
            Assert.IsTrue(deleted);
            Assert.IsFalse(Directory.Exists(_tempDir));
        }

        [TestMethod]
        public void ReadNonexistentFile_ShouldReturnFalse()
        {
            var nonexistentFile = Path.Combine(_tempDir, "not_exists.json");
            var success = _fileService.TryRead(nonexistentFile, out var _);

            Assert.IsFalse(success);
        }
    }
}