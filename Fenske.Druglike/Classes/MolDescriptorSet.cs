using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension
{
    public class MolDescriptorSet
    {

        #region Private variables

        private IEnumerable<MolDescriptor> _molDescriptors;

        #endregion

        #region Properties

        /// <summary>
        /// List of molecular descriptor instances
        /// </summary>
        private IEnumerable<MolDescriptor> MolDescriptors
        {
            get { return this._molDescriptors; }
        }

        /// <summary>
        /// Property to determine if the set contains molecular descriptors
        /// </summary>
        public bool HasMols
        {
            get { return (this.MolDescriptors != null && this.NumMols > 0); }
        }

        /// <summary>
        /// Number of mols in the molecular descriptor list
        /// </summary>
        public int NumMols
        {
            get { return this.MolDescriptors.Count(); }
        }

        #endregion

        #region Constructor

        public MolDescriptorSet(IEnumerable<MolDescriptor> molDescriptors)
        {
            if (molDescriptors != null)
            {
                this._molDescriptors = molDescriptors;
            }
            else
            {
                this._molDescriptors = new List<MolDescriptor>();
            }
        }

        #endregion

        #region Statics

        /// <summary>
        /// Instance of MolDescriptorSet from file with optional molecular weight filter
        /// </summary>
        /// <param name="filePath">string</param>
        /// <returns></returns>
        public static MolDescriptorSet FromFile(string filePath, int? molWeightCutoff = null)
        {
            var mols = new MolReader(filePath).Open();
            if (molWeightCutoff.HasValue)
            {
                mols = mols.Where(md => md.GetMolWt() <= molWeightCutoff.Value);
            }
            return new MolDescriptorSet(mols.Select(cmpd => new MolDescriptor(cmpd)));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a feature values object that contains the feature name and all the given feature values in the mol descriptor collection
        /// </summary>
        /// <param name="featureName">string</param>
        /// <returns></returns>
        public OBDescriptorExtension.FeatureValues FeatureValues(string featureName)
        {
            var values = this.MolDescriptors.Select(d => d.FeatureValue(featureName).Value);
            return new OBDescriptorExtension.FeatureValues(featureName, values);
        }

        /// <summary>
        /// Returns the average value for a given feature
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns></returns>
        public double Average(string featureName)
        {
            return new FeatureStatistics(this.FeatureValues(featureName)).Mean;
        }

        /// <summary>
        /// Return the minimum value for a given feature
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns></returns>
        public double Min(string featureName)
        {
            return new FeatureStatistics(this.FeatureValues(featureName)).Min;
        }

        /// <summary>
        /// Returns the maximum value for a given feature
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns></returns>
        public double Max(string featureName)
        {
            return new FeatureStatistics(this.FeatureValues(featureName)).Max;
        }

        /// <summary>
        /// Returns the variance for a given feature
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns></returns>
        public double Variance(string featureName)
        {
            return new FeatureStatistics(this.FeatureValues(featureName)).Variance;
        }

        /// <summary>
        /// Returns the standard deviation for a given feature
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns></returns>
        public double StdDev(string featureName)
        {
            return new FeatureStatistics(this.FeatureValues(featureName)).StdDev;
        }

        /// <summary>
        /// Return the median for a given feature
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns></returns>
        public double Median(string featureName)
        {
            return new FeatureStatistics(this.FeatureValues(featureName)).Median;
        }

        /// <summary>
        /// Returns the statistics for each feature
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FeatureStatistics> Statistics()
        {
            if (!this.HasMols)
            {
                return new List<FeatureStatistics>();
            }
            return MolDescriptor.GetFeatureNames().Select(f => new FeatureStatistics(this.FeatureValues(f)));
        }

        /// <summary>
        /// Converts the molecular description collection to a Matrix object
        /// </summary>
        /// <returns></returns>
        public Matrix ToMatrix()
        {
            if (!this.HasMols)
            {
                return new Matrix(0, 0);
            }
            var features = MolDescriptor.GetFeatureNames().OrderBy(n => n);
            var matrix = new Matrix(this.NumMols, features.Count());
            var i = 0;
            foreach (var descriptor in this.MolDescriptors)
            {
                var j = 0;
                foreach (var feature in features)
                {
                    matrix.Update(i, j, descriptor.FeatureValue(feature).Value);
                    j++;
                }
                i++;
            }
            return matrix;
        }

        #endregion
    }
}
