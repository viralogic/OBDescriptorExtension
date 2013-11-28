using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBabel;
using System.IO;

namespace OBDescriptorExtension
{
    public class MolReader
    {
        #region Private vars

        private OBConversion _converter;
        private string _filePath;
        private HashSet<string> _supportedFormats;

        #endregion

        #region Private properties

        private OBConversion Converter
        {
            get { return this._converter; }
        }

        private string FilePath
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

        #endregion

        #region Constructor

        public MolReader(string filePath)
        {
            this._filePath = filePath;
            this._converter = new OBConversion();
        }

        #endregion

        #region Methods

        public IEnumerable<OBMol> Open()
        {
            if (!File.Exists(this.FilePath))
            {
                throw new FileNotFoundException(string.Format("FileNotFound: {0}", this.FilePath));
            }
            var extension = this.FilePath.Substring(this.FilePath.LastIndexOf('.') + 1);
            if (!this.SupportedFormats.Contains(extension))
            {
                throw new IOException(string.Format("FormatNotSupported: {0}", extension));
            }
            this.Converter.SetInFormat(extension);
            var mol = new OBMol();
            if (this.Converter.ReadFile(mol, this.FilePath))
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
            return this.Open().First();
        }

        #endregion
    }
}
