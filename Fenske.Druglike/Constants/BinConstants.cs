using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension.Constants
{
    class BinConstants
    {

        /// <summary>
        /// Used for PEOE_VSA
        /// </summary>
        public static readonly double[] AtomicChargeBins = new double[]
            {
                -0.3,
                -.25,
                -.20,
                -.15,
                -.10,
                -.05,
                0,
                0.05,
                0.10,
                0.15,
                0.20,
                0.25,
                0.30
            };

        /// <summary>
        /// Used for Labute SMR VSA calculation
        /// </summary>
        public static readonly double[] LabuteMrBins = new double[]
            {
                1.29,
                1.82,
                2.24,
                2.45,
                2.75,
                3.05,
                3.63,
                3.8,
                4.0
            };

        /// <summary>
        /// Used for Labute SLogP VSA calculation
        /// </summary>
        public static readonly double[] LabuteLogPBins = new double[]
            {
                -0.4,
                -0.2,
                0,
                0.1,
                0.15,
                0.2,
                0.25,
                0.3,
                0.4,
                0.5,
                0.6
            };

        /// <summary>
        /// Used for VSA_EState and EState_VSA calculations
        /// </summary>
        public static readonly double[] EStateBins = new double[]
            {
                -0.390,
                0.290,
                0.717,
                1.165,
                1.540,
                1.807,
                2.05,
                4.69,
                9.17,
                15.0
            };
    }
}
