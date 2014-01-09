using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension
{
    public class FeatureStatistics
    {
        #region Privates

        private FeatureValues _featureValues;
        private double? _mean;
        private double? _min;
        private int? _count;
        private double? _max;
        private double? _variance;
        private double?_stdDev;
        private double? _median;

        #endregion

        #region Properties

        private FeatureValues FeatureValues
        {
            get { return this._featureValues; }
        }

        public string Name
        {
            get { return this.FeatureValues.Name; }
        }

        public IEnumerable<double> Values
        {
            get { return this.FeatureValues.Values; }
        }

        public double Count
        {
            get 
            {
                if (!this._count.HasValue)
                {
                    this._count = this.FeatureValues.Values.Count(); 
                }
                return this._count.Value;
            }
        }

        public double Mean
        {
            get 
            {
                if (!this._mean.HasValue)
                {
                    this._mean = this.FeatureValues.Values.Average(); 
                }
                return this._mean.Value;
            }
        }

        public double Min
        {
            get
            {
                if (!this._min.HasValue)
                {
                    this._min = this.FeatureValues.Values.Min();
                }
                return this._min.Value;
            }
        }

        public double Max
        {
            get
            {
                if (!this._max.HasValue)
                {
                    this._max = this.FeatureValues.Values.Max();
                }
                return this._max.Value;
            }
        }

        public double Variance
        {
            get
            {
                if (!this._variance.HasValue)
                {
                    this._variance = this.FeatureValues.Values.Variance();
                }
                return this._variance.Value;
            }
        }

        public double StdDev
        {
            get 
            {
                if (!this._stdDev.HasValue)
                {
                    this._stdDev = Math.Sqrt(this.Variance);
                }
                return this._stdDev.Value;
            }
        }

        public double Median
        {
            get
            {
                if (!this._median.HasValue)
                {
                    this._median = this.FeatureValues.Values.Median();
                }
                return this._median.Value;
            }
        }



        #endregion

        #region Constructor

        public FeatureStatistics(FeatureValues featureValues)
        {
            this._featureValues = featureValues;
        }

        #endregion
    }
}
