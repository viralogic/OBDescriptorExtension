using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBabel;
using System.IO;
using System.Web;

namespace OBDescriptorExtension
{
    public class MolReader
    {
        #region Private vars

        private OBConversion _converter;
        private string _filePath;
        private HashSet<string> _supportedFormats;
        private HttpPostedFileBase _postedFile;
        private string _tempDirectory = @"C:\Temp";

        #endregion

        #region Private properties

        private OBConversion Converter
        {
            get { return this._converter; }
        }

        public string FilePath
        {
            get { return this._filePath; }
        }

        private HashSet<string> SupportedFormats
        {
            get
            {
                if (this._supportedFormats == null)
                {
                    this._supportedFormats = new HashSet<string>();
                    foreach (var format in this.Converter.GetSupportedInputFormat())
                    {
                        this._supportedFormats.Add(format.Remove(format.IndexOf(' ')));
                    }
                }
                return this._supportedFormats;
            }
        }

        private HttpPostedFileBase PostedFile
        {
            get { return this._postedFile; }
        }

        private bool IsPostedFile
        {
            get { return this.PostedFile != null; }
        }

        #endregion

        #region Constructor

        public MolReader(string filePath)
        {
            this._filePath = filePath;
            this.SetConverter();
        }

        public MolReader(HttpPostedFileBase file)
        {
            this._postedFile = file;
            this.SetConverter();
        }

        #endregion

        #region Methods

        private void SetConverter()
        {
            this._converter = new OBConversion();
        }

        public IEnumerable<OBMol> Open()
        {
            if (!this.IsPostedFile)
            {
                return this.OpenFromPath(this.FilePath);
            }
            return this.OpenFromPostedFile(this.PostedFile);
        }

        private string CheckExtension(string fileName)
        {
            var extension = fileName.Substring(fileName.LastIndexOf('.') + 1);
            if (!this.SupportedFormats.Contains(extension))
            {
                throw new IOException(string.Format("FormatNotSupported: {0}", extension));
            }
            return extension;
        }

        /// <summary>
        /// This is a hack to allow opening files from a Http Post file. Currently have to write a temp file
        /// to disk, open file, and then delete the temp file to do this. OBDotNet does not currently have the ability
        /// to open files from a stream.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private IEnumerable<OBMol> OpenFromPostedFile(HttpPostedFileBase file)
        {
            var extension = this.CheckExtension(file.FileName);
            this.Converter.SetInFormat(extension);
            if (!Directory.Exists(this._tempDirectory))
            {
                try
                {
                    Directory.CreateDirectory(this._tempDirectory);
                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }
            var tempFile = System.IO.Path.Combine(this._tempDirectory, string.Format("{0}.{1}", Guid.NewGuid().ToString(), extension));
            var buffer = new byte[file.InputStream.Length];
            file.InputStream.Read(buffer, 0, (int)file.InputStream.Length);
            try
            {
                File.WriteAllBytes(tempFile, buffer);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
            var mols = this.OpenFromPath(tempFile);
            this._filePath = tempFile;
            return mols;
            
        }

        private IEnumerable<OBMol> OpenFromPath(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("FileNotFound: {0}", filePath));
            }
            this.Converter.SetInFormat(this.CheckExtension(filePath));
            var mol = new OBMol();
            if (this.Converter.ReadFile(mol, filePath))
            {
                yield return mol;
            }
            while (this.Converter.Read(mol))
            {
                yield return mol;
            }
        }

        public OBMol GetMol()
        {
            return this.Open().FirstOrDefault();
        }

        #endregion
    }
}
