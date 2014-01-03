# OBDescriptorExtension #

## Intro ##

OBDescriptorExtension is an extension of the C# port of OpenBabel (OBDotNet) that includes additional calculated cheminformatic properties
of a given molecule. 

### Calculated properties ###

There are 100 new properties can be calculated using this extension library. These include:

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

### Fragments ###

Additionally, fragment counts for 85 different fragments can be obtained. These include:

<table>
	<thead>
		<tr>
			<th>Fragment Name</th>
			<th>SMARTS Pattern</th>
		</tr>
	</thead>
	<tbody>
		<tr><td>fr_C=O</td><td>[CX3]=[OX1]</td></tr>
        <tr><td>fr_C=O_noCOO</td><td>[C!$(C-[OH])]=O</td></tr>
        <tr><td>fr_Al_OH</td><td>[C!$(C=O)]-[OH]</td></tr>
        <tr><td>fr_Ar_OH</td><td>c[OH1]</td></tr>
        <tr><td>fr_methoxy</td><td>[OX2](-[#6])-[CH3]</td></tr>
        <tr><td>fr_oxime</td><td>[CX3]=[NX2]-[OX2]</td></tr>
        <tr><td>fr_ester</td><td>[#6][CX3](=O)[OX2H0][#6]</td></tr>
        <tr><td>fr_Al_COO</td><td>C-C(=O)[O;H1,-]</td></tr>
        <tr><td>fr_Ar_COO</td><td>c-C(=O)[O;H1,-]</td></tr>
        <tr><td>fr_COO</td><td>[#6]C(=O)[O;H,-1]</td></tr>
        <tr><td>fr_COO2</td><td>[CX3](=O)[OX1H0-,OX2H1]</td></tr>
        <tr><td>fr_ketone</td><td>[#6][CX3](=O)[#6]</td></tr>
        <tr><td>fr_ether</td><td>[OD2]([#6])[#6]</td></tr>
        <tr><td>fr_phenol</td><td>[OX2H]-c1ccccc1</td></tr>
        <tr><td>fr_aldehyde</td><td>[CX3H1](=O)[#6]</td></tr>
        <tr><td>fr_quatN</td><td>[$([NX4+]),$([NX4]=*)]</td></tr>
        <tr><td>fr_NH2</td><td>[NH2,nH2]</td></tr>
        <tr><td>fr_NH1</td><td>[NH1,nH1]</td></tr>
        <tr><td>fr_NH0</td><td>[NH0,nH0]</td></tr>
        <tr><td>fr_Ar_N</td><td>n</td></tr>
        <tr><td>fr_Ar_NH</td><td>[nH]</td></tr>
        <tr><td>fr_aniline</td><td>c-[NX3]</td></tr>
        <tr><td>fr_Imine</td><td>[Nv3](=C)-[#6]</td></tr>
        <tr><td>fr_nitrile</td><td>[NX1]#[CX2]</td></tr>
        <tr><td>fr_hdrzine</td><td>[NX3]-[NX3]</td></tr>
        <tr><td>fr_hdrzone</td><td>C=N-[NX3]</td></tr>
        <tr><td>fr_nitroso</td><td>[N!$(N-O)]=O</td></tr>
        <tr><td>fr_N-O</td><td>[N!$(N=O)](-O)-C</td></tr>
        <tr><td>fr_nitro</td><td>[$([NX3](=O)=O),$([NX3+](=O)[O-])][!#8]</td></tr>
        <tr><td>fr_azo</td><td>[#6]-N=N-[#6]</td></tr>
        <tr><td>fr_diazo</td><td>[N+]#N</td></tr>
        <tr><td>fr_azide</td><td>[$(*-[NX2-]-[NX2+]#[NX1]),$(*-[NX2]=[NX2+]=[NX1-])]</td></tr>
        <tr><td>fr_amide</td><td>C(=O)-N</td></tr>
        <tr><td>fr_priamide</td><td>C(=O)-[NH2]</td></tr>
        <tr><td>fr_amidine</td><td>C(=N)(-N)-[!#7]</td></tr>
        <tr><td>fr_guanido</td><td>C(=N)(N)N</td></tr>
        <tr><td>fr_Nhpyrrole</td><td>[nH]</td></tr>
        <tr><td>fr_imide</td><td>N(-C(=O))-C=O</td></tr>
        <tr><td>fr_isocyan</td><td>N=C=O</td></tr>
        <tr><td>fr_isothiocyan</td><td>N=C=S</td></tr>
        <tr><td>fr_thiocyan</td><td>S-C#N</td></tr>
        <tr><td>fr_halogen</td><td>[#9,#17,#35,#53]</td></tr>
        <tr><td>fr_alkyl_halide</td><td>[CX4]-[Cl,Br,I,F]</td></tr>
        <tr><td>fr_sulfide</td><td>[SX2](-[#6])-C</td></tr>
        <tr><td>fr_SH</td><td>[SH]</td></tr>
        <tr><td>fr_C=S</td><td>C=[SX1]</td></tr>
        <tr><td>fr_sulfone</td><td>S(=,-[OX1;+0,-1])(=,-[OX1;+0,-1])(-[#6])-[#6]</td></tr>
        <tr><td>fr_sulfone</td><td>S(=,-[OX1;+0,-1])(=,-[OX1;+0,-1])(-[#6])-[#6]</td></tr>
        <tr><td>fr_sulfonamd</td><td>N-S(=,-[OX1;+0,-1])(=,-[OX1;+0,-1])-[#6]</td></tr>
        <tr><td>fr_prisulfonamd</td><td>[NH2]-S(=,-[OX1;+0;-1])(=,-[OX1;+0;-1])-[#6]</td></tr>
        <tr><td>fr_barbitur</td><td>C1C(=O)NC(=O)NC1=O</td></tr>
        <tr><td>fr_urea</td><td>C(=O)(-N)-N</td></tr>
        <tr><td>fr_term_acetylene</td><td>C#[CH]</td></tr>
        <tr><td>fr_imidazole</td><td>n1cncc1</td></tr>
        <tr><td>fr_furan</td><td>o1cccc1</td></tr>
        <tr><td>fr_thiophene</td><td>s1cccc1</td></tr>
        <tr><td>fr_thiazole</td><td>c1scnc1</td></tr>
        <tr><td>fr_oxazole</td><td>c1ocnc1</td></tr>
        <tr><td>fr_pyridine</td><td>n1ccccc1</td></tr>
        <tr><td>fr_piperdine</td><td>N1CCCCC1</td></tr>
        <tr><td>fr_piperzine</td><td>N1CCNCC1</td></tr>
        <tr><td>fr_morpholine</td><td>O1CCNCC1</td></tr>
        <tr><td>fr_lactam</td><td>N1C(=O)CC1</td></tr>
        <tr><td>fr_lactone</td><td>[C&R1](=O)[O&R1][C&R1]</td></tr>
        <tr><td>fr_tetrazole</td><td>c1nnnn1</td></tr>
        <tr><td>fr_epoxide</td><td>O1CC1</td></tr>
        <tr><td>fr_unbrch_alkane</td><td>[R0;D2][R0;D2][R0;D2][R0;D2]</td></tr>
        <tr><td>fr_bicyclic</td><td>[R2][R2]</td></tr>
        <tr><td>fr_benzene</td><td>c1ccccc1</td></tr>
        <tr><td>fr_phos_acid</td><td>[$(P(=[OX1])([$([OX2H]),$([OX1-]),$([OX2]P)])([$([OX2H]),$([OX1-]),$([OX2]P)])[$([OX2H]),$([OX1-]),$([OX2]P)]),$([P+]([OX1-])([$([OX2H]),$([OX1-]),$([OX2]P)])([$([OX2H]),$([OX1-]),$([OX2]P)])[$([OX2H]),$([OX1-]),$([OX2]P)])]</td></tr>
        <tr><td>fr_phos_ester</td><td>[$(P(=[OX1])([OX2][#6])([$([OX2H]),$([OX1-]),$([OX2][#6])])[$([OX2H]),$([OX1-]),$([OX2][#6]),$([OX2]P)]),$([P+]([OX1-])([OX2][#6])([$([OX2H]),$([OX1-]),$([OX2][#6])])[$([OX2H]),$([OX1-]),$([OX2][#6]),$([OX2]P)])]</td></tr>
        <tr><td>fr_nitro_arom</td><td>[$(c1(-[$([NX3](=O)=O),$([NX3+](=O)[O-])])ccccc1)]</td></tr>
        <tr><td>fr_nitro_arom_nonortho</td><td>[$(c1(-[$([NX3](=O)=O),$([NX3+](=O)[O-])])ccccc1);!$(cc-!:*)]</td></tr>
        <tr><td>fr_dihydropyridine</td><td>[$([NX3H1]1-C=C-C-C=C1),$([Nv3]1=C-C-C=C-C1),$([Nv3]1=C-C=C-C-C1),$([NX3H1]1-C-C=C-C=C1)]</td></tr>
        <tr><td>fr_phenol_noOrthoHbond</td><td>[$(c1(-[OX2H])ccccc1);!$(cc-!:[CH2]-[OX2H]);!$(cc-!:C(=O)[O;H1,-]);!$(cc-!:C(=O)-[NH2])]</td></tr>
        <tr><td>fr_Al_OH_noTert</td><td>[$(C-[OX2H]);!$([CX3](-[OX2H])=[OX1]);!$([CD4]-[OX2H])]</td></tr>
        <tr><td>fr_benzodiazepine</td><td>[c&R2]12[c&R1][c&R1][c&R1][c&R1][c&R2]1[N&R1][C&R1][C&R1][N&R1]=[C&R1]2</td></tr>
        <tr><td>fr_para_hydroxylation</td><td>[$([cH]1[cH]cc(c[cH]1)~[$([#8,$([#8]~[H,c,C])])]),$([cH]1[cH]cc(c[cH]1)~[$([#7X3,$([#7](~[H,c,C])~[H,c,C])])]),$([cH]1[cH]cc(c[cH]1)-!:[$([NX3H,$(NC(=O)[H,c,C])])])]</td></tr>
        <tr><td>fr_allylic_oxid</td><td>[$(C=C-C);!$(C=C-C-[N,O,S]);!$(C=C-C-C-[N,O]);!$(C12=CC(=O)CCC1C3C(C4C(CCC4)CC3)CC2)]</td></tr>
        <tr><td>fr_aryl_methyl</td><td>[$(a-[CH3]),$(a-[CH2]-[CH3]),$(a-[CH2]-[CH2]~[!N;!O]);!$(a(:a!:*):a!:*)]</td></tr>
        <tr><td>fr_Ndealkylation1</td><td>[$(N(-[CH3])-C-[$(C~O),$(C-a),$(C-N),$(C=C)]),$(N(-[CH2][CH3])-C-[$(C~O),$(C-a),$(C-N),$(C=C)])]</td></tr>
        <tr><td>fr_Ndealkylation2</td><td>[$([N&R1]1(-C)CCC1),$([N&R1]1(-C)CCCC1),$([N&R1]1(-C)CCCCC1),$([N&R1]1(-C)CCCCCC1),$([N&R1]1(-C)CCCCCCC1)]</td></tr>
        <tr><td>fr_alkyl_carbamate</td><td>C[NH1]C(=O)OC</td></tr>
        <tr><td>fr_ketone_Topliss</td><td>[$([CX3](=[OX1])(C)([c,C]));!$([CX3](=[OX1])([CH1]=C)[c,C])]</td></tr>
        <tr><td>fr_ArN</td><td>[$(a-[NX3H2]),$(a-[NH1][NH2]),$(a-C(=[OX1])[NH1][NH2]),$(a-C(=[NH])[NH2])]</td></tr>
        <tr><td>fr_HOCCN</td><td>[$([OX2H1][CX4][CX4H2][NX3&R1]),$([OH1][CX4][CX4H2][NX3][CX4](C)(C)C)]</td></tr>
	</tbody>
</table>
