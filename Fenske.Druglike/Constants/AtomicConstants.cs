using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension.Constants
{
    public class AtomValues
    {
        #region Properties

        public readonly uint AtomicNumber;
        public readonly string Symbol;
        public readonly double RBO;
        public readonly int OuterShellElectrons;
        public readonly Nullable<double>[] HallKierAlphas;
        public readonly double rVdw;

        #endregion

        #region Constructor

        public AtomValues(uint atomicNumber, string symbol, double rbo, int outerElectrons, double rVdw, Nullable<double>[] hallKierAlphas)
        {
            if (symbol.Length > 2)
            {
                throw new ArgumentOutOfRangeException("Symbol cannot have length greater than 2");
            }
            this.AtomicNumber = atomicNumber;
            this.Symbol = symbol;
            this.RBO = rbo;
            this.OuterShellElectrons = outerElectrons;
            this.HallKierAlphas = hallKierAlphas;
            this.rVdw = rVdw;
        }

        public AtomValues(uint atomicNumber, string symbol, double rbo, int outerElectrons, double rVdw)
            : this(atomicNumber, symbol, rbo, outerElectrons, rVdw, null)
        {
        }

        #endregion

    }


    public class AtomicConstants
    {
        /// <summary>
        /// Immutable lookup of atom values used to contain atom constants
        /// </summary>
        private static ILookup<uint, AtomValues> AtomConstants = new AtomValues[]
        {
            new AtomValues(1, "H", 0.33, 1, 1.200, new Nullable<double>[]{0.0, 0.0, 0.0}),
            new AtomValues(2, "He",	0.7, 2, 1.400),
            new AtomValues(3,"Li",1.23,1, 1.820),
            new AtomValues(4,"Be",0.9,2, 1.700),
            new AtomValues(5,"B",0.82,3, 2.080),
            new AtomValues(6,"C",0.77,4, 1.950, new Nullable<double>[] {-0.22,-0.13,0.0}),
            new AtomValues(7,"N",0.7,5, 1.850, new Nullable<double>[] { -0.29,-0.20,-0.04}),
            new AtomValues(8,"O",0.66,6, 1.700, new Nullable<double>[] { null,-0.20,-0.04}),
            new AtomValues(9,"F",0.611,7, 1.730, new Nullable<double>[] {null,null,-0.07}),
            new AtomValues(10,"Ne",0.7,8, 1.540),
            new AtomValues(11,"Na",1.54,1, 2.270),
            new AtomValues(12,"Mg",1.36,2, 1.730),
            new AtomValues(13,"Al",1.18,3, 2.050),
            new AtomValues(14,"Si",0.937,4, 2.100),
            new AtomValues(15,"P",0.89,5, 2.080, new Nullable<double>[] {null,0.30,0.43}),
            new AtomValues(16,"S",1.04,6, 2.000, new Nullable<double>[] {null,0.22,0.35}),
            new AtomValues(17,"Cl",0.997,7, 1.970, new Nullable<double>[] { null,null,0.29}),
            new AtomValues(18,"Ar",1.74,8, 1.880),
            new AtomValues(19,"K",2.03,1, 2.750),
            new AtomValues(20,"Ca",1.74,2, 1.973),
            new AtomValues(21,"Sc",1.44,3, 1.700),
            new AtomValues(22,"Ti",1.32,4, 1.700),
            new AtomValues(23,"V",1.22,5, 1.700),
            new AtomValues(24,"Cr",1.18,6, 1.700),
            new AtomValues(25,"M",1.17,7, 1.700),
            new AtomValues(26,"Fe",1.17,8, 1.700),
            new AtomValues(27,"Co",1.16,9, 1.700),
            new AtomValues(28,"Ni",1.15,10, 1.630),
            new AtomValues(29,"Cu",1.17,11, 1.400),
            new AtomValues(30,"Z",1.25,2, 1.390),
            new AtomValues(31,"Ga",1.26,3, 1.870),
            new AtomValues(32,"Ge",1.188,4, 1.700),
            new AtomValues(33,"As",1.2,5, 1.850),
            new AtomValues(34,"Se",1.17,6, 1.900),
            new AtomValues(35,"Br",1.167,7, 2.100, new Nullable<double>[] {null,null,0.48}),
            new AtomValues(36,"Kr",1.91,8, 2.020),
            new AtomValues(37,"Rb",2.16,1, 1.700),
            new AtomValues(38,"Sr",1.91,2, 1.700),
            new AtomValues(39,"Y",1.62,3, 1.700),
            new AtomValues(40,"Zr",1.45,4, 1.700),
            new AtomValues(41,"Nb",1.34,5, 1.700),
            new AtomValues(42,"Mo",1.3,6, 1.700),
            new AtomValues(43,"Tc",1.27,7, 1.700),
            new AtomValues(44,"Ru",1.25,8, 1.700),
            new AtomValues(45,"Rh",1.25,9, 1.700),
            new AtomValues(46,"Pd",1.28,10, 1.630),
            new AtomValues(47,"Ag",1.34,11, 1.720),
            new AtomValues(48,"Cd",1.48,2, 1.580),
            new AtomValues(49,"I",1.44,3, 1.930, new Nullable<double>[] { null,null,0.73}),
            new AtomValues(50,"S",1.385,4, 2.170),
            new AtomValues(51,"Sb",1.4,5, 2.200),
            new AtomValues(52,"Te",1.378,6, 2.060),
            new AtomValues(53,"I",1.387,7, 2.150),
            new AtomValues(54,"Xe",1.98,8, 2.160),
            new AtomValues(55,"Cs",2.35,1, 1.700),
            new AtomValues(56,"Ba",1.98,2, 1.700),
            new AtomValues(57,"La",1.69,3, 1.700),
            new AtomValues(58,"Ce",1.83,4, 1.700),
            new AtomValues(59,"Pr",1.82,3, 1.700),
            new AtomValues(60,"Nd",1.81,4, 1.700),
            new AtomValues(61,"Pm",1.8,5, 1.700),
            new AtomValues(62,"Sm",1.8,6, 1.700),
            new AtomValues(63,"Eu",1.99,7, 1.700),
            new AtomValues(64,"Gd",1.79,8, 1.700),
            new AtomValues(65,"Tb",1.76,9, 1.700),
            new AtomValues(66,"Dy",1.75,10, 1.700),
            new AtomValues(67,"Ho",1.74,11, 1.700),
            new AtomValues(68,"Er",1.73,12, 1.700),
            new AtomValues(69,"Tm",1.72,13, 1.700),
            new AtomValues(70,"Yb",1.94,14, 1.700),
            new AtomValues(71,"Lu",1.72,15, 1.700),
            new AtomValues(72,"Hf",1.44,4, 1.700),
            new AtomValues(73,"Ta",1.34,5, 1.700),
            new AtomValues(74,"W",1.3,6, 1.700),
            new AtomValues(75,"Re",1.28,7, 1.700),
            new AtomValues(76,"Os",1.26,8, 1.700),
            new AtomValues(77,"Ir",1.27,9, 1.700),
            new AtomValues(78,"Pt",1.3,10, 1.720),
            new AtomValues(79,"Au",1.34,11, 1.660),
            new AtomValues(80,"Hg",1.49,2, 1.550),
            new AtomValues(81,"Tl",1.48,3, 1.960),
            new AtomValues(82,"Pb",1.48,4, 2.020),
            new AtomValues(83,"Bi",1.45,5, 1.700),
            new AtomValues(84,"Po",1.46,6, 1.700),
            new AtomValues(85,"At",1.45,7, 1.700),
            new AtomValues(86,"Rn",2.4,8, 1.700),
            new AtomValues(87,"Fr",2,1, 1.700),
            new AtomValues(88,"Ra",1.9,2, 1.700),
            new AtomValues(89,"Ac",1.88,3, 1.700),
            new AtomValues(90,"Th",1.79,4, 1.700),
            new AtomValues(91,"Pa",1.61,3, 1.700),
            new AtomValues(92,"U",1.58,4, 1.860),
            new AtomValues(93,"Np",1.55,5, 1.700),
            new AtomValues(94,"Pu",1.53,6, 1.700),
            new AtomValues(95,"Am",1.07,7, 1.700),
            new AtomValues(96,"Cm",0,8, 1.700),
            new AtomValues(97,"Bk",0,9, 1.700),
            new AtomValues(98,"Cf",0,10, 1.700),
            new AtomValues(99,"Es",0,11, 1.700),
            new AtomValues(100,"Fm",0,12, 1.700),
            new AtomValues(101,"Md",0,13, 1.700),
            new AtomValues(102,"No",0,14, 1.700),
            new AtomValues(103,"Lr",0,15, 1.700),
            new AtomValues(104,"Rf",0,2, 1.700),
            new AtomValues(105,"Db",0,2, 1.700),
            new AtomValues(106,"Sg",0,2, 1.700),
            new AtomValues(107,"Bh",0,2, 1.700),
            new AtomValues(108,"Hs",0,2, 1.700),
            new AtomValues(109,"Mt",0,2, 1.700),
            new AtomValues(110,"Ds",0,2, 1.700),
            new AtomValues(111,"Rg",0,2, 1.700),
            new AtomValues(112,"Cn",0,2, 1.700)
        }.ToLookup(a => a.AtomicNumber);

        private static AtomValues GetAtomValues(uint atomicNumber)
        {
            var atomValue = AtomConstants.SingleOrDefault(l => l.Key == atomicNumber);
            if (atomValue == null || atomValue.Count() == 0)
            {
                throw new KeyNotFoundException(string.Format("AtomValue with key {0} was not found", atomicNumber));
            }
            return atomValue.First();
        }

        /// <summary>
        /// Gets the RBO value for atom given atomic number
        /// </summary>
        /// <param name="atomicNumber"></param>
        /// <returns></returns>
        public static double GetRBO(uint atomicNumber)
        {
            return GetAtomValues(atomicNumber).RBO;
        }

        /// <summary>
        /// Gets number of outer shell electrons given atomic number
        /// </summary>
        /// <param name="atomicNumber"></param>
        /// <returns></returns>
        public static int GetOuterShellElectrons(uint atomicNumber)
        {
            return GetAtomValues(atomicNumber).OuterShellElectrons;
        }

        public static int GetLength()
        {
            return AtomConstants.Count;
        }

        /// <summary>
        /// Gets the Hall-Kier alphas for a given atomic number
        /// </summary>
        /// <param name="atomicNumber"></param>
        /// <returns></returns>
        public static Nullable<double>[] GetHallKierAlphas(uint atomicNumber)
        {
            return GetAtomValues(atomicNumber).HallKierAlphas;
        }

        /// <summary>
        /// Gets the rVdW constant for a given atomic number
        /// </summary>
        /// <param name="atomicNumber"></param>
        /// <returns></returns>
        public static double GetrVdW(uint atomicNumber)
        {
            return GetAtomValues(atomicNumber).rVdw;
        }
    }

    
}
