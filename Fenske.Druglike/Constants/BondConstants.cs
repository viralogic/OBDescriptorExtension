using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension.Constants
{
    public class BondConstants
    {
        /// <summary>
        /// Scaling factors for 
        /// </summary>
        public static readonly double[] BondScaleFactors = new double[]
            {
                0.1, // aromatic
                0, // single
                0.2, // double
                0.3 // triple
            };
    }
}
