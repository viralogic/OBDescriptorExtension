using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBabel;

namespace OBDescriptorExtension
{
    public class Path
    {
        #region Privates

        private IEnumerable<OBAtom> _pathAtoms;

        #endregion

        #region Properties

        /// <summary>
        /// The start atom of the path
        /// </summary>
        public OBAtom EndAtom
        {
            get { return this.PathAtoms.LastOrDefault(); }
        }

        public int StartIdx
        {
            get { return this.Length > 0 ? (int)this.StartAtom.GetIdx() - 1 : -1; } 
        }

        public int EndIdx
        {
            get { return this.Length > 0 ? (int)this.EndAtom.GetIdx() - 1 : -1; }
        }

        /// <summary>
        /// The end atom of the path
        /// </summary>
        public OBAtom StartAtom
        {
            get { return this.PathAtoms.FirstOrDefault(); }
        }

        /// <summary>
        /// The atom indices that make up the path
        /// </summary>
        public IEnumerable<OBAtom> PathAtoms 
        {
            get { return this._pathAtoms; }
        }

        public int Length { get { return this.PathAtoms.Count(); } }

        #endregion

        #region Constructor

        public Path(IEnumerable<OBAtom> pathAtoms)
        {
            this._pathAtoms = pathAtoms;
        }

        #endregion
    }
}
