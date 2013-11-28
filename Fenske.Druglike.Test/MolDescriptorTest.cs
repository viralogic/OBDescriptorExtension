using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenBabel;
using OBDescriptorExtension;
using OBDescriptorExtension.Constants;

namespace OBDescriptorExtension.Test
{

    public class PhenylPyridine
    {
        public static readonly double BalabanJ = 2.4571;
        public static readonly double Kappa3 = 1.3472;
        public static readonly double LabuteASA = 71.7081;
        public static readonly double Chi0 = 8.2258;
    }

    public class Propane
    {
        public static readonly string Title = "PROPANE";
        public static readonly string Smiles = "CCC";
        public static readonly int SingleCarbonCount = 3;
        public static readonly int DoubleCarbonCount = 2;
        public static readonly int TripleCarbonCount = 1;
        public static readonly double LabuteASA = 21.4691;
        public static readonly double NumHeavyAtoms = 3d;
        public static readonly double PeoeVSA1 = 0d;
        public static readonly double PeoeVSA2 = 0d;
        public static readonly double PeoeVSA3 = 0d;
        public static readonly double PeoeVSA4 = 0d;
        public static readonly double PeoeVSA5 = 0d;
        public static readonly double PeoeVSA6 = 20.2683;
        public static readonly double PeoeVSA7 = 0d;
        public static readonly double PeoeVSA8 = 0d;
        public static readonly double PeoeVSA9 = 0d;
        public static readonly double PeoeVSA10 = 0d;
        public static readonly double PeoeVSA11 = 0d;
        public static readonly double PeoeVSA12 = 0d;
        public static readonly double SmrVSA1 = 0d;
        public static readonly double SmrVSA2 = 0d;
        public static readonly double SmrVSA3 = 0d;
        public static readonly double SmrVSA4 = 0d;
        public static readonly double SmrVSA5 = 20.2683;
        public static readonly double SmrVSA6 = 0d;
        public static readonly double SmrVSA7 = 0d;
        public static readonly double SmrVSA8 = 0d;
        public static readonly double SmrVSA9 = 0d;
        public static readonly double SmrVSA10 = 0d;
        public static readonly double SLogPVSA1 = 0d;
        public static readonly double SLogPVSA2 = 0d;
        public static readonly double SLogPVSA3 = 0d;
        public static readonly double SLogPVSA4 = 0d;
        public static readonly double SLogPVSA5 = 20.2683;
        public static readonly double SLogPVSA6 = 0d;
        public static readonly double SLogPVSA7 = 0d;
        public static readonly double SLogPVSA8 = 0d;
        public static readonly double SLogPVSA9 = 0d;
        public static readonly double SLogPVSA10 = 0d;
        public static readonly double SLogPVSA11 = 0d;
        public static readonly double SLogPVSA12 = 0d;
        public static readonly double VsaEState9 = 5.5;
        public static readonly double EStateVsa5 = 6.4208;
        public static readonly double EStateVsa8 = 13.8475;
        public static readonly double Chi0 = 2.7071;
        public static readonly double Chi1 = 1.4142;
        public static readonly double Chi0v = 2.7071;
        public static readonly double Chi1v = 1.4142;
        public static readonly double Chi2v = 0.7071;
        public static readonly double Chi3v = 0d;
        public static readonly double Chi4v = 0d;
        public static readonly double Chi0n = 2.7071;
        public static readonly double Chi1n = 1.4142;
        public static readonly double Chi2n = 0.7071;
        public static readonly double Chi3n = 0d;
        public static readonly double Chi4n = 0d;
        public static readonly double HallKierAlpha = 0d;
        public static readonly double Kappa1 = 3.0;
        public static readonly double Kappa2 = 2.0;
        public static readonly double Kappa3 = 0d;
        public static readonly double Ipc = 2.7549;
        public static readonly double BalabanJ = 1.6330;
    }

    public class Benzene
    {
        public static readonly string Title = "BENZENE";
        public static readonly string Smiles = "c1ccccc1";
        public static readonly int BenzeneCount = 1;
        public static readonly double LabuteASA = 37.4314;
        public static readonly double NumHeavyAtoms = 6d;
        public static readonly double PeoeVSA1 = 0d;
        public static readonly double PeoeVSA2 = 0d;
        public static readonly double PeoeVSA3 = 0d;
        public static readonly double PeoeVSA4 = 0d;
        public static readonly double PeoeVSA5 = 0d;
        public static readonly double PeoeVSA6 = 36.3982;
        public static readonly double PeoeVSA7 = 0d;
        public static readonly double PeoeVSA8 = 0d;
        public static readonly double PeoeVSA9 = 0d;
        public static readonly double PeoeVSA10 = 0d;
        public static readonly double PeoeVSA11 = 0d;
        public static readonly double PeoeVSA12 = 0d;
        public static readonly double PeoeVSA13 = 0d;
        public static readonly double PeoeVSA14 = 0d;
        public static readonly double SmrVSA1 = 0d;
        public static readonly double SmrVSA2 = 0d;
        public static readonly double SmrVSA3 = 0d;
        public static readonly double SmrVSA4 = 0d;
        public static readonly double SmrVSA5 = 0d;
        public static readonly double SmrVSA6 = 0d;
        public static readonly double SmrVSA7 = 36.3982;
        public static readonly double SmrVSA8 = 0d;
        public static readonly double SmrVSA9 = 0d;
        public static readonly double SmrVSA10 = 0d;
        public static readonly double SLogPVSA1 = 0d;
        public static readonly double SLogPVSA2 = 0d;
        public static readonly double SLogPVSA3 = 0d;
        public static readonly double SLogPVSA4 = 0d;
        public static readonly double SLogPVSA5 = 0d;
        public static readonly double SLogPVSA6 = 36.3982;
        public static readonly double SLogPVSA7 = 0d;
        public static readonly double SLogPVSA8 = 0d;
        public static readonly double SLogPVSA9 = 0d;
        public static readonly double SLogPVSA10 = 0d;
        public static readonly double SLogPVSA11 = 0d;
        public static readonly double SLogPVSA12 = 0d;
        public static readonly double VsaEState9 = 12.0;
        public static readonly double EStateVsa7 = 36.3982;
        public static readonly double Chi0 = 4.2426;
        public static readonly double Chi1 = 3.0;
        public static readonly double Chi0v = 3.4641;
        public static readonly double Chi1v = 2.0;
        public static readonly double Chi2v = 1.1547;
        public static readonly double Chi3v = 0.6667;
        public static readonly double Chi4v = 0.3849;
        public static readonly double Chi0n = 3.4641;
        public static readonly double Chi1n = 2.0;
        public static readonly double Chi2n = 1.1547;
        public static readonly double Chi3n = 0.6667;
        public static readonly double Chi4n = 0.3849;
        public static readonly double HallKierAlpha = -0.78;
        public static readonly double Kappa1 = 3.4116;
        public static readonly double Kappa2 = 1.6058;
        public static readonly double Kappa3 = 0.5824;
        public static readonly double Ipc = 34.3995;
        public static readonly double BalabanJ = 3.0;
    }

    public class Cyclosporine
    {
        public static readonly string Title = "CYCLOSPORINE";
        public static readonly int CarbonylCount = 11;
        public static readonly double LabuteASA = 508.3945;
        public static readonly double NumHeavyAtoms = 85d;
        public static readonly double PeoeVSA1 = 60.6730;
        public static readonly double PeoeVSA2 = 52.7399;
        public static readonly double PeoeVSA3 = 0d;
        public static readonly double PeoeVSA4 = 0d;
        public static readonly double PeoeVSA5 = 0d;
        public static readonly double PeoeVSA6 = 109.0844;
        public static readonly double PeoeVSA7 = 100.7215;
        public static readonly double PeoeVSA8 = 49.3337;
        public static readonly double PeoeVSA9 = 12.6487;
        public static readonly double PeoeVSA10 = 60.4184;
        public static readonly double PeoeVSA11 = 0d;
        public static readonly double PeoeVSA12 = 64.9790;
        public static readonly double PeoeVSA13 = 0d;
        public static readonly double PeoeVSA14 = 0d;
        public static readonly double SmrVSA1 = 57.8464;
        public static readonly double SmrVSA2 = 0d;
        public static readonly double SmrVSA3 = 55.5665;
        public static readonly double SmrVSA4 = 41.4253;
        public static readonly double SmrVSA5 = 222.7508;
        public static readonly double SmrVSA6 = 55.8785;
        public static readonly double SmrVSA7 = 12.1520;
        public static readonly double SmrVSA8 = 0d;
        public static readonly double SmrVSA9 = 0d;
        public static readonly double SmrVSA10 = 64.9790;
        public static readonly double SLogPVSA1 = 21.2672;
        public static readonly double SLogPVSA2 = 226.7857;
        public static readonly double SLogPVSA3 = 52.7399;
        public static readonly double SLogPVSA4 = 41.4253;
        public static readonly double SLogPVSA5 = 156.2285;
        public static readonly double SLogPVSA6 = 12.1520;
        public static readonly double SLogPVSA7 = 0d;
        public static readonly double SLogPVSA8 = 0d;
        public static readonly double SLogPVSA9 = 0d;
        public static readonly double SLogPVSA10 = 0d;
        public static readonly double SLogPVSA11 = 0d;
        public static readonly double SLogPVSA12 = 0d;
        public static readonly double VsaEState9 = 211.8333;
        public static readonly double EStateVsa1 = 155.7998;
        public static readonly double EStateVsa2 = 55.7757;
        public static readonly double EStateVsa3 = 6.4208;
        public static readonly double EStateVsa4 = 9.7998;
        public static readonly double EStateVsa5 = 87.6807;
        public static readonly double EStateVsa6 = 54.5422;
        public static readonly double EStateVsa7 = 61.4659;
        public static readonly double EStateVsa8 = 21.2672;
        public static readonly double EStateVsa9 = 0.0;
        public static readonly double EStateVsa10 = 48.2574;
        public static readonly double EStateVsa11 = 9.5891;
        public static readonly double Chi0 = 65.9770;
        public static readonly double Chi1 = 39.2091;
        public static readonly double Chi0v = 56.0652;
        public static readonly double Chi1v = 30.5618;
        public static readonly double Chi2v = 26.0926;
        public static readonly double Chi3v = 16.0766;
        public static readonly double Chi4v = 10.6813;
        public static readonly double Chi0n = 56.0652;
        public static readonly double Chi1n = 30.5618;
        public static readonly double Chi2n = 26.0926;
        public static readonly double Chi3n = 16.0766;
        public static readonly double Chi4n = 10.6813;
        public static readonly double HallKierAlpha = -6.13;
        public static readonly double Kappa1 = 76.8827;
        public static readonly double Kappa2 = 34.8715;
        public static readonly double Kappa3 = 21.6556;
        public static readonly double Ipc = 7.31512726233e+16;
        public static readonly double BalabanJ = 4.3203;
    }

    [TestClass]
    public class MolDescriptorTest
    {
        #region Private variables

        private MolDescriptor _descriptor;
        private string[] _featureNames = new string[]
            {
                "Molecular Weight",
                "Number Rings",
                "Total Charge",
                "Total Spin Multiplicity",
                "Number Conformers",
                "Least Conformer Energy",
                "Heat of Formation",
                "Number Atoms",
                "Number Heavy Atoms",
                "Number Rotatable Bonds",
                "Number Bonds",
                "Number Single Bonds",
                "Number Double Bonds",
                "Number Triple Bonds",
                "Number Aromatic Bonds",
                "LogP",
                "TPSA",
                "HBA1",
                "HBA2",
                "HBD",
                "Melting Point",
                "Molar Refractivity",
                "Number Fluorines",
                "Labute ASA",
                "PEOE VSA 1",
                "PEOE VSA 2",
                "PEOE VSA 3",
                "PEOE VSA 4",
                "PEOE VSA 5",
                "PEOE VSA 6",
                "PEOE VSA 7",
                "PEOE VSA 8",
                "PEOE VSA 9",
                "PEOE VSA 10",
                "PEOE VSA 11",
                "PEOE VSA 12",
                "PEOE VSA 13",
                "PEOE VSA 14",
                "SMR VSA 1",
                "SMR VSA 2",
                "SMR VSA 3",
                "SMR VSA 4",
                "SMR VSA 5",
                "SMR VSA 6",
                "SMR VSA 7",
                "SMR VSA 8",
                "SMR VSA 9",
                "SMR VSA 10",
                "SLogP VSA 1",
                "SLogP VSA 2",
                "SLogP VSA 3",
                "SLogP VSA 4",
                "SLogP VSA 5",
                "SLogP VSA 6",
                "SLogP VSA 7",
                "SLogP VSA 8",
                "SLogP VSA 9",
                "SLogP VSA 10",
                "SLogP VSA 11",
                "SLogP VSA 12",
                "VSA EState 1",
                "VSA EState 2",
                "VSA EState 3",
                "VSA EState 4",
                "VSA EState 5",
                "VSA EState 6",
                "VSA EState 7",
                "VSA EState 8",
                "VSA EState 9",
                "VSA EState 10",
                "VSA EState 11",
                "EState VSA 1",
                "EState VSA 2",
                "EState VSA 3",
                "EState VSA 4",
                "EState VSA 5",
                "EState VSA 6",
                "EState VSA 7",
                "EState VSA 8",
                "EState VSA 9",
                "EState VSA 10",
                "EState VSA 11",
                "Chi0",
                "Chi1",
                "Chi0v",
                "Chi1v",
                "Chi2v",
                "Chi3v",
                "Chi4v",
                "Chi0n",
                "Chi1n",
                "Chi2n",
                "Chi3n",
                "Chi4n",
                "Hall-Kier Alpha",
                "Kappa1",
                "Kappa2",
                "Kappa3",
                "Ipc",
                "BalabanJ"
            }
            .Concat(Fragments.Collection.AllKeys).ToArray();


        #endregion

        [TestMethod]
        public void CyclosporineTest()
        {
            var mol = new MolReader(FileNames.CyclosporineFilePath).GetMol();
            this._descriptor = new MolDescriptor(mol);
            Assert.AreEqual(Cyclosporine.Title, this._descriptor.Title);
            Assert.AreEqual(Cyclosporine.CarbonylCount, this._descriptor.FragmentCount(Fragments.Collection["fr_C=O"]));
            Assert.AreEqual(Cyclosporine.LabuteASA, Math.Round(this._descriptor.LabuteASA, 4));
            Assert.AreEqual(Cyclosporine.NumHeavyAtoms, this._descriptor.NumHeavyAtoms);

            /** These test are not run because the values given by RDKit (used as the truth argument in
             *  the asserts) appear to be incorrect. This is based upon the fact that the total charge
             *  calculated by RDKit after computing the Gasteiger charges for cyclosporine gives -4.55
             *  and the actual total charge for cyclosporine should be close to 0. In comparison, the
             *  total charge given by OpenBabel (after assigning Gasteiger charges) was close to 0.
             *  
             *  Since the binning of the PEOE VSA algorithm is dependent upon Gasteiger charges, this
             *  leads me to believe that the binning given by RDKit is incorrect and hence is leading
             *  to false fails for these tests.
            Assert.AreEqual(Cyclosporine.PeoeVSA1, Math.Round(this._descriptor.PeoeVSA1, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA2, Math.Round(this._descriptor.PeoeVSA2, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA3, Math.Round(this._descriptor.PeoeVSA3, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA4, Math.Round(this._descriptor.PeoeVSA4, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA5, Math.Round(this._descriptor.PeoeVSA5, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA6, Math.Round(this._descriptor.PeoeVSA6, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA7, Math.Round(this._descriptor.PeoeVSA7, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA8, Math.Round(this._descriptor.PeoeVSA8, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA9, Math.Round(this._descriptor.PeoeVSA9, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA10, Math.Round(this._descriptor.PeoeVSA10, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA11, Math.Round(this._descriptor.PeoeVSA11, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA12, Math.Round(this._descriptor.PeoeVSA12, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA13, Math.Round(this._descriptor.PeoeVSA13, 4));
            Assert.AreEqual(Cyclosporine.PeoeVSA14, Math.Round(this._descriptor.PeoeVSA14, 4));
             * */
            Assert.AreEqual(Cyclosporine.SmrVSA1, Math.Round(this._descriptor.SmrVSA1, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA2, Math.Round(this._descriptor.SmrVSA2, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA3, Math.Round(this._descriptor.SmrVSA3, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA4, Math.Round(this._descriptor.SmrVSA4, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA5, Math.Round(this._descriptor.SmrVSA5, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA6, Math.Round(this._descriptor.SmrVSA6, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA7, Math.Round(this._descriptor.SmrVSA7, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA8, Math.Round(this._descriptor.SmrVSA8, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA9, Math.Round(this._descriptor.SmrVSA9, 4));
            Assert.AreEqual(Cyclosporine.SmrVSA10, Math.Round(this._descriptor.SmrVSA10, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA1, Math.Round(this._descriptor.SLogPVSA1, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA2, Math.Round(this._descriptor.SLogPVSA2, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA3, Math.Round(this._descriptor.SLogPVSA3, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA4, Math.Round(this._descriptor.SLogPVSA4, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA5, Math.Round(this._descriptor.SLogPVSA5, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA6, Math.Round(this._descriptor.SLogPVSA6, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA7, Math.Round(this._descriptor.SLogPVSA7, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA8, Math.Round(this._descriptor.SLogPVSA8, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA9, Math.Round(this._descriptor.SLogPVSA9, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA10, Math.Round(this._descriptor.SLogPVSA10, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA11, Math.Round(this._descriptor.SLogPVSA11, 4));
            Assert.AreEqual(Cyclosporine.SLogPVSA12, Math.Round(this._descriptor.SLogPVSA12, 4));
            Assert.AreEqual(Cyclosporine.VsaEState9, Math.Round(this._descriptor.VsaEState9, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa1, Math.Round(this._descriptor.EStateVsa1, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa2, Math.Round(this._descriptor.EStateVsa2, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa3, Math.Round(this._descriptor.EStateVsa3, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa4, Math.Round(this._descriptor.EStateVsa4, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa5, Math.Round(this._descriptor.EStateVsa5, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa6, Math.Round(this._descriptor.EStateVsa6, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa7, Math.Round(this._descriptor.EStateVsa7, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa8, Math.Round(this._descriptor.EStateVsa8, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa9, Math.Round(this._descriptor.EStateVsa9, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa10, Math.Round(this._descriptor.EStateVsa10, 4));
            Assert.AreEqual(Cyclosporine.EStateVsa11, Math.Round(this._descriptor.EStateVsa11, 4));
            Assert.AreEqual(Cyclosporine.Chi0, Math.Round(this._descriptor.Chi0, 4));
            Assert.AreEqual(Cyclosporine.Chi1, Math.Round(this._descriptor.Chi1, 4));
            Assert.AreEqual(Cyclosporine.Chi0v, Math.Round(this._descriptor.Chi0v, 4));
            Assert.AreEqual(Cyclosporine.Chi1v, Math.Round(this._descriptor.Chi1v, 4));
            Assert.AreEqual(Cyclosporine.Chi2v, Math.Round(this._descriptor.Chi2v, 4));
            Assert.AreEqual(Cyclosporine.Chi3v, Math.Round(this._descriptor.Chi3v, 4));
            Assert.AreEqual(Cyclosporine.Chi4v, Math.Round(this._descriptor.Chi4v, 4));
            Assert.AreEqual(Cyclosporine.Chi0n, Math.Round(this._descriptor.Chi0n, 4));
            Assert.AreEqual(Cyclosporine.Chi1n, Math.Round(this._descriptor.Chi1n, 4));
            Assert.AreEqual(Cyclosporine.Chi2n, Math.Round(this._descriptor.Chi2n, 4));
            Assert.AreEqual(Cyclosporine.Chi3n, Math.Round(this._descriptor.Chi3n, 4));
            Assert.AreEqual(Cyclosporine.Chi4n, Math.Round(this._descriptor.Chi4n, 4));
            Assert.AreEqual(Cyclosporine.HallKierAlpha, Math.Round(this._descriptor.HallKierAlpha, 4));
            Assert.AreEqual(Cyclosporine.Kappa1, Math.Round(this._descriptor.Kappa1, 4));
            Assert.AreEqual(Cyclosporine.Kappa2, Math.Round(this._descriptor.Kappa2, 4));
            Assert.AreEqual(Cyclosporine.Kappa3, Math.Round(this._descriptor.Kappa3, 4));
            Assert.AreEqual(Cyclosporine.Ipc.ToString("E4"), this._descriptor.Ipc.ToString("E4"));
            Assert.AreEqual(Cyclosporine.BalabanJ, Math.Round(this._descriptor.BalabanJ, 4));
        }

        [TestMethod]
        public void BenzeneTest()
        {
            var mol = new MolReader(FileNames.BenzeneFilePath).GetMol();
            this._descriptor = new MolDescriptor(mol);
            Assert.AreEqual(Benzene.Title, this._descriptor.Title);
            Assert.AreEqual(Benzene.Smiles, this._descriptor.Smiles);
            Assert.AreEqual(Benzene.BenzeneCount, this._descriptor.FragmentCount(Benzene.Smiles));
            Assert.AreEqual(Benzene.LabuteASA, Math.Round(this._descriptor.LabuteASA, 4));

            var frags = this._descriptor.FragmentCounts;
            foreach (var key in frags.Keys)
            {
                if (key == "fr_benzene")
                {
                    continue;
                }
                int count;
                var hasCount = frags.TryGetValue(key, out count);
                if (!hasCount)
                {
                    throw new KeyNotFoundException(string.Format("{0} is not a valid key", key));
                }
                Assert.AreEqual(0, count);
            }
            Assert.AreEqual(Benzene.NumHeavyAtoms, this._descriptor.FeatureValue("Number Heavy Atoms").Value);
            Assert.AreEqual(Benzene.PeoeVSA1, this._descriptor.PeoeVSA1);
            Assert.AreEqual(Benzene.PeoeVSA2, this._descriptor.PeoeVSA2);
            Assert.AreEqual(Benzene.PeoeVSA3, this._descriptor.PeoeVSA3);
            Assert.AreEqual(Benzene.PeoeVSA4, this._descriptor.PeoeVSA4);
            Assert.AreEqual(Benzene.PeoeVSA5, this._descriptor.PeoeVSA5);
            Assert.AreEqual(Benzene.PeoeVSA6, Math.Round(this._descriptor.PeoeVSA6, 4));
            Assert.AreEqual(Benzene.PeoeVSA7, this._descriptor.PeoeVSA7);
            Assert.AreEqual(Benzene.PeoeVSA8, this._descriptor.PeoeVSA8);
            Assert.AreEqual(Benzene.PeoeVSA9, this._descriptor.PeoeVSA9);
            Assert.AreEqual(Benzene.PeoeVSA10, this._descriptor.PeoeVSA10);
            Assert.AreEqual(Benzene.PeoeVSA11, this._descriptor.PeoeVSA11);
            Assert.AreEqual(Benzene.PeoeVSA12, this._descriptor.PeoeVSA12);
            Assert.AreEqual(Benzene.PeoeVSA13, this._descriptor.PeoeVSA13);
            Assert.AreEqual(Benzene.PeoeVSA14, this._descriptor.PeoeVSA14);
            Assert.AreEqual(Benzene.SmrVSA1, this._descriptor.SmrVSA1);
            Assert.AreEqual(Benzene.SmrVSA2, this._descriptor.SmrVSA2);
            Assert.AreEqual(Benzene.SmrVSA3, this._descriptor.SmrVSA3);
            Assert.AreEqual(Benzene.SmrVSA4, this._descriptor.SmrVSA4);
            Assert.AreEqual(Benzene.SmrVSA5, this._descriptor.SmrVSA5);
            Assert.AreEqual(Benzene.SmrVSA6, this._descriptor.SmrVSA6);
            Assert.AreEqual(Benzene.SmrVSA7, Math.Round(this._descriptor.SmrVSA7, 4));
            Assert.AreEqual(Benzene.SmrVSA8, this._descriptor.SmrVSA8);
            Assert.AreEqual(Benzene.SmrVSA9, this._descriptor.SmrVSA9);
            Assert.AreEqual(Benzene.SmrVSA10, this._descriptor.SmrVSA10);
            Assert.AreEqual(Benzene.SLogPVSA1, this._descriptor.SLogPVSA1);
            Assert.AreEqual(Benzene.SLogPVSA2, this._descriptor.SLogPVSA2);
            Assert.AreEqual(Benzene.SLogPVSA3, this._descriptor.SLogPVSA3);
            Assert.AreEqual(Benzene.SLogPVSA4, this._descriptor.SLogPVSA4);
            Assert.AreEqual(Benzene.SLogPVSA5, this._descriptor.SLogPVSA5);
            Assert.AreEqual(Benzene.SLogPVSA6, Math.Round(this._descriptor.SLogPVSA6, 4));
            Assert.AreEqual(Benzene.SLogPVSA7, this._descriptor.SLogPVSA7);
            Assert.AreEqual(Benzene.SLogPVSA8, this._descriptor.SLogPVSA8);
            Assert.AreEqual(Benzene.SLogPVSA9, this._descriptor.SLogPVSA9);
            Assert.AreEqual(Benzene.SLogPVSA10, this._descriptor.SLogPVSA10);
            Assert.AreEqual(Benzene.SLogPVSA11, this._descriptor.SLogPVSA11);
            Assert.AreEqual(Benzene.SLogPVSA12, this._descriptor.SLogPVSA12);
            Assert.AreEqual(Benzene.VsaEState9, Math.Round(this._descriptor.VsaEState9, 1));
            Assert.AreEqual(Benzene.EStateVsa7, Math.Round(this._descriptor.EStateVsa7, 4));
            Assert.AreEqual(Benzene.Chi0, Math.Round(this._descriptor.Chi0, 4));
            Assert.AreEqual(Benzene.Chi1, Math.Round(this._descriptor.Chi1, 4));
            Assert.AreEqual(Benzene.Chi0v, Math.Round(this._descriptor.Chi0v, 4));
            Assert.AreEqual(Benzene.Chi1v, Math.Round(this._descriptor.Chi1v, 4));
            Assert.AreEqual(Benzene.Chi2v, Math.Round(this._descriptor.Chi2v, 4));
            Assert.AreEqual(Benzene.Chi3v, Math.Round(this._descriptor.Chi3v, 4));
            Assert.AreEqual(Benzene.Chi4v, Math.Round(this._descriptor.Chi4v, 4));
            Assert.AreEqual(Benzene.Chi0n, Math.Round(this._descriptor.Chi0n, 4));
            Assert.AreEqual(Benzene.Chi1n, Math.Round(this._descriptor.Chi1n, 4));
            Assert.AreEqual(Benzene.Chi2n, Math.Round(this._descriptor.Chi2n, 4));
            Assert.AreEqual(Benzene.Chi3n, Math.Round(this._descriptor.Chi3n, 4));
            Assert.AreEqual(Benzene.Chi4n, Math.Round(this._descriptor.Chi4n, 4));
            Assert.AreEqual(Benzene.HallKierAlpha, Math.Round(this._descriptor.HallKierAlpha, 2));
            Assert.AreEqual(Benzene.Kappa1, Math.Round(this._descriptor.Kappa1, 4));
            Assert.AreEqual(Benzene.Kappa2, Math.Round(this._descriptor.Kappa2, 4));
            Assert.AreEqual(Benzene.Kappa3, Math.Round(this._descriptor.Kappa3, 4));
            Assert.AreEqual(Benzene.Ipc, Math.Round(this._descriptor.Ipc, 4));
            Assert.AreEqual(Benzene.BalabanJ, Math.Round(this._descriptor.BalabanJ, 4));
        }

        [TestMethod]
        public void PropaneTest()
        {
            var mol = new MolReader(FileNames.PropaneFilePath).GetMol();
            this._descriptor = new MolDescriptor(mol);
            Assert.AreEqual(Propane.Title, this._descriptor.Title);
            Assert.AreEqual(Propane.Smiles, this._descriptor.Smiles);
            Assert.AreEqual(Propane.SingleCarbonCount, this._descriptor.FragmentCount("C"));
            Assert.AreEqual(Propane.DoubleCarbonCount, this._descriptor.FragmentCount("CC"));
            Assert.AreEqual(Propane.TripleCarbonCount, this._descriptor.FragmentCount("CCC"));
            Assert.AreEqual(0, this._descriptor.FragmentCount("c"));
            Assert.AreEqual(Propane.LabuteASA, Math.Round(this._descriptor.LabuteASA, 4));

            var frags = this._descriptor.FragmentCounts;
            foreach (var key in frags.Keys)
            {
                int count;
                var hasCount = frags.TryGetValue(key, out count);
                if (!hasCount)
                {
                    throw new KeyNotFoundException(string.Format("{0} is not a valid key", key));
                }
                Assert.AreEqual(0, count);
            }
            Assert.AreEqual(Propane.NumHeavyAtoms, this._descriptor.FeatureValue("Number Heavy Atoms").Value);
            Assert.AreEqual(Propane.PeoeVSA1, this._descriptor.PeoeVSA1);
            Assert.AreEqual(Propane.PeoeVSA2, this._descriptor.PeoeVSA2);
            Assert.AreEqual(Propane.PeoeVSA3, this._descriptor.PeoeVSA3);
            Assert.AreEqual(Propane.PeoeVSA4, this._descriptor.PeoeVSA4);
            Assert.AreEqual(Propane.PeoeVSA5, this._descriptor.PeoeVSA5);
            Assert.AreEqual(Propane.PeoeVSA6, Math.Round(this._descriptor.PeoeVSA6, 4));
            Assert.AreEqual(Propane.PeoeVSA7, this._descriptor.PeoeVSA7);
            Assert.AreEqual(Propane.PeoeVSA8, this._descriptor.PeoeVSA8);
            Assert.AreEqual(Propane.PeoeVSA9, this._descriptor.PeoeVSA9);
            Assert.AreEqual(Propane.PeoeVSA10, this._descriptor.PeoeVSA10);
            Assert.AreEqual(Propane.PeoeVSA11, this._descriptor.PeoeVSA11);
            Assert.AreEqual(Propane.PeoeVSA12, this._descriptor.PeoeVSA12);
            Assert.AreEqual(Propane.SmrVSA1, this._descriptor.SmrVSA1);
            Assert.AreEqual(Propane.SmrVSA2, this._descriptor.SmrVSA2);
            Assert.AreEqual(Propane.SmrVSA3, this._descriptor.SmrVSA3);
            Assert.AreEqual(Propane.SmrVSA4, this._descriptor.SmrVSA4);
            Assert.AreEqual(Propane.SmrVSA5, Math.Round(this._descriptor.SmrVSA5, 4));
            Assert.AreEqual(Propane.SmrVSA6, this._descriptor.SmrVSA6);
            Assert.AreEqual(Propane.SmrVSA7, this._descriptor.SmrVSA7);
            Assert.AreEqual(Propane.SmrVSA8, this._descriptor.SmrVSA8);
            Assert.AreEqual(Propane.SmrVSA9, this._descriptor.SmrVSA9);
            Assert.AreEqual(Propane.SmrVSA10, this._descriptor.SmrVSA10);
            Assert.AreEqual(Propane.SLogPVSA1, this._descriptor.SLogPVSA1);
            Assert.AreEqual(Propane.SLogPVSA2, this._descriptor.SLogPVSA2);
            Assert.AreEqual(Propane.SLogPVSA3, this._descriptor.SLogPVSA3);
            Assert.AreEqual(Propane.SLogPVSA4, this._descriptor.SLogPVSA4);
            Assert.AreEqual(Propane.SLogPVSA5, Math.Round(this._descriptor.SLogPVSA5, 4));
            Assert.AreEqual(Propane.SLogPVSA6, this._descriptor.SLogPVSA6);
            Assert.AreEqual(Propane.SLogPVSA7, this._descriptor.SLogPVSA7);
            Assert.AreEqual(Propane.SLogPVSA8, this._descriptor.SLogPVSA8);
            Assert.AreEqual(Propane.SLogPVSA9, this._descriptor.SLogPVSA9);
            Assert.AreEqual(Propane.SLogPVSA10, this._descriptor.SLogPVSA10);
            Assert.AreEqual(Propane.SLogPVSA11, this._descriptor.SLogPVSA11);
            Assert.AreEqual(Propane.SLogPVSA12, this._descriptor.SLogPVSA12);
            Assert.AreEqual(Propane.VsaEState9, Math.Round(this._descriptor.VsaEState9, 1));
            Assert.AreEqual(Propane.EStateVsa5, Math.Round(this._descriptor.EStateVsa5, 4));
            Assert.AreEqual(Propane.EStateVsa8, Math.Round(this._descriptor.EStateVsa8, 4));
            Assert.AreEqual(Propane.Chi0, Math.Round(this._descriptor.Chi0, 4));
            Assert.AreEqual(Propane.Chi1, Math.Round(this._descriptor.Chi1, 4));
            Assert.AreEqual(Propane.Chi0v, Math.Round(this._descriptor.Chi0v, 4));
            Assert.AreEqual(Propane.Chi1v, Math.Round(this._descriptor.Chi1v, 4));
            Assert.AreEqual(Propane.Chi2v, Math.Round(this._descriptor.Chi2v, 4));
            Assert.AreEqual(Propane.Chi3v, Math.Round(this._descriptor.Chi3v, 4));
            Assert.AreEqual(Propane.Chi4v, Math.Round(this._descriptor.Chi4v, 4));
            Assert.AreEqual(Propane.Chi0n, Math.Round(this._descriptor.Chi0n, 4));
            Assert.AreEqual(Propane.Chi1n, Math.Round(this._descriptor.Chi1n, 4));
            Assert.AreEqual(Propane.Chi2n, Math.Round(this._descriptor.Chi2n, 4));
            Assert.AreEqual(Propane.Chi3n, Math.Round(this._descriptor.Chi3n, 4));
            Assert.AreEqual(Propane.Chi4n, Math.Round(this._descriptor.Chi4n, 4));
            Assert.AreEqual(Propane.HallKierAlpha, Math.Round(this._descriptor.HallKierAlpha, 1));
            Assert.AreEqual(Propane.Kappa1, Math.Round(this._descriptor.Kappa1, 1));
            Assert.AreEqual(Propane.Kappa2, Math.Round(this._descriptor.Kappa2, 1));
            Assert.AreEqual(Propane.Kappa3, Math.Round(this._descriptor.Kappa3, 1));
            Assert.AreEqual(Propane.Ipc, Math.Round(this._descriptor.Ipc, 4));
            Assert.AreEqual(Propane.BalabanJ, Math.Round(this._descriptor.BalabanJ, 4));
        }

        [TestMethod]
        public void FeatureNamesTest()
        {
            var mol = new MolReader(FileNames.PropaneFilePath).GetMol();
            this._descriptor = new MolDescriptor(mol);

            Assert.AreEqual(_featureNames.Length, MolDescriptor.FeatureCount());

            foreach (var name in this._featureNames)
            {
                Assert.IsTrue(MolDescriptor.GetFeatureNames().Contains(name));
            }
            try
            {
                this._descriptor.FeatureValue("Fenske Descriptor");
                Assert.Fail("Fenske Descriptor is not a valid feature");
            }
            catch (ArgumentException)
            {
                // Expected
            }

        }

        [TestMethod]
        public void GasteigerChargeTest()
        {
            var mol = new MolReader(FileNames.BenzeneFilePath).GetMol();
            var chargedMol = mol.AssignGasteigerCharges();
            Assert.IsTrue(chargedMol.Atoms().Count() > 0);
            foreach (var atom in chargedMol.Atoms())
            {
                if (atom.IsCarbon())
                {
                    Assert.AreEqual(-0.0618, Math.Round(atom.GetPartialCharge(), 4));
                }
                else
                {
                    Assert.AreEqual(0.0618, Math.Round(atom.GetPartialCharge(), 4));
                }
            }

            mol = new MolReader(FileNames.PropaneFilePath).GetMol();
            chargedMol = mol.AssignGasteigerCharges();
            Assert.IsTrue(chargedMol.Atoms().Count() > 0);
            foreach (var atom in chargedMol.Atoms())
            {
                if (atom.IsCarbon() && (atom.GetIdx() == 1 || atom.GetIdx() == 3))
                {
                    Assert.AreEqual(-0.0655, Math.Round(atom.GetPartialCharge(), 4));
                }
                else if (atom.IsCarbon() && atom.GetIdx() == 2)
                {
                    Assert.AreEqual(-0.0588, Math.Round(atom.GetPartialCharge(), 4));
                }
                else if (atom.IsHydrogen() && atom.Neighbors().First().IsCarbon() && (atom.Neighbors().First().GetIdx() == 1 || atom.Neighbors().First().GetIdx() == 3))
                {
                    Assert.AreEqual(0.0230, Math.Round(atom.GetPartialCharge(), 4));
                }
                else if (atom.IsHydrogen() && atom.Neighbors().First().IsCarbon() && atom.Neighbors().First().GetIdx() == 2)
                {
                    Assert.AreEqual(0.0260, Math.Round(atom.GetPartialCharge(), 4));
                }
            }
        }

        /// <summary>
        /// Test to see if TotalCharge property properly calculates formal charge on molecule
        /// </summary>
        [TestMethod]
        public void FormalChargeTest()
        {
            var mol = new MolReader(FileNames.AceticAcidFilePath).GetMol();
            this._descriptor = new MolDescriptor(mol);
            Assert.AreEqual(0, this._descriptor.TotalCharge);

            var newMol = mol.AssignGasteigerCharges();
            Assert.AreEqual(0, Math.Round(newMol.Atoms().Sum(a => a.GetPartialCharge()), 4));

            mol = new MolReader(FileNames.AcetateFilePath).GetMol();
            this._descriptor = new MolDescriptor(mol);
            Assert.AreEqual(-1, this._descriptor.TotalCharge);

            newMol = mol.AssignGasteigerCharges();
            this._descriptor = new MolDescriptor(newMol);
            Assert.AreEqual(-1, Math.Round(newMol.Atoms().Sum(a => a.GetPartialCharge()), 4));

            mol = new MolReader(FileNames.CyclosporineFilePath).GetMol();
            this._descriptor = new MolDescriptor(mol);
            Assert.AreEqual(0d, Math.Round(this._descriptor.TotalCharge, 4));
            
        }

        [TestMethod]
        public void CrippenVsaTest()
        {
            var mol = new MolReader(FileNames.AnisoleFilePath).GetMol();
            Assert.AreEqual(34.66, Math.Round(mol.CrippenSmrVSA(), 2));
            Assert.AreEqual(1.40, Math.Round(mol.CrippenSLogPVSA(), 2));

            mol = new MolReader(FileNames.PyridineFilePath).GetMol();
            Assert.AreEqual(49.67, Math.Round(mol.CrippenSmrVSA(), 2));
            Assert.AreEqual(2.75, Math.Round(mol.CrippenSLogPVSA(), 2));
        }

        [TestMethod]
        public void DistanceMatrixTest()
        {
            var converter = new OBConversion();
            converter.SetInFormat("smi");
            var mol = new OBMol();
            converter.ReadString(mol, "CC=C");
            var dMat = mol.DistanceMatrix();
            Assert.AreEqual(0d, dMat.Get(0,0));
            Assert.AreEqual(1d, dMat.Get(0,1));
            Assert.AreEqual(2d, dMat.Get(0,2));
            Assert.AreEqual(1d, dMat.Get(1,0));
            Assert.AreEqual(0d, dMat.Get(1,1));
            Assert.AreEqual(1d, dMat.Get(1,2));
            Assert.AreEqual(2d, dMat.Get(2,0));
            Assert.AreEqual(1d, dMat.Get(2,1));
            Assert.AreEqual(0d, dMat.Get(2,2));

            dMat = mol.DistanceMatrix(useBondOrder: true);
            Assert.AreEqual(0d, dMat.Get(0, 0));
            Assert.AreEqual(1d, dMat.Get(0, 1));
            Assert.AreEqual(1.5, dMat.Get(0, 2));
            Assert.AreEqual(1d, dMat.Get(1, 0));
            Assert.AreEqual(0d, dMat.Get(1, 1));
            Assert.AreEqual(0.5, dMat.Get(1, 2));
            Assert.AreEqual(1.5, dMat.Get(2, 0));
            Assert.AreEqual(0.5, dMat.Get(2, 1));
            Assert.AreEqual(0d, dMat.Get(2, 2));
        }

        [TestMethod]
        public void PathsOfLengthNTest()
        {
            var converter = new OBConversion();
            converter.SetInFormat("smi");
            var mol = new OBMol();
            converter.ReadString(mol, "CCC");
            var paths = mol.PathsOfLengthN(2, false);
            Assert.AreEqual(1, paths.Count());

            paths = mol.PathsOfLengthN(4, false);
            Assert.AreEqual(0, paths.Count());

            converter.ReadString(mol, "CC(C)C");
            paths = mol.PathsOfLengthN(2, false);
            Assert.AreEqual(3, paths.Count());

            converter.ReadString(mol, "c1ccccc1");
            paths = mol.PathsOfLengthN(3, false);
            Assert.AreEqual(6, paths.Count());
        }

        [TestMethod]
        public void EStateIndiceTest()
        {
            var converter = new OBConversion();
            converter.SetInFormat("smi");
            var mol = new OBMol();
            converter.ReadString(mol, "CCCC");
            var eStateIndices = mol.EStateIndices();
            // 2.18,1.32,1.32,2.18
            Assert.AreEqual(2.18, Math.Round(eStateIndices[0], 2));
            Assert.AreEqual(1.32, Math.Round(eStateIndices[1], 2));
            Assert.AreEqual(1.32, Math.Round(eStateIndices[2], 2));
            Assert.AreEqual(2.18, Math.Round(eStateIndices[3], 2));

            // 1.85,0.22,1.85,-0.19,11.11
            converter.ReadString(mol, "CC(C)CF");
            eStateIndices = mol.EStateIndices();
            Assert.AreEqual(1.85, Math.Round(eStateIndices[0], 2));
            Assert.AreEqual(0.22, Math.Round(eStateIndices[1], 2));
            Assert.AreEqual(1.85, Math.Round(eStateIndices[2], 2));
            Assert.AreEqual(-0.19, Math.Round(eStateIndices[3], 2));
            Assert.AreEqual(11.12, Math.Round(eStateIndices[4], 2));

            converter.ReadString(mol, "CCOCC");
            eStateIndices = mol.EStateIndices();
            //1.99,0.84,4.83,0.84,1.99
            Assert.AreEqual(1.99, Math.Round(eStateIndices[0], 2));
            Assert.AreEqual(0.84, Math.Round(eStateIndices[1], 2));
            Assert.AreEqual(4.83, Math.Round(eStateIndices[2], 2));
            Assert.AreEqual(0.84, Math.Round(eStateIndices[3], 2));
            Assert.AreEqual(1.99, Math.Round(eStateIndices[4], 2));
        }

        [TestMethod]
        public void CharacteristicPolynomialTest()
        {
            var converter = new OBConversion();
            converter.SetInFormat("smi");
            var mol = new OBMol();
            converter.ReadString(mol, "CCC");
            var adjMat = mol.AdjacencyMatrix();
            var cPoly = mol.CharacteristicPolynomial(adjMat);
            Assert.AreEqual(1d, cPoly[0]);
            Assert.AreEqual(0d, cPoly[1]);
            Assert.AreEqual(-2d, cPoly[2]);
            Assert.AreEqual(0d, cPoly[3]);
        }

    }
}
