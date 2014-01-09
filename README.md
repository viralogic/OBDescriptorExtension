# OBDescriptorExtension #

## Intro ##

OBDescriptorExtension is an extension of the C# port of OpenBabel (OBDotNet) that includes additional calculated cheminformatic properties
of a given molecule. 

<h3 id="Features">Calculated properties / Features</h3>

There are 100 new properties (**Features**) can be calculated using this extension library. These include:

* Molecular Weight
* Number Rings
* Total Charge
* Total Spin Multiplicity
* Number Conformers
* Least Conformer Energy
* Heat of Formation
* Number Atoms
* Number Heavy Atoms
* Number Rotatable Bonds
* Number Bonds
* Number Single Bonds
* Number Double Bonds
* Number Triple Bonds
* Number Aromatic Bonds
* LogP
* TPSA
* HBA1
* HBA2
* HBD
* Melting Point
* Molar Refractivity
* Number Fluorines
* Labute ASA
* PEOE VSA 1
* PEOE VSA 2
* PEOE VSA 3
* PEOE VSA 4
* PEOE VSA 5
* PEOE VSA 6
* PEOE VSA 7
* PEOE VSA 8
* PEOE VSA 9
* PEOE VSA 10
* PEOE VSA 11
* PEOE VSA 12
* PEOE VSA 13
* PEOE VSA 14
* SMR VSA 1
* SMR VSA 2
* SMR VSA 3
* SMR VSA 4
* SMR VSA 5
* SMR VSA 6
* SMR VSA 7
* SMR VSA 8
* SMR VSA 9
* SMR VSA 10
* SLogP VSA 1
* SLogP VSA 2
* SLogP VSA 3
* SLogP VSA 4
* SLogP VSA 5
* SLogP VSA 6
* SLogP VSA 7
* SLogP VSA 8
* SLogP VSA 9
* SLogP VSA 10
* SLogP VSA 11
* SLogP VSA 12
* VSA EState 1
* VSA EState 2
* VSA EState 3
* VSA EState 4
* VSA EState 5
* VSA EState 6
* VSA EState 7
* VSA EState 8
* VSA EState 9
* VSA EState 10
* VSA EState 11
* EState VSA 1
* EState VSA 2
* EState VSA 3
* EState VSA 4
* EState VSA 5
* EState VSA 6
* EState VSA 7
* EState VSA 8
* EState VSA 9
* EState VSA 10
* EState VSA 11
* Chi0
* Chi1
* Chi0v
* Chi1v
* Chi2v
* Chi3v
* Chi4v
* Chi0n
* Chi1n
* Chi2n
* Chi3n
* Chi4n
* Hall-Kier Alpha
* Kappa1
* Kappa2
* Kappa3
* Ipc
* BalabanJ

<h3 id="Fragments">Fragments</h3>

Additionally, fragment counts for 85 different fragments can be obtained. These include:

**Fragment Name(SMARTS Pattern)**

* fr_C=O ([CX3]=[OX1] )
* fr_C=O_noCOO ([C!$(C-[OH])]=O )</li>
* fr_Al_OH ([C!$(C=O)]-[OH] )
* fr_Ar_OH (c[OH1] )
* fr_methoxy ([OX2](-[#6])-[CH3] )
* fr_oxime ([CX3]=[NX2]-[OX2] )
* fr_ester ([#6][CX3](=O)[OX2H0][#6] )
* fr_Al_COO (C-C(=O)[O;H1,-] )
* fr_Ar_COO (c-C(=O)[O;H1,-] )
* fr_COO ([#6]C(=O)[O;H,-1] )
* fr_COO2 ([CX3](=O)[OX1H0-,OX2H1] )
* fr_ketone ([#6][CX3](=O)[#6] )
* fr_ether ([OD2]([#6])[#6] )
* fr_phenol ([OX2H]-c1ccccc1 )
* fr_aldehyde ([CX3H1](=O)[#6] )
* fr_quatN ([$([NX4+]),$([NX4]=*)] )
* fr_NH2 ([NH2,nH2] )
* fr_NH1 ([NH1,nH1] )
* fr_NH0 ([NH0,nH0] )
* fr_Ar_N (n )
* fr_Ar_NH ([nH] )
* fr_aniline (c-[NX3] )
* fr_Imine ([Nv3](=C)-[#6] )
* fr_nitrile ([NX1]#[CX2] )
* fr_hdrzine ([NX3]-[NX3] )
* fr_hdrzone (C=N-[NX3] )
* fr_nitroso ([N!$(N-O)]=O )
* fr_N-O ([N!$(N=O)](-O)-C )
* fr_nitro ([$([NX3](=O)=O),$([NX3+](=O)[O-])][!#8] )
* fr_azo ([#6]-N=N-[#6] )
* fr_diazo ([N+]#N )
* fr_azide ([$(*-[NX2-]-[NX2+]#[NX1]),$(*-[NX2]=[NX2+]=[NX1-])] )
* fr_amide (C(=O)-N )
* fr_priamide (C(=O)-[NH2] )
* fr_amidine (C(=N)(-N)-[!#7] )
* fr_guanido (C(=N)(N)N )
* fr_Nhpyrrole ([nH] )
* fr_imide (N(-C(=O))-C=O )
* fr_isocyan (N=C=O )
* fr_isothiocyan (N=C=S )
* fr_thiocyan (S-C#N )
* fr_halogen ([#9,#17,#35,#53] )
* fr_alkyl_halide ([CX4]-[Cl,Br,I,F] )
* fr_sulfide ([SX2](-[#6])-C )
* fr_SH ([SH] )
* fr_C=S (C=[SX1] )
* fr_sulfone (S(=,-[OX1;+0,-1])(=,-[OX1;+0,-1])(-[#6])-[#6] )
* fr_sulfone (S(=,-[OX1;+0,-1])(=,-[OX1;+0,-1])(-[#6])-[#6] )
* fr_sulfonamd (N-S(=,-[OX1;+0,-1])(=,-[OX1;+0,-1])-[#6] )
* fr_prisulfonamd ([NH2]-S(=,-[OX1;+0;-1])(=,-[OX1;+0;-1])-[#6] )
* fr_barbitur (C1C(=O)NC(=O)NC1=O )
* fr_urea (C(=O)(-N)-N )
* fr_term_acetylene (C#[CH] )
* fr_imidazole (n1cncc1 )
* fr_furan (o1cccc1 )
* fr_thiophene (s1cccc1 )
* fr_thiazole (c1scnc1 )
* fr_oxazole (c1ocnc1 )
* fr_pyridine (n1ccccc1 )
* fr_piperdine (N1CCCCC1 )
* fr_piperzine (N1CCNCC1 )
* fr_morpholine (O1CCNCC1 )
* fr_lactam (N1C(=O)CC1 )
* fr_lactone ([C&R1](=O)[O&R1][C&R1] )
* fr_tetrazole (c1nnnn1 )
* fr_epoxide (O1CC1 )
* fr_unbrch_alkane ([R0;D2][R0;D2][R0;D2][R0;D2] )
* fr_bicyclic ([R2][R2] )
* fr_benzene (c1ccccc1 )
* fr_phos_acid ([$(P(=[OX1])([$([OX2H]),$([OX1-]),$([OX2]P)])([$([OX2H]),$([OX1-]),$([OX2]P)])[$([OX2H]),$([OX1-]),$([OX2]P)]),$([P+]([OX1-])([$([OX2H]),$([OX1-]),$([OX2]P)])([$([OX2H]),$([OX1-]),$([OX2]P)])[$([OX2H]),$([OX1-]),$([OX2]P)])] )
* fr_phos_ester ([$(P(=[OX1])([OX2][#6])([$([OX2H]),$([OX1-]),$([OX2][#6])])[$([OX2H]),$([OX1-]),$([OX2][#6]),$([OX2]P)]),$([P+]([OX1-])([OX2][#6])([$([OX2H]),$([OX1-]),$([OX2][#6])])[$([OX2H]),$([OX1-]),$([OX2][#6]),$([OX2]P)])] )
* fr_nitro_arom ([$(c1(-[$([NX3](=O)=O),$([NX3+](=O)[O-])])ccccc1)] )
* fr_nitro_arom_nonortho ([$(c1(-[$([NX3](=O)=O),$([NX3+](=O)[O-])])ccccc1);!$(cc-!:*)] )
* fr_dihydropyridine ([$([NX3H1]1-C=C-C-C=C1),$([Nv3]1=C-C-C=C-C1),$([Nv3]1=C-C=C-C-C1),$([NX3H1]1-C-C=C-C=C1)] )
* fr_phenol_noOrthoHbond ([$(c1(-[OX2H])ccccc1);!$(cc-!:[CH2]-[OX2H]);!$(cc-!:C(=O)[O;H1,-]);!$(cc-!:C(=O)-[NH2])] )
* fr_Al_OH_noTert ([$(C-[OX2H]);!$([CX3](-[OX2H])=[OX1]);!$([CD4]-[OX2H])] )
* fr_benzodiazepine ([c&R2]12[c&R1][c&R1][c&R1][c&R1][c&R2]1[N&R1][C&R1][C&R1][N&R1]=[C&R1]2 )
* fr_para_hydroxylation ([$([cH]1[cH]cc(c[cH]1)~[$([#8,$([#8]~[H,c,C])])]),$([cH]1[cH]cc(c[cH]1)~[$([#7X3,$([#7](~[H,c,C])~[H,c,C])])]),$([cH]1[cH]cc(c[cH]1)-!:[$([NX3H,$(NC(=O)[H,c,C])])])] )
* fr_allylic_oxid ([$(C=C-C);!$(C=C-C-[N,O,S]);!$(C=C-C-C-[N,O]);!$(C12=CC(=O)CCC1C3C(C4C(CCC4)CC3)CC2)] )
* fr_aryl_methyl ([$(a-[CH3]),$(a-[CH2]-[CH3]),$(a-[CH2]-[CH2]~[!N;!O]);!$(a(:a!:*):a!:*)] )
* fr_Ndealkylation1 ([$(N(-[CH3])-C-[$(C~O),$(C-a),$(C-N),$(C=C)]),$(N(-[CH2][CH3])-C-[$(C~O),$(C-a),$(C-N),$(C=C)])] )
* fr_Ndealkylation2 ([$([N&R1]1(-C)CCC1),$([N&R1]1(-C)CCCC1),$([N&R1]1(-C)CCCCC1),$([N&R1]1(-C)CCCCCC1),$([N&R1]1(-C)CCCCCCC1)] )
* fr_alkyl_carbamate (C[NH1]C(=O)OC )
* fr_ketone_Topliss ([$([CX3](=[OX1])(C)([c,C]));!$([CX3](=[OX1])([CH1]=C)[c,C])] )
* fr_ArN ([$(a-[NX3H2]),$(a-[NH1][NH2]),$(a-C(=[OX1])[NH1][NH2]),$(a-C(=[NH])[NH2])] )
* fr_HOCCN ([$([OX2H1][CX4][CX4H2][NX3&R1]),$([OH1][CX4][CX4H2][NX3][CX4](C)(C)C)] )

## Dependencies ##

OBDescriptorExtension is dependent upon the OBDotNet library. This library is a C# port of [OpenBabel](http://openbabel.org/wiki/Main_Page).

# Usage #

[Download](https://bitbucket.org/bfenskeca/obdescriptorextension/get/a708f335cd8e.zip) the project and unzip to the directory. Load the solution using Visual Studio 2012 or greater. Check that the OBDescriptorExtension build properties are set to use the .NET Framework 4 target framework and x86 target platform and build the solution in release mode.

Add the OBDotNet and OBDescriptorExtension class libraries to the References folder in your project. The OBDotNet dll is located in the Dependencies folder and the OBDescriptorExtension dll will be located in the bin folder.

Import the OBDescriptor and OpenBabel namespaces at the top of your C# class file:

`
	using OpenBabel;<br>
	using OBDescriptorExtension;
`

Additionally, when using the MolReader class, you must also import the System.Web namespace.

`
	using System.Web;
`

## Loading ##

Files containing multiple molecules can be loaded:

`
	var mols = new MolReader("*filepath*").Open();
`

where `mols` is an `IEnumerable` of `OBMol` objects. Thus LINQ can be used on `mols` for further processing.

Files containing a single molecule can loaded:

`
	var mol = new MolReader("*filepath*").GetMol();
`

or

`
	var mol = new MolReader("*filepath*").Open().FirstOrDefault();
`

A MolReader constructor also exists for handling web form post files.

`
	var mols = new MolReader(*HttpPostedFileBase uploadFile*).Open();
`

**Note:** Due to the lack of the OBConversion class in OBDotNet to read streams, the above method writes files to the C:/Temp directory on your system. It is up to you to clean up these files in your code. For example:

`
	// Instantiate MolReader object<br>
	var reader = new MolReader(uploadFile);<br>
	var mols = reader.Open();<br>
	// Process the molecules. Here we will just load them into memory<br>
	var molList = mols.ToList();<br>
	// Clean up after yourself<br>
	File.Delete(reader.FilePath);
`

All file formats that can be read by OpenBabel are compatible with the OBDescriptorExtension library.

## MolDescriptor class ##

The MolDescriptor class is a wrapper around the `OBMol` object. Chemical descriptors/properties  are known as **Features** and can be obtained by calling the appropriate MolDescriptor class property. For example:

`
	var molDescriptor = new MolDescriptor(mol); // mol is OBMol instance<br>
	var molWeight = molDescriptor.MolWt; // getter for molecular weight<br>
	var labuteASA = molDescriptor.LabuteASA; // getter for Labute ASA property<br>
`

Features can also be calculated by using the appropriate feature name as given in the list <a href="Features">above</a>.

`
	var feature = molDescriptor.FeatureValue("Molecular Weight");
`

This returns a FeatureValue object that contains the property name and value.

`
	var property = feature.Name; // string<br>
	var value = feature.Value; // double
`

A full listing for available feature names can be obtained by:

`
	var propertyNames = molDescriptor.GetFeatureNames(); // string array
`

There are also other properties that can be obtained, such as SMILES.

` var smiles = molDescriptor.Smiles; // getter for SMILES string`

To obtain fragment counts:

`
	var fragCount = molDescriptor.FragmentCount("*smartsPattern*");
`

There is a preset dictionary of fragments that the MolDescriptor class calculates. To get the fragment counts for all the preset fragments, use:

`
	var fragments = molDescriptor.FragmentCounts; // returns "*string*" : count dictionary
`

The preset fragments and associated SMARTS pattern are given in the <a href="#Fragments">Fragments</a> section above.

## MolDescriptorSet Class ##

The MolDesriptorSet class is wrapper class around `IEnumerable` of MolDescriptors. It is used to calculate statistics for each MolDescriptor feature. This class can be used to obtain average, standard deviation, variance, median, minimum, and maximum chemical property values.

`
	var descriptorSet = new MolReader("mols.sdf").Open().Select(m => new MolDescriptor(m)); // IEnumerable of MolDescriptor instances<br>
	var molSet = new MolDescriptorSet(descriptorSet);
`

Methods can then be called to compute aggregate values.

`
	molSet.Average(*FeatureName*);<br>
	// Example<br>
	molSet.Average("BalabanJ");<br>
`

To get all available statistics from all calculated properties:

`
	var stats = molSet.Statistics();
`

where stats is a `IEnumerable` of FeatureStatistics objects. Each object contains the feature name and all the calculated property values for each molecule in the set.

`
	var firstFeature = stats.First();<br>
	var featureName = firstFeature.FirstName;<br>
	var calcValues = firstFeature.Values;<br>
	var featureMin = firstFeature.Min;<br>
`