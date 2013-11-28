using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension
{
    public class FeatureValue
    {
        #region Privates

        private string _name;
        private double _value;

        #endregion

        #region Properties

        public string Name
        {
            get { return this._name; }
        }

        public double Value
        {
            get { return this._value; }
        }

        #endregion

        #region Constructor

        public FeatureValue(string featureName, double value)
        {
            this._name = featureName;
            this._value = value;
        }
        #endregion
    }
}
