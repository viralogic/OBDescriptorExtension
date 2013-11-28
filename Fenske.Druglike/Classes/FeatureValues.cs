using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension
{
    public class FeatureValues
    {
        #region Privates

        private string _name;
        private IEnumerable<double> _values;

        #endregion

        #region Properties

        public string Name
        {
            get { return this._name; }
        }

        public IEnumerable<double> Values
        {
            get { return this._values; }
        }

        #endregion

        #region Constructors

        public FeatureValues(string featureName, IEnumerable<double> values)
        {
            this._name = featureName;
            this._values = values;
        }

        #endregion
    }
}
