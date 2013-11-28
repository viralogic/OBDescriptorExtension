using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBabel;
using OBDescriptorExtension.Constants;

namespace OBDescriptorExtension
{
    public static class OBAtomExtensions
    {

        /// <summary>
        /// Retrieves the RCov value for atom
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public static double GetRBO(this OBAtom atom)
        {
            var index = atom.GetAtomicNum();
            if (index >= AtomicConstants.GetLength())
            {
                throw new IndexOutOfRangeException(string.Format("GetRBO: {0} is out of range", index));
            }
            return AtomicConstants.GetRBO(index);
        }

        /// <summary>
        /// Determines the possible Crippen atom type for the OBAtom object
        /// </summary>
        /// <param name="atom"></param>
        /// <returns>Crippen atom type as string if found, otherwise empty string</returns>
        private static string GetCrippenAtomType(this OBAtom atom)
        {
            var partialCharge = Convert.ToInt32(atom.GetPartialCharge());
            var atomicNumber = atom.GetAtomicNum();
            if (partialCharge != 0)
            {
                if (atomicNumber == 9 || 
                    atomicNumber == 17 || 
                    atomicNumber == 35 || 
                    atomicNumber == 53 || 
                    atomicNumber == 3 || 
                    atomicNumber == 11 || 
                    atomicNumber == 19 ||
                    atomicNumber == 37 ||
                    atomicNumber == 55 )
                {
                    return "Ha";
                }
            }
            else
            {
                if (atomicNumber == 6) return "C";
                if (atomicNumber == 1) return "H";
                if (atomicNumber == 7) return "N";
                if (atomicNumber == 8) return "O";
                if (atomicNumber == 15) return "P";
                if (atomicNumber == 16) return "S";
                if (atomicNumber == 9) return "F";
                if (atomicNumber == 17) return "Cl";
                if (atomicNumber == 35) return "Br";
                if (atomicNumber == 53) return "I";
                if ((atomicNumber >= 21 && atomicNumber <= 30) ||
                    (atomicNumber >= 39 && atomicNumber <= 48) ||
                    (atomicNumber >= 72 && atomicNumber <= 80) ||
                    atomicNumber == 3 ||
                    atomicNumber == 4 ||
                    atomicNumber == 5 ||
                    atomicNumber == 11 ||
                    atomicNumber == 12 ||
                    atomicNumber == 13 ||
                    atomicNumber == 14 ||
                    atomicNumber == 19 ||
                    atomicNumber == 20 ||
                    atomicNumber == 31 ||
                    atomicNumber == 32 ||
                    atomicNumber == 33 ||
                    atomicNumber == 34 ||
                    atomicNumber == 37 ||
                    atomicNumber == 38 ||
                    atomicNumber == 49 ||
                    atomicNumber == 50 ||
                    atomicNumber == 51 ||
                    atomicNumber == 52 ||
                    atomicNumber == 55 ||
                    atomicNumber == 56 ||
                    atomicNumber == 81 ||
                    atomicNumber == 82 ||
                    atomicNumber == 83 ||
                    atomicNumber == 84) return "Me";
            }
            return string.Empty;
        }

        /// <summary>
        /// Retrieves first relevant atom type based on SMARTS pattern that matches atom
        /// </summary>
        /// <param name="atom"></param>
        /// <returns>Crippen Atom Type key if atom matches a pattern, otherwise empty string.</returns>
        public static string GetCrippenKey(this OBAtom atom)
        {
            var element = atom.GetCrippenAtomType();
            if (string.IsNullOrEmpty(element))
            {
                throw new Exception(string.Format("Crippen atom type could not be determined for {0}", atom.GetAtomicNum()));
            }
            var keys = CrippenConstants.CrippenContributions.Where(g => g.Key.Contains(element)).Select(g => g.Key);
            foreach (var key in keys)
            {
                foreach (var pattern in CrippenConstants.GetSmarts(key))
                {
                    if (atom.MatchesSMARTS(pattern))
                    {
                        return key;
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Calculates the number of atoms in the outermost shell
        /// </summary>
        /// <param name="atom"></param>
        /// <returns>int</returns>
        public static int NOuterShellElectrons(this OBAtom atom)
        {
            return AtomicConstants.GetOuterShellElectrons(atom.GetAtomicNum());
        }

        /// <summary>
        /// Determines the principle quantum number of an atom
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public static int PrincipleQuantumNumber(this OBAtom atom)
        {
            var atomicNumber = atom.GetAtomicNum();
            if (atomicNumber <= 2) return 1;
            if (atomicNumber <= 10) return 2;
            if (atomicNumber <= 18) return 3;
            if (atomicNumber <= 36) return 4;
            if (atomicNumber <= 54) return 5;
            if (atomicNumber <= 86) return 6;
            return 7;
        }

        /// <summary>
        /// Calculates the total number of hydrogens (implicit and explicit)
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public static uint TotalNumHydrogens(this OBAtom atom)
        {
            return atom.ImplicitHydrogenCount() + atom.ExplicitHydrogenCount();
        }

        /// <summary>
        /// Calculates the valence number as defined by the number of outer shell electrons minus the total number of hydrogens
        /// (implicit and explicit)
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public static int ValenceNumber(this OBAtom atom)
        {
            return atom.NOuterShellElectrons() - (int)atom.TotalNumHydrogens();
        }

        /// <summary>
        /// Performs hybridization mapping from OpenBabel to rdkit values
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public static int Hybridization(this OBAtom atom)
        {
            switch (atom.GetHyb())
            {
                case 1:
                    return 2;
                case 2:
                    return 3;
                case 3:
                    return 4;
                case 4:
                    return 6;
                case 5:
                    return 5;
                case 6:
                    return 6;
                default:
                    return 4;
            }
        }

        public static bool IsHeavyAtom(this OBAtom atom)
        {
            return !atom.IsHydrogen();
        }
    }
}
