using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBDescriptorExtension.Constants;
using OBDescriptorExtension.Annotations;
using OpenBabel;

namespace OBDescriptorExtension
{
    public class MolDescriptor
    {
        #region Private variables

        private OBMolExtended _mol;
        private IDictionary<string, int> _fragmentCounts;
        private string _inchiKey;
        private string _smiles;
        

        #endregion

        #region Properties

        private OBMolExtended ExtendedMol
        {
            get { return this._mol; }
        }

        /// <summary>
        /// Molecule title
        /// </summary>
        public string Title
        {
            get { return this.ExtendedMol.Mol.GetTitle(); }
        }

        /// <summary>
        /// Molecule in smiles format
        /// </summary>
        public string Smiles
        {
            get
            {
                if (string.IsNullOrEmpty(this._smiles))
                {
                    var converter = new OBConversion();
                    converter.SetOutFormat("smi");
                    this._smiles = converter.WriteString(this.ExtendedMol.Mol).Replace(this.Title, string.Empty).Trim();
                }
                return this._smiles;
            }
        }

        /// <summary>
        /// Generates InchiKey for mol
        /// </summary>
        public string InchiKey
        {
            get
            {
                if (string.IsNullOrEmpty(this._inchiKey))
                {
                    var converter = new OBConversion();
                    converter.SetOutFormat("inchikey");
                    this._inchiKey = converter.WriteString(this.ExtendedMol.Mol).Trim();
                }
                return this._inchiKey;
            }
        }

        /// <summary>
        /// Molecular weight
        /// </summary>
        [Feature(Name="Molecular Weight")]
        public double MolWt
        {
            get { return this.ExtendedMol.Mol.GetMolWt(); }
        }

        /// <summary>
        /// Smallest set of smallest rings
        /// </summary>
        [Feature(Name="Number Rings")]
        public int NumRings
        {
            get { return this.ExtendedMol.Mol.GetSSSR().Count; }
        }

        /// <summary>
        /// Total molecular charge (Gasteiger)
        /// </summary>
        [Feature(Name="Total Charge")]
        public double TotalCharge
        {
            get 
            {
                var newMol = this.ExtendedMol.Mol.AssignGasteigerCharges();
                return newMol.Atoms().Select(a => a.GetPartialCharge()).Sum();
            }
        }

        /// <summary>
        /// Total spin multiplicity
        /// </summary>
        [Feature(Name="Total Spin Multiplicity")]
        public uint TotalSpinMultiplicity
        {
            get { return this.ExtendedMol.Mol.GetTotalSpinMultiplicity(); }
        }

        /// <summary>
        /// Number of conformers
        /// </summary>
        [Feature(Name="Number Conformers")]
        public int NumConformers
        {
            get { return this.ExtendedMol.Mol.NumConformers(); }
        }

        /// <summary>
        /// Energy of the conformer with lowest energy
        /// </summary>
        [Feature(Name="Least Conformer Energy")]
        public double LeastConformerEnergy
        {
            get { return this.ExtendedMol.Mol.GetEnergies().Min(); }
        }

        /// <summary>
        /// Heat of formation
        /// </summary>
        [Feature(Name="Heat of Formation")]
        public double HeatOfFormation
        {
            get { return this.ExtendedMol.Mol.GetEnergy(); }
        }

        /// <summary>
        /// Number of atoms
        /// </summary>
        [Feature(Name="Number Atoms")]
        public uint NumAtoms
        {
            get { return this.ExtendedMol.Mol.NumAtoms(); }
        }

        /// <summary>
        /// Number of heavy atoms (atoms with atomic mass > H)
        /// </summary>
        [Feature(Name="Number Heavy Atoms")]
        public uint NumHeavyAtoms
        {
            get { return this.ExtendedMol.Mol.NumHvyAtoms(); }
        }

        /// <summary>
        /// Number of rotatable bonds
        /// </summary>
        [Feature(Name="Number Rotatable Bonds")]
        public uint RotatableBonds
        {
            get { return this.ExtendedMol.Mol.NumRotors(); }
        }

        /// <summary>
        /// Number of bonds
        /// </summary>
        [Feature(Name="Number Bonds")]
        public uint NumBonds
        {
            get { return this.ExtendedMol.Mol.NumBonds(); }
        }

        /// <summary>
        /// Number of single bonds
        /// </summary>
        [Feature(Name="Number Single Bonds")]
        public double NumSingleBonds
        {
            get { return this.PredictProperty(OBDescriptorType.NumSingleBonds); }
        }

        /// <summary>
        /// Number of double bonds
        /// </summary>
        [Feature(Name="Number Double Bonds")]
        public double NumDoubleBonds
        {
            get { return this.PredictProperty(OBDescriptorType.NumDoubleBonds); }
        }

        /// <summary>
        /// Number of triple bonds
        /// </summary>
        [Feature(Name="Number Triple Bonds")]
        public double NumTripleBonds
        {
            get { return this.PredictProperty(OBDescriptorType.NumTripleBonds); }
        }

        /// <summary>
        /// Number of aromatic bonds
        /// </summary>
        [Feature(Name="Number Aromatic Bonds")]
        public double NumAromaticBonds
        {
            get { return this.PredictProperty(OBDescriptorType.AromaticBonds); }
        }

        /// <summary>
        /// Predicts the logP
        /// </summary>
        [Feature(Name="LogP")]
        public double LogP
        {
            get { return this.PredictProperty(OBDescriptorType.LogP); }
        }

        /// <summary>
        /// Predicts the total polar surface area
        /// </summary>
        [Feature(Name="TPSA")]
        public double Tpsa
        {
            get { return this.PredictProperty(OBDescriptorType.TPSA); }
        }

        /// <summary>
        /// Predicts number of hydrogen bond acceptors
        /// </summary>
        [Feature(Name="HBA1")]
        public double HBA1
        {
            get { return this.PredictProperty(OBDescriptorType.HBA1); }
        }

        /// <summary>
        /// Predicts number of hydrogen bond acceptors
        /// </summary>
        [Feature(Name="HBA2")]
        public double HBA2
        {
            get { return this.PredictProperty(OBDescriptorType.HBA2); }
        }

        /// <summary>
        /// Predicts number of hydrogen bond donors
        /// </summary>
        [Feature(Name="HBD")]
        public double HBD
        {
            get { return this.PredictProperty(OBDescriptorType.HBD); }
        }

        /// <summary>
        /// Predicts melting point
        /// </summary>
        [Feature(Name="Melting Point")]
        public double MeltingPoint
        {
            get { return this.PredictProperty(OBDescriptorType.MeltingPoint); }
        }

        /// <summary>
        /// Predicts molar refractivity
        /// </summary>
        [Feature(Name="Molar Refractivity")]
        public double MolarRefractivity
        {
            get { return this.PredictProperty(OBDescriptorType.MolarRefractivity); }
        }

        /// <summary>
        /// Predicts number of fluorines
        /// </summary>
        [Feature(Name="Number Fluorines")]
        public double NumberFluorines
        {
            get { return this.PredictProperty(OBDescriptorType.NumF); }
        }

        /// <summary>
        /// Gets the number of occurrences for each fragment listed in the Fragments collection
        /// </summary>
        public IDictionary<string, int> FragmentCounts
        {
            get
            {
                if (this._fragmentCounts == null)
                {
                    this._fragmentCounts = new Dictionary<string, int>();
                    foreach (var key in Fragments.Collection.AllKeys)
                    {
                        var smarts = Fragments.Collection[key];
                        if (string.IsNullOrEmpty(smarts))
                        {
                            throw new KeyNotFoundException(string.Format("MolDescriptor: key={0} was not found.", key));
                        }
                        this._fragmentCounts.Add(key, this.FragmentCount(smarts));
                    }
                }
                return this._fragmentCounts;
            }
        }

        #region Surface Area Properties

        /// <summary>
        /// Labute ASA prediction
        /// </summary>
        [Feature(Name = "Labute ASA")]
        public double LabuteASA
        {
            get { return this.ExtendedMol.LabuteAsaContributions.Sum(); }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge -inf < x < -0.30
        /// </summary>
        [Feature(Name = "PEOE VSA 1")]
        public double PeoeVSA1
        {
            get { return this.ExtendedMol.PeoeVsa[0]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge -0.30 <= x < -0.25
        /// </summary>
        [Feature(Name = "PEOE VSA 2")]
        public double PeoeVSA2
        {
            get { return this.ExtendedMol.PeoeVsa[1]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge -0.25 <= x < -0.20
        /// </summary>
        [Feature(Name = "PEOE VSA 3")]
        public double PeoeVSA3
        {
            get { return this.ExtendedMol.PeoeVsa[2]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge -0.20 <= x < -0.15
        /// </summary>
        [Feature(Name = "PEOE VSA 4")]
        public double PeoeVSA4
        {
            get { return this.ExtendedMol.PeoeVsa[3]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge -0.15 <= x < -0.10
        /// </summary>
        [Feature(Name = "PEOE VSA 5")]
        public double PeoeVSA5
        {
            get { return this.ExtendedMol.PeoeVsa[4]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge -0.10 <= x < -0.05
        /// </summary>
        [Feature(Name = "PEOE VSA 6")]
        public double PeoeVSA6
        {
            get { return this.ExtendedMol.PeoeVsa[5]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge -0.05 <= x < 0.0
        /// </summary>
        [Feature(Name = "PEOE VSA 7")]
        public double PeoeVSA7
        {
            get { return this.ExtendedMol.PeoeVsa[6]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge 0 <= x < 0.05
        /// </summary>
        [Feature(Name = "PEOE VSA 8")]
        public double PeoeVSA8
        {
            get { return this.ExtendedMol.PeoeVsa[7]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge 0.05 <= x < 0.10
        /// </summary>
        [Feature(Name = "PEOE VSA 9")]
        public double PeoeVSA9
        {
            get { return this.ExtendedMol.PeoeVsa[8]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge 0.10 <= x < 0.15
        /// </summary>
        [Feature(Name = "PEOE VSA 10")]
        public double PeoeVSA10
        {
            get { return this.ExtendedMol.PeoeVsa[9]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge 0.15 <= x < 0.20
        /// </summary>
        [Feature(Name = "PEOE VSA 11")]
        public double PeoeVSA11
        {
            get { return this.ExtendedMol.PeoeVsa[10]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge 0.20 <= x < 0.25
        /// </summary>
        [Feature(Name = "PEOE VSA 12")]
        public double PeoeVSA12
        {
            get { return this.ExtendedMol.PeoeVsa[11]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge 0.25 <= x < 0.30
        /// </summary>
        [Feature(Name = "PEOE VSA 13")]
        public double PeoeVSA13
        {
            get { return this.ExtendedMol.PeoeVsa[12]; }
        }

        /// <summary>
        /// PEOE VSA contribution for atoms with charge 0.30 <= x < inf
        /// </summary>
        [Feature(Name = "PEOE VSA 14")]
        public double PeoeVSA14
        {
            get { return this.ExtendedMol.PeoeVsa[13]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR -inf < x < 1.29
        /// </summary>
        [Feature(Name = "SMR VSA 1")]
        public double SmrVSA1
        {
            get { return this.ExtendedMol.SmrVsa[0]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 1.29 <= x < 1.82
        /// </summary>
        [Feature(Name = "SMR VSA 2")]
        public double SmrVSA2
        {
            get { return this.ExtendedMol.SmrVsa[1]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 1.82 <= x < 2.24
        /// </summary>
        [Feature(Name = "SMR VSA 3")]
        public double SmrVSA3
        {
            get { return this.ExtendedMol.SmrVsa[2]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 2.24 <= x < 2.45
        /// </summary>
        [Feature(Name = "SMR VSA 4")]
        public double SmrVSA4
        {
            get { return this.ExtendedMol.SmrVsa[3]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 2.45 <= x < 2.75
        /// </summary>
        [Feature(Name = "SMR VSA 5")]
        public double SmrVSA5
        {
            get { return this.ExtendedMol.SmrVsa[4]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 2.75 <= x < 3.05
        /// </summary>
        [Feature(Name = "SMR VSA 6")]
        public double SmrVSA6
        {
            get { return this.ExtendedMol.SmrVsa[5]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 3.05 <= x < 3.63
        /// </summary>
        [Feature(Name = "SMR VSA 7")]
        public double SmrVSA7
        {
            get { return this.ExtendedMol.SmrVsa[6]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 3.63 <= x < 3.80
        /// </summary>
        [Feature(Name = "SMR VSA 8")]
        public double SmrVSA8
        {
            get { return this.ExtendedMol.SmrVsa[7]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 3.80 <= x < 4.00
        /// </summary>
        [Feature(Name = "SMR VSA 9")]
        public double SmrVSA9
        {
            get { return this.ExtendedMol.SmrVsa[8]; }
        }

        /// <summary>
        /// SMR VSA contributions for atoms with MR 4.00 <= x < inf
        /// </summary>
        [Feature(Name = "SMR VSA 10")]
        public double SmrVSA10
        {
            get { return this.ExtendedMol.SmrVsa[9]; }
        }

        /// <summary>
        /// Contributions from EState bin 1 using EState as binning property
        /// </summary>
        [Feature(Name="VSA EState 1")]
        public double VsaEState1
        {
            get { return this.ExtendedMol.VsaEState[0]; }
        }

        /// <summary>
        /// Contributions from EState bin 2 using EState as binning property
        /// </summary>
        [Feature(Name="VSA EState 2")]
        public double VsaEState2
        {
            get { return this.ExtendedMol.VsaEState[1]; }
        }

        /// <summary>
        /// Contributions from EState bin 3 using EState as binning property
        /// </summary>
        [Feature(Name="VSA EState 3")]
        public double VsaEState3
        {
            get { return this.ExtendedMol.VsaEState[2]; }
        }

        /// <summary>
        /// Contributions from EState bin 4 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 4")]
        public double VsaEState4
        {
            get { return this.ExtendedMol.VsaEState[3]; }
        }

        /// <summary>
        /// Contributions from EState bin 5 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 5")]
        public double VsaEState5
        {
            get { return this.ExtendedMol.VsaEState[4]; }
        }

        /// <summary>
        /// Contributions from EState bin 6 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 6")]
        public double VsaEState6
        {
            get { return this.ExtendedMol.VsaEState[5]; }
        }

        /// <summary>
        /// Contributions from EState bin 7 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 7")]
        public double VsaEState7
        {
            get { return this.ExtendedMol.VsaEState[6]; }
        }

        /// <summary>
        /// Contributions from EState bin 8 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 8")]
        public double VsaEState8
        {
            get { return this.ExtendedMol.VsaEState[7]; }
        }

        /// <summary>
        /// Contributions from EState bin 9 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 9")]
        public double VsaEState9
        {
            get { return this.ExtendedMol.VsaEState[8]; }
        }

        /// <summary>
        /// Contributions from EState bin 10 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 10")]
        public double VsaEState10
        {
            get { return this.ExtendedMol.VsaEState[9]; }
        }

        /// <summary>
        /// Contributions from EState bin 11 using EState as binning property
        /// </summary>
        [Feature(Name = "VSA EState 11")]
        public double VsaEState11
        {
            get { return this.ExtendedMol.VsaEState[10]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP -inf < x < -0.40
        /// </summary>
        [Feature(Name = "SLogP VSA 1")]
        public double SLogPVSA1
        {
            get { return this.ExtendedMol.SLogPVsa[0]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP -0.40 <= x < -0.30
        /// </summary>
        [Feature(Name = "SLogP VSA 2")]
        public double SLogPVSA2
        {
            get { return this.ExtendedMol.SLogPVsa[1]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP -0.30 <= x < -0.20
        /// </summary>
        [Feature(Name = "SLogP VSA 3")]
        public double SLogPVSA3
        {
            get { return this.ExtendedMol.SLogPVsa[2]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP -0.20 <= x < -0.10
        /// </summary>
        [Feature(Name = "SLogP VSA 4")]
        public double SLogPVSA4
        {
            get { return this.ExtendedMol.SLogPVsa[3]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP -0.10 <= x < 0.00
        /// </summary>
        [Feature(Name = "SLogP VSA 5")]
        public double SLogPVSA5
        {
            get { return this.ExtendedMol.SLogPVsa[4]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP 0.00 <= x < 0.10
        /// </summary>
        [Feature(Name = "SLogP VSA 6")]
        public double SLogPVSA6
        {
            get { return this.ExtendedMol.SLogPVsa[5]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP 0.10 <= x < 0.20
        /// </summary>
        [Feature(Name = "SLogP VSA 7")]
        public double SLogPVSA7
        {
            get { return this.ExtendedMol.SLogPVsa[6]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP 0.20 <= x < 0.30
        /// </summary>
        [Feature(Name = "SLogP VSA 8")]
        public double SLogPVSA8
        {
            get { return this.ExtendedMol.SLogPVsa[7]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP 0.30 <= x < 0.40
        /// </summary>
        [Feature(Name = "SLogP VSA 9")]
        public double SLogPVSA9
        {
            get { return this.ExtendedMol.SLogPVsa[8]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP 0.40 <= x < 0.50
        /// </summary>
        [Feature(Name = "SLogP VSA 10")]
        public double SLogPVSA10
        {
            get { return this.ExtendedMol.SLogPVsa[9]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP 0.50 <= x < 0.60
        /// </summary>
        [Feature(Name = "SLogP VSA 11")]
        public double SLogPVSA11
        {
            get { return this.ExtendedMol.SLogPVsa[10]; }
        }

        /// <summary>
        /// Contributions from atoms with LogP 0.60 <= x < inf
        /// </summary>
        [Feature(Name = "SLogP VSA 12")]
        public double SLogPVSA12
        {
            get { return this.ExtendedMol.SLogPVsa[11]; }
        }

        /// <summary>
        /// Contributions from EState bin 1 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 1")]
        public double EStateVsa1
        {
            get { return this.ExtendedMol.EStateVsa[0]; }
        }

        /// <summary>
        /// Contributions from EState bin 2 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 2")]
        public double EStateVsa2
        {
            get { return this.ExtendedMol.EStateVsa[1]; }
        }

        /// <summary>
        /// Contributions from EState bin 3 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 3")]
        public double EStateVsa3
        {
            get { return this.ExtendedMol.EStateVsa[2]; }
        }

        /// <summary>
        /// Contributions from EState bin 4 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 4")]
        public double EStateVsa4
        {
            get { return this.ExtendedMol.EStateVsa[3]; }
        }

        /// <summary>
        /// Contributions from EState bin 5 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 5")]
        public double EStateVsa5
        {
            get { return this.ExtendedMol.EStateVsa[4]; }
        }

        /// <summary>
        /// Contributions from EState bin 6 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 6")]
        public double EStateVsa6
        {
            get { return this.ExtendedMol.EStateVsa[5]; }
        }

        /// <summary>
        /// Contributions from EState bin 7 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 7")]
        public double EStateVsa7
        {
            get { return this.ExtendedMol.EStateVsa[6]; }
        }

        /// <summary>
        /// Contributions from EState bin 8 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 8")]
        public double EStateVsa8
        {
            get { return this.ExtendedMol.EStateVsa[7]; }
        }

        /// <summary>
        /// Contributions from EState bin 9 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 9")]
        public double EStateVsa9
        {
            get { return this.ExtendedMol.EStateVsa[8]; }
        }

        /// <summary>
        /// Contributions from EState bin 10 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 10")]
        public double EStateVsa10
        {
            get { return this.ExtendedMol.EStateVsa[9]; }
        }

        /// <summary>
        /// Contributions from EState bin 11 using VSA as binning property
        /// </summary>
        [Feature(Name = "EState VSA 11")]
        public double EStateVsa11
        {
            get { return this.ExtendedMol.EStateVsa[10]; }
        }

        /// <summary>
        /// Chi0 atomic connectivity index (order 0)
        /// </summary>
        [Feature(Name = "Chi0")]
        public double Chi0
        {
            get { return this.ExtendedMol.Mol.Chi0(); }
        }

        /// <summary>
        /// Chi1 atomic connectivity index (order 1)
        /// </summary>
        [Feature(Name = "Chi1")]
        public double Chi1
        {
            get { return this.ExtendedMol.Mol.Chi1(); }
        }

        /// <summary>
        /// Chi0v atomic valence connectivity index (order 0)
        /// </summary>
        [Feature(Name = "Chi0v")]
        public double Chi0v
        {
            get { return this.ExtendedMol.Mol.Chi0v(); }
        }

        /// <summary>
        /// Chi1v atomic valence connectivity index (order 1)
        /// </summary>
        [Feature(Name = "Chi1v")]
        public double Chi1v
        {
            get { return this.ExtendedMol.Mol.Chi1v(); }
        }

        /// <summary>
        /// Chi2v atomic valence connectivity index (order 2)
        /// </summary>
        [Feature(Name = "Chi2v")]
        public double Chi2v
        {
            get { return this.ExtendedMol.ChiNv(2); }
        }

        /// <summary>
        /// Chi3v atomic valence connectivity index (order 3)
        /// </summary>
        [Feature(Name = "Chi3v")]
        public double Chi3v
        {
            get { return this.ExtendedMol.ChiNv(3); }
        }

        /// <summary>
        /// Chi4v atomic valence connectivity index (order 4)
        /// </summary>
        [Feature(Name = "Chi4v")]
        public double Chi4v
        {
            get { return this.ExtendedMol.ChiNv(4); }
        }

        /// <summary>
        /// Chi0n atomic valence number connectivity index (order 0)
        /// </summary>
        [Feature(Name = "Chi0n")]
        public double Chi0n
        {
            get { return this.ExtendedMol.Mol.Chi0n(); }
        }

        /// <summary>
        /// Chi1n atomic valence number connectivity index (order 1)
        /// </summary>
        [Feature(Name = "Chi1n")]
        public double Chi1n
        {
            get { return this.ExtendedMol.Mol.Chi1n(); }
        }

        /// <summary>
        /// Chi2n atomic valence number connectivity index (order 2)
        /// </summary>
        [Feature(Name="Chi2n")]
        public double Chi2n
        {
            get { return this.ExtendedMol.ChiNn(2); }
        }

        /// <summary>
        /// Chi3n atomic valence number connectivity index (order 3)
        /// </summary>
        [Feature(Name="Chi3n")]
        public double Chi3n
        {
            get { return this.ExtendedMol.ChiNn(3); }
        }

        /// <summary>
        /// Chi4n atomic valence number connectivity index (order 4)
        /// </summary>
        [Feature(Name = "Chi4n")]
        public double Chi4n
        {
            get { return this.ExtendedMol.ChiNn(4); }
        }

        /// <summary>
        /// Hall-Kier alpha value for molecule
        /// </summary>
        [Feature(Name = "Hall-Kier Alpha")]
        public double HallKierAlpha
        {
            get { return this.ExtendedMol.HallKierAlpha; }
        }

        /// <summary>
        /// Hall-Kier Kappa 1 value for molecule
        /// </summary>
        [Feature(Name = "Kappa1")]
        public double Kappa1
        {
            get { return this.ExtendedMol.Kappa1; }
        }

        /// <summary>
        /// Hall-Kier Kappa2 value for molecule
        /// </summary>
        [Feature(Name = "Kappa2")]
        public double Kappa2
        {
            get { return this.ExtendedMol.Kappa2; }
        }

        /// <summary>
        /// Hall-Kier Kappa3 value for molecule
        /// </summary>
        [Feature(Name = "Kappa3")]
        public double Kappa3
        {
            get { return this.ExtendedMol.Kappa3; }
        }

        /// <summary>
        /// Returns the information content of the coefficients of the characteristic 
        /// polynomial of the adjacency matrix of a hydrogen-suppressed graph of a molecule.
        /// </summary>
        [Feature(Name = "Ipc")]
        public double Ipc
        {
            get { return this.ExtendedMol.Ipc(); }
        }

        [Feature(Name = "BalabanJ")]
        public double BalabanJ
        {
            get { return this.ExtendedMol.BalabanJ; }
        }

        #endregion

        /// <summary>
        /// All the properties marked with the feature attribute
        /// </summary>
        public IEnumerable<PropertyInfo> Features
        {
            get { return this.GetType().GetProperties().Where(p => p.IsDefined(typeof(FeatureAttribute), false)); }
        }

        /// <summary>
        /// Number of features in a MolDescriptor instance
        /// </summary>
        public static int FeatureCount()
        {
            return MolDescriptor.GetFeatureNames().Length;
        }

        /// <summary>
        /// Returns the names of all the available features
        /// </summary>
        public static string[] GetFeatureNames()
        {
            var descriptor = new MolDescriptor(new OBMol());
            return descriptor.Features
                .Select(p => p.GetCustomAttributes(false).OfType<FeatureAttribute>().First().Name)
                .Concat(descriptor.FragmentCounts.Keys).OrderBy(n => n)
                .ToArray(); 
        }

        #endregion

        #region Constructor

        public MolDescriptor(OBMol mol)
        {
            var newMol = new OBMol(mol);
            newMol.DeleteHydrogens();
            this._mol = new OBMolExtended(newMol);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to use the OBDescriptor class to predict properties
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private double PredictProperty(string propertyName)
        {
            var descriptor = OBDescriptor.FindType(propertyName);
            return descriptor.Predict(this.ExtendedMol.Mol);
        }

        /// <summary>
        /// Predicts the number of occurrences of a fragment given a SMARTS pattern
        /// </summary>
        /// <param name="smarts"></param>
        /// <returns></returns>
        public int FragmentCount(string smarts)
        {
            return this.ExtendedMol.Mol.SmartPatternCount(smarts);
        }

        /// <summary>
        /// Returns a FeatureValue object that holds the Feature name and its associated property value
        /// </summary>
        /// <param name="featureName">string</param>
        /// <returns>object</returns>
        public OBDescriptorExtension.FeatureValue FeatureValue(string featureName)
        {
            var property = this.Features.SingleOrDefault(p => p.GetCustomAttributes(false).OfType<FeatureAttribute>().First().Name.Equals(featureName, StringComparison.CurrentCultureIgnoreCase));
            if (property == null)
            {
                // Look in the fragment counts dictionary
                try
                {
                    return new OBDescriptorExtension.FeatureValue(featureName, Convert.ToDouble(this.FragmentCounts[featureName]));
                }
                catch (KeyNotFoundException)
                {
                    throw new ArgumentException(string.Format("{0} is not a valid feature", featureName));
                }
            }
            return new OBDescriptorExtension.FeatureValue(featureName,Convert.ToDouble(property.GetValue(this, null)));
        }

        /// <summary>
        /// Returns an array of feature value objects holding values for all features.
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            return MolDescriptor.GetFeatureNames().Select(n => this.FeatureValue(n).Value).ToArray();
        }

        #endregion
    }
}
