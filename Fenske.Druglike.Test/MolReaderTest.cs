using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OBDescriptorExtension;
using System.IO;
using OpenBabel;
using System.Web;
using Moq;

namespace OBDescriptorExtension.Test
{
    [TestClass]
    public class MolReaderTest
    {
        #region Private variables

        private IEnumerable<OBMol> _molCollection;

        #endregion

        [TestMethod]
        public void PropaneTest()
        {
            this._molCollection = new MolReader(FileNames.PropaneFilePath).Open();
            Assert.AreEqual<int>(1, this._molCollection.Count(), string.Format("PropaneTest: {0} does not equal 1", this._molCollection.Count()));
        }

        [TestMethod]
        public void MultiMolTest()
        {
            this._molCollection = new MolReader(FileNames.MultiMolFilePath).Open();
            Assert.AreEqual<int>(1597, this._molCollection.Count(), string.Format("MultiMolTest: {0} does not equal 1597", this._molCollection.Count()));
        }

        [TestMethod]
        public void PostedFileTest()
        {
            using (var stream = new FileStream(FileNames.MultiMolFilePath, FileMode.Open))
            {
                var postedFile = new Mock<HttpPostedFileBase>();
                postedFile.Setup(f => f.ContentLength).Returns((int)stream.Length).Verifiable();
                postedFile.Setup(f => f.FileName).Returns(FileNames.MultiMolFilePath.Split('/').Last()).Verifiable();
                postedFile.Setup(f => f.InputStream).Returns(stream).Verifiable();

                var reader = new MolReader(postedFile.Object);
                this._molCollection = reader.Open();
                Assert.AreEqual<int>(1597, this._molCollection.Count(), string.Format("PostedFileTest: {0} does not equal 1597", this._molCollection.Count()));
                File.Delete(reader.FilePath);
            }
        }

        [TestMethod, ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundExceptionTest()
        {
            this._molCollection = new MolReader(FileNames.NotExistFilePath).Open();
            // Need to enumerate collection to force exception
            var molList = this._molCollection.ToList();
        }

        [TestMethod, ExpectedException(typeof(IOException))]
        public void IOExceptionTest()
        {
            this._molCollection = new MolReader(FileNames.NotSupportedFilePath).Open();
            var molList = this._molCollection.ToList();
        }
    }
}
