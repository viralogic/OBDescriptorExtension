using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OBDescriptorExtension.Test
{
    [TestClass]
    public class MolDescriptorSetTest
    {
        #region Private

        private MolDescriptorSet _molSet;

        #endregion 


        [TestInitialize]
        public void TestSetup()
        {
            var propane = new MolReader(FileNames.PropaneFilePath).GetMol();
            var benzene = new MolReader(FileNames.BenzeneFilePath).GetMol();
            var cyclosporin = new MolReader(FileNames.CyclosporineFilePath).GetMol();
            this._molSet = new MolDescriptorSet(new List<MolDescriptor> { new MolDescriptor(propane), new MolDescriptor(benzene), new MolDescriptor(cyclosporin) });
        }

        [TestCleanup]
        public void TestTearDown()
        {
            this._molSet = null;
        }

        [TestMethod]
        public void FromFileTest()
        {
            var mols = MolDescriptorSet.FromFile(FileNames.MultiMolFilePath);
            Assert.AreEqual(1597, mols.NumMols);
        }

        [TestMethod]
        public void HasMolsTest()
        {
            Assert.IsTrue(this._molSet.HasMols);
            this._molSet = new MolDescriptorSet(new List<MolDescriptor>());
            Assert.IsFalse(this._molSet.HasMols);
        }

        [TestMethod]
        public void AverageTest()
        {
            var aveBalabanJ = (Propane.BalabanJ + Benzene.BalabanJ + Cyclosporine.BalabanJ) / 3;
            Assert.AreEqual(Math.Round(aveBalabanJ, 4), Math.Round(this._molSet.Average("BalabanJ"), 4));

            var aveKappa3 = (Propane.Kappa3 + Benzene.Kappa3 + Cyclosporine.Kappa3) / 3;
            Assert.AreEqual(Math.Round(aveKappa3, 4), Math.Round(this._molSet.Average("Kappa3"), 4));

            var aveKappa2 = (Propane.Kappa2 + Benzene.Kappa2 + Cyclosporine.Kappa2) / 3;
            Assert.AreEqual(Math.Round(aveKappa2, 4), Math.Round(this._molSet.Average("Kappa2"), 4));

            var aveChi0 = (Propane.Chi0 + Propane.Chi0 + Cyclosporine.Chi0) / 3;
            Assert.AreEqual(Math.Round(aveChi0, 0), Math.Round(this._molSet.Average("Chi0"), 0));
        }

        [TestMethod]
        public void MaxTest()
        {
            Assert.AreEqual(Cyclosporine.BalabanJ, Math.Round(this._molSet.Max("BalabanJ"), 4));
            Assert.AreEqual(Cyclosporine.Kappa3, Math.Round(this._molSet.Max("Kappa3"), 4));
            Assert.AreEqual(Cyclosporine.LabuteASA, Math.Round(this._molSet.Max("Labute ASA"), 4));
            Assert.AreEqual(Cyclosporine.Chi0, Math.Round(this._molSet.Max("Chi0"), 4));
        }

        [TestMethod]
        public void MinTest()
        {
            Assert.AreEqual(Propane.BalabanJ, Math.Round(this._molSet.Min("BalabanJ"), 4));
            Assert.AreEqual(Propane.Kappa3, Math.Round(this._molSet.Min("Kappa3"), 4));
            Assert.AreEqual(Propane.LabuteASA, Math.Round(this._molSet.Min("Labute ASA"), 4));
            Assert.AreEqual(Propane.Chi0, Math.Round(this._molSet.Min("Chi0"), 4));
        }

        [TestMethod]
        public void MedianTest()
        {
            Assert.AreEqual(Benzene.BalabanJ, Math.Round(this._molSet.Median("BalabanJ"), 4));
            Assert.AreEqual(Benzene.Kappa3, Math.Round(this._molSet.Median("Kappa3"), 4));
            Assert.AreEqual(Benzene.LabuteASA, Math.Round(this._molSet.Median("Labute ASA"), 4));
            Assert.AreEqual(Benzene.Chi0, Math.Round(this._molSet.Median("Chi0"), 4));

            var propane = new MolReader(FileNames.PropaneFilePath).GetMol();
            var benzene = new MolReader(FileNames.BenzeneFilePath).GetMol();
            var cyclosporin = new MolReader(FileNames.CyclosporineFilePath).GetMol();
            var phenylPyridine = new MolReader(FileNames.PyridineFilePath).GetMol();
            this._molSet = new MolDescriptorSet(new List<MolDescriptor> 
                { 
                    new MolDescriptor(propane), 
                    new MolDescriptor(benzene), 
                    new MolDescriptor(cyclosporin),
                    new MolDescriptor(phenylPyridine)
                });

            var BalabanJMedian = (PhenylPyridine.BalabanJ + Benzene.BalabanJ) / 2;
            var Kappa3Median = (PhenylPyridine.Kappa3 + Benzene.Kappa3) / 2;
            var LabuteASAMedian = (PhenylPyridine.LabuteASA + Benzene.LabuteASA) / 2;
            var Chi0Median = (PhenylPyridine.Chi0 + Benzene.Chi0) / 2;

            Assert.AreEqual(Math.Round(BalabanJMedian, 4), Math.Round(this._molSet.Median("BalabanJ"), 4));
            Assert.AreEqual(Math.Round(Kappa3Median, 4), Math.Round(this._molSet.Median("Kappa3"), 4));
            Assert.AreEqual(Math.Round(LabuteASAMedian, 4), Math.Round(this._molSet.Median("Labute ASA"), 4));
            Assert.AreEqual(Math.Round(Chi0Median, 4), Math.Round(this._molSet.Median("Chi0"), 4));
        }

        [TestMethod]
        public void VarianceTest()
        {
            Assert.AreEqual(1.8055, Math.Round(this._molSet.Variance("BalabanJ"), 4));
            Assert.AreEqual(152.2304, Math.Round(this._molSet.Variance("Kappa3"), 4));
            Assert.AreEqual(76526.2389, Math.Round(this._molSet.Variance("Labute ASA"), 4));
            Assert.AreEqual(1302.7613, Math.Round(this._molSet.Variance("Chi0"), 4));
        }

        [TestMethod]
        public void StdDevTest()
        {
            Assert.AreEqual(Math.Round(Math.Sqrt(1.8055), 4), Math.Round(this._molSet.StdDev("BalabanJ"), 4));
            Assert.AreEqual(Math.Round(Math.Sqrt(152.2304), 4), Math.Round(this._molSet.StdDev("Kappa3"), 4));
            Assert.AreEqual(Math.Round(Math.Sqrt(76526.2389), 4), Math.Round(this._molSet.StdDev("Labute ASA"), 4));
            Assert.AreEqual(Math.Round(Math.Sqrt(1302.7613), 4), Math.Round(this._molSet.StdDev("Chi0"), 4));
        }
    }
}
