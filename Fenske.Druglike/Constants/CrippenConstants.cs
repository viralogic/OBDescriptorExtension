using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension.Constants
{
    public class CrippenValues
    {
        #region Properties

        public readonly string AtomType;
        public readonly string[] Smarts;
        public readonly double MolarRefractivity;
        public readonly double LogP;

        #endregion

        #region Constructor

        public CrippenValues(string atomType, string[] smarts, double molarRefractivity, double logP)
        {
            this.AtomType = atomType;
            this.Smarts = smarts;
            this.MolarRefractivity = molarRefractivity;
            this.LogP = logP;
        }

        #endregion
    }

    public class CrippenConstants
    {
        public static ILookup<string, CrippenValues> CrippenContributions = new CrippenValues[]
            {
                new CrippenValues("C1", new string[] {"[CH4]","[CH3]C","[CH2](C)C"}, 2.503, 0.1441),
                new CrippenValues("C2", new string[] {"[CH](C)(C)C", "[C](C)(C)(C)C"}, 2.433, 0),
                new CrippenValues("C3", new string[] {"[CH3][N,O,P,S,F,Cl,Br,I]", "[CH2X4]([N,O,P,S,F,Cl,Br,I])[A;!#1]"}, 2.753, -0.2035),
                new CrippenValues("C4", new string[] {"[CH1X4]([N,O,P,S,F,Cl,Br,I])([A;!#1])[A;!#1]", "[CH0X4]([N,O,P,S,F,Cl,Br,I])([A;!#1])([A;!#1])[A;!#1]"}, 2.731, -0.2051),
                new CrippenValues("C5", new string[] {"[C]=[!C;A;!#1]"}, 5.007, -0.2783),
                new CrippenValues("C6", new string[] {"[CH2]=C", "[CH1](=C)[A;!#1]", "[CH0](=C)([A;!#1])[A;!#1]", "[C](=C)=C"}, 3.513, 0.1551),
                new CrippenValues("C7", new string[] {"[CX2]#[A;!#1]"}, 3.888, 0.0017),
                new CrippenValues("C8", new string[] {"[CH3]c"}, 2.464, 0.08452),
                new CrippenValues("C9", new string[] {"[CH3]a"}, 2.412, -0.1444),
                new CrippenValues("C10",new string[] {"[CH2X4]a"}, 2.488, -0.0516),
                new CrippenValues("C11",new string[] {"[CHX4]a"}, 2.582, 0.1193),
                new CrippenValues("C12",new string[] {"[CH0X4]a"}, 2.576, -0.0967),
                new CrippenValues("C13",new string[] {"[cH0]-[A;!C;!N;!O;!S;!F;!Cl;!Br;!I;!#1]"}, 4.041, -0.5443),
                new CrippenValues("C14", new string[] {"[c][#9]"}, 3.257, 0),
                new CrippenValues("C15", new string[] {"[c][#17]"}, 3.564, 0.245),
                new CrippenValues("C16", new string[] {"[c][#35]"}, 3.18, 0.198),
                new CrippenValues("C17", new string[] {"[c][#53]"}, 3.104, 0),
                new CrippenValues("C18", new string[] {"[cH]"}, 3.35, 0.1581),
                new CrippenValues("C19", new string[] {"[c](:a)(:a):a"}, 4.346, 0.2955),
                new CrippenValues("C20", new string[] {"[c](:a)(:a)-a"}, 3.904, 0.2713),
                new CrippenValues("C21", new string[] {"[c](:a)(:a)-C"}, 3.509, 0.136),
                new CrippenValues("C22", new string[] {"[c](:a)(:a)-N"}, 4.067, 0.4619),
                new CrippenValues("C23", new string[] {"[c](:a)(:a)-O"}, 3.853, 0.5437),
                new CrippenValues("C24", new string[] {"[c](:a)(:a)-S"}, 2.673, 0.1893),
                new CrippenValues("C25", new string[] {"[c](:a)(:a)=[C,N,O]"}, 3.135, -0.8186),
                new CrippenValues("C26", new string[] {"[C](=C)(a)[A;!#1]", "[C](=C)(c)a", "[CH1](=C)a","[C]=c"}, 4.305, 0.264),
                new CrippenValues("C27", new string[] {"[CX4][A;!C;!N;!O;!P;!S;!F;!Cl;!Br;!I;!#1]"}, 2.693, 0.2148),
                new CrippenValues("CS", new string[]{"[#6]"}, 3.243, 0.08129),
                new CrippenValues("H1", new string[]{"[#1][#6,#1]"}, 1.057, 0.123),
                new CrippenValues("H2", new string[]{"[#1]O[CX4,c]", "[#1]O[!C;!N;!O;!S]","[#1][!C;!N;!O]"}, 1.395, -0.2677),
                new CrippenValues("H3", new string[]{"[#1][#7]", "[#1]O[#7]"}, 0.9627, 0.2142),
                new CrippenValues("H4", new string[]{"[#1]OC=[#6,#7,O,S]", "[#1]O[O,S]"}, 1.805, 0.298),
                new CrippenValues("HS", new string[] {"[#1]"}, 1.112, 0.1125),
                new CrippenValues("N1", new string[] {"[NH2+0][A;!#1]"}, 2.262, -1.019),
                new CrippenValues("N2", new string[] {"[NH+0]([A;!#1])[A;!#1]"}, 2.173, -0.7096),
                new CrippenValues("N3", new string[] {"[NH2+0]a"}, 2.827, -1.027),
                new CrippenValues("N4", new string[] {"[NH1+0]([!#1;A,a])a"}, 3, -0.5188),
                new CrippenValues("N5", new string[] {"[NH+0]=[!#1;A,a]"}, 1.757, 0.08387),
                new CrippenValues("N6", new string[] {"[N+0](=[!#1;A,a])[!#1;A,a]"}, 2.428, 0.1836),
                new CrippenValues("N7", new string[] {"[N+0]([A;!#1])([A;!#1])[A;!#1]"}, 1.839, -0.3187),
                new CrippenValues("N8", new string[] {"[N+0](a)([!#1;A,a])[A;!#1]", "[N+0](a)(a)a"}, 2.819, -0.4458),
                new CrippenValues("N9", new string[] {"[N+0]#[A;!#1]"}, 1.725, 0.01508),
                new CrippenValues("N10", new string[]{"[NH3,NH2,NH;+,+2,+3]"}, -1.95, -1.950),
                new CrippenValues("N11", new string[]{"[n+0]"}, 2.202, -0.3239),
                new CrippenValues("N12", new string[] {"[n;+,+2,+3]"}, -1.119, -1.119),
                new CrippenValues("N13", new string[]{"[NH0;+,+2,+3]([A;!#1])([A;!#1])([A;!#1])[A;!#1]", "[NH0;+,+2,+3](=[A;!#1])([A;!#1])[!#1;A,a]","[NH0;+,+2,+3](=[#6])=[#7]"}, 0.2604, -0.3396),
                new CrippenValues("N14", new string[] {"[N;+,+2,+3]#[A;!#1]", "[N;-,-2,-3]", "[N;+,+2,+3](=[N;-,-2,-3])=N"}, 3.359, 0.2887),
                new CrippenValues("NS", new string[] {"[#7]"}, 2.134, -0.4806),
                new CrippenValues("O1", new string[]{"[o]"}, 1.08, 0.1552),
                new CrippenValues("O2", new string[]{"[OH,OH2]"}, 0.8238, -0.2893),
                new CrippenValues("O3", new string[]{"[O]([A;!#1])[A;!#1]"}, 1.085, -0.0684),
                new CrippenValues("O4", new string[]{"[O](a)[!#1;A,a]"}, 1.182, -0.4195),
                new CrippenValues("O5",	new string[]{"[O]=[#7,#8]", "[OX1;-,-2,-3][#7]"}, 3.367, 0.0335),
                new CrippenValues("O6", new string[] {"[OX1;-,-2,-2][#16]", "[O;-0]=[#16;-0]"}, 0.7774, -0.3339),
                new CrippenValues("O7", new string[] {"[OX1;-,-2,-3][!#1;!N;!S]"}, 0, -1.189),
                new CrippenValues("O8", new string[] {"[O]=c"}, 3.135, 0.1788),
                new CrippenValues("O9", new string[] {"[O]=[CH]C", "[O]=C(C)([A;!#1])", "[O]=[CH][N,O]","[O]=[CH2]","[O]=[CX2]=O"}, 0, -0.1526),
                new CrippenValues("O10", new string[] {"[O]=[CH]c", "[O]=C([C,c])[a;!#1]","[O]=C(c)[A;!#1]"}, 0.2215, 0.1129),
                new CrippenValues("O11" , new string[] {"[O]=C([!#1;!#6])[!#1;!#6]"}, 0.389, 0.4833),
                new CrippenValues("O12", new string[] {"[O-]C(=O)"}, 0, -1.326),
                new CrippenValues("OS", new string[] {"[#8]"}, 0.6865, -0.1188),
                new CrippenValues("F", new string[] {"[#9-0]"}, 1.108, 0.4202),
                new CrippenValues("Cl", new string[] {"[#17-0]"}, 5.853, 0.6895),
                new CrippenValues("Br", new string[] {"[#35-0]"}, 8.927, 0.8456),
                new CrippenValues("I", new string[] {"[#53-0]"}, 14.02, 0.8857),
                new CrippenValues("Hal", new string[]{"[#9,#17,#35,#53;-]", "[#53;+,+2,+3]","[+;#3,#11,#19,#37,#55]"}, 0, -2.996),
                new CrippenValues("P", new string[] {"[#15]"}, 6.92, 0.8612),
                new CrippenValues("S1", new string[] {"[S;A]"}, 7.591, 0.6482),
                new CrippenValues("S2", new string[] {"[S;-,-2,-3,-4,+1,+2,+3,+5,+6]", "[S-0]=[N,O,P,S]"}, 7.365, -0.0024),
                new CrippenValues("S3", new string[] {"[s;a]"}, 6.691, 0.6237),
                new CrippenValues("Me1", new string[] {"[#3,#11,#19,#37,#55]", "[#4,#12,#20,#38,#56]","[#5,#13,#31,#49,#81]","[#14,#32,#50,#82]","[#33,#51,#83]","[#34,#52,#84]"}, 5.754, -0.3808),
                new CrippenValues("Me2", new string[] {"[#21,#22,#23,#24,#25,#26,#27,#28,#29,#30]", "[#39,#40,#41,#42,#43,#44,#45,#46,#47,#48]","[#72,#73,#74,#75,#76,#77,#78,#79,#80]"}, 0, -0.0025)
            }.ToLookup(a => a.AtomType);

        private static CrippenValues GetCrippenValues(string atomType)
        {
            var crippenValue = CrippenContributions.SingleOrDefault(v => v.Key == atomType);
            if (crippenValue == null || crippenValue.Count() == 0)
            {
                throw new KeyNotFoundException(string.Format("CrippenValue with key {0} was not found", atomType));
            }
            return crippenValue.First();
        }

        /// <summary>
        /// Gets the Smarts patterns associated with the given atom type
        /// </summary>
        /// <param name="atomType"></param>
        /// <returns></returns>
        public static string[] GetSmarts(string atomType)
        {
            return GetCrippenValues(atomType).Smarts;
        }

        /// <summary>
        /// Gets the molar refractivity contribution associated with the given atom type
        /// </summary>
        /// <param name="atomType"></param>
        /// <returns></returns>
        public static double GetMolarRefractivity(string atomType)
        {
            return GetCrippenValues(atomType).MolarRefractivity;
        }

        /// <summary>
        /// Gets the logP contribution associated with the given atom type
        /// </summary>
        /// <param name="atomType"></param>
        /// <returns></returns>
        public static double GetLogP(string atomType)
        {
            return GetCrippenValues(atomType).LogP;
        }
    }        
}
