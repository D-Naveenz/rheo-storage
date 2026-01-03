namespace Rheo.Storage.DefinitionsBuilder.ETL.Sluice
{
    internal static partial class CommonExtensions
    {
        /// <summary>
        /// Returns a collection of file extensions representing obscure, legacy, or highly specific file formats.
        /// This collection is limited to approximately 1000-1500 extensions.
        /// </summary>
        /// <remarks>The returned collection includes extensions for formats that are uncommon, outdated,
        /// or used in specialized domains, such as legacy office documents, retro computing disk images, network packet
        /// captures, and proprietary software files. This method is intended for scenarios where comprehensive file
        /// type recognition is required, including support for rare or obsolete formats.</remarks>
        /// <returns>An <see cref="IEnumerable{String}"/> containing file extension strings for obscure, legacy, or very specific
        /// file formats. The collection may include duplicate extensions if a format is relevant to multiple
        /// categories.</returns>
        private static IEnumerable<string> BuildLevel5()
        {
            #region Obscure & Legacy Archive & Disk Formats (~150 extensions)
            // Obscure compression and archiving formats
            yield return "?Q?";      // Files compressed by the SQ program[citation:1]
            yield return "alz";      // ALZip compressed file[citation:1]
            yield return "arc";      // Pre-Zip data compression format[citation:1]
            yield return "arj";      // Archived by Robert Jung[citation:1]
            yield return "bz2";      // bzip2 compressed file[citation:1]
            yield return "cpt";      // Compact Pro (Macintosh)[citation:1]
            yield return "sea";      // Compact Pro (Macintosh) - self-extracting archive[citation:1]
            yield return "egg";      // Alzip Egg Edition compressed file[citation:1]
            yield return "egt";      // EGT Universal Document[citation:1]
            yield return "ecab";     // EGT Compressed Folder (older)[citation:1]
            yield return "ezip";     // EGT Compressed Folder (alternative)[citation:1]
            yield return "ess";      // EGT SmartSense File[citation:1]
            yield return "flipchart"; // Promethean Flipchart Software file[citation:1]
            yield return "fun";      // Jigsaw ransomware encrypted file[citation:1]
            yield return "g3fc";     // Zstd based file container with encryption[citation:1]
            yield return "la";       // Lawrence Compiler Type file (.LAWRENCE)[citation:1]
            yield return "lbr";      // Library file[citation:1]
            yield return "lzh";      // LHA Lempel, Ziv, Huffman[citation:1]
            yield return "lz";       // lzip compressed file[citation:1]
            yield return "lzo";      // lzo compressed data[citation:1]
            yield return "lzma";     // Lempel–Ziv–Markov chain algorithm compressed file[citation:1]
            yield return "lzx";      // LZX compressed file[citation:1]
            yield return "mbw";      // MBRWizard archive[citation:1]
            yield return "mcaddon";  // Plugin for Minecraft Bedrock[citation:1]
            yield return "oar";      // OAR archive[citation:1]
            yield return "pak";      // Enhanced type of .ARC archive[citation:1]
            yield return "par";      // Parchive[citation:1]
            yield return "par2";     // Parchive 2[citation:1]
            yield return "paf";      // Portable Application File[citation:1]
            yield return "pea";      // PeaZip archive file[citation:1]
            yield return "pyk";      // PYK compressed file[citation:1]
            yield return "rax";      // Archive file created by RaX[citation:1]
            yield return "sitx";     // StuffIt X archive (Macintosh)[citation:1]
            yield return "wax";      // Wavexpress - ZIP alternative optimized for video[citation:1]
            yield return "xz";       // xz compressed files (LZMA/LZMA2)[citation:1]
            yield return "z";        // Unix compress file[citation:1]
            yield return "zoo";      // Archival format based on LZW[citation:1]

            // Retro disk and media image formats
            yield return "adf";      // Amiga floppy disk archive[citation:1]
            yield return "adz";      // GZip-compressed ADF file[citation:1]
            yield return "b5t";      // BlindWrite 5 image file[citation:1]
            yield return "b6t";      // BlindWrite 6 image file[citation:1]
            yield return "bwt";      // BlindWrite 4 image file[citation:1]
            yield return "cdi";      // DiscJuggler image file[citation:1]
            yield return "cif";      // Easy CD Creator .cif format[citation:1]
            yield return "c2d";      // Roxio-WinOnCD .c2d format[citation:1]
            yield return "daa";      // PowerISO .daa format (closed, Windows-only)[citation:1]
            yield return "d64";      // Commodore 64 floppy disk archive[citation:1]
            yield return "dms";      // Amiga disk-archiving system[citation:1]
            yield return "dsk";      // Floppy disk images (ZX Spectrum, Amstrad CPC)[citation:1]
            yield return "esd";      // Electronic Software Distribution (compressed/encrypted WIM)[citation:1]
            yield return "ffppkg";   // FreeFire Profile Export Package[citation:1]
            yield return "gho";      // Norton Ghost image[citation:1]
            yield return "ghs";      // Norton Ghost span file[citation:1]
            yield return "mds";      // Daemon Tools image descriptor[citation:1]
            yield return "mdx";      // Daemon Tools compressed image format[citation:1]
            yield return "nrg";      // Nero Burning ROM image[citation:1]
            yield return "sdi";      // Archives with "virtual disk" functionality[citation:1]
            yield return "swm";      // Split WIM File[citation:1]
            yield return "tib";      // Acronis True Image backup[citation:1]
            yield return "wim";      // Windows Imaging Format[citation:1]
            #endregion

            #region Failed & Legacy Document Formats (~100 extensions)
            // Legacy and failed word processor formats
            yield return "bravo";    // Xerox Alto WYSIWYG word processor[citation:7]
            yield return "vw";       // Volkswriter document[citation:7]
            yield return "vw3";      // Volkswriter 3 document[citation:7]
            yield return "awp";      // AppleWorks word processor (Apple II)[citation:7]
            yield return "cwk";      // ClarisWorks/AppleWorks (Mac)[citation:7]
            yield return "pfs";      // PFS:Write/Professional Write[citation:7]
            yield return "wri";      // Microsoft Write (Windows 3.x)[citation:7]
            yield return "sam";      // Ami Pro/Lotus Word Pro[citation:3]
            yield return "lwp";      // Lotus Word Pro[citation:3]
            yield return "mcw";      // Microsoft Word for Mac (pre-2004)[citation:3]
            yield return "wps";      // Microsoft Works Word Processor[citation:3]
            yield return "602";      // T602 document[citation:3]
            yield return "abw";      // AbiWord Document[citation:3]
            yield return "zabw";     // Compressed AbiWord Document[citation:3]
            yield return "hwp";      // Hangul (Korean word processor)[citation:3]
            yield return "cvt";      // GeoWrite document (Commodore 64)[citation:7]
            yield return "000";      // GeoWrite document (DOS)[citation:7]
            yield return "dca";      // Document Content Architecture (IBM)[citation:3]
            yield return "rft";      // Revisable-Form Text (IBM)[citation:3]
            yield return "ans";      // ANSI text art[citation:3]
            yield return "nfo";      // Warez information file[citation:3]
            yield return "diz";      // Description in zip file[citation:3]

            // Legacy spreadsheet and presentation formats
            yield return "qpw";      // Quattro Pro Spreadsheet[citation:3]
            yield return "wb1";      // Quattro Pro for Windows[citation:3]
            yield return "wb2";      // Quattro Pro for Windows version 6[citation:3]
            yield return "wb3";      // Quattro Pro for Windows version 7/8[citation:3]
            yield return "slk";      // SYLK (Symbolic Link) spreadsheet[citation:3]
            yield return "dif";      // Data Interchange Format[citation:3]
            yield return "sdc";      // StarOffice/OpenOffice Calc[citation:3]
            yield return "pm3";      // PageMaker 3 Document[citation:3]
            yield return "pm4";      // PageMaker 4 Document[citation:3]
            yield return "pm5";      // PageMaker 5 Document[citation:3]
            yield return "pm6";      // PageMaker 6 Document[citation:3]
            yield return "p65";      // PageMaker 6.5 Document[citation:3]
            yield return "fm";       // FrameMaker Document[citation:3]
            yield return "book";     // FrameMaker Book File[citation:3]
            yield return "mif";      // Maker Interchange Format[citation:3]
            #endregion

            #region Specialized Scientific & Geospatial Formats (~150 extensions)
            // General scientific data formats
            yield return "cdf";      // Common Data Format (NASA)[citation:5]
            yield return "eas3";     // Binary file format for structured data[citation:5]
            yield return "igor";     // IGOR data files[citation:5]
            yield return "ibw";      // IGOR Binary Wave[citation:5]
            yield return "nrrd";     // Nearly Raw Raster Data[citation:5]
            yield return "root";     // CERN data-analysis package format[citation:5]
            yield return "sdxf";     // Structured Data Exchange Format[citation:5]
            yield return "silo";     // Storage format for visualization (Lawrence Livermore)[citation:5]
            yield return "sdf";      // Simple Data format (George H. Fisher)[citation:5]
            yield return "xdf";      // Extensible Data Format[citation:5]
            yield return "xsil";     // Extensible Scientific Interchange Language[citation:5]

            // Astronomical and space science formats
            yield return "asdf";     // Advanced Scientific Data Format[citation:5]
            yield return "arn";      // Astronomical Research Network[citation:5]
            yield return "cpa";      // PRISM format[citation:5]
            yield return "fits";     // Flexible Image Transport System[citation:5][citation:9]
            yield return "psrfits";  // Pulsar data storage standard[citation:5]
            yield return "icer";     // ICER image compression[citation:5]
            yield return "nrm";      // NASA Raster Metafile[citation:5]
            yield return "odl";      // NASA Object Description Language[citation:5]
            yield return "pds";      // Planetary Data System[citation:5]
            yield return "pds4";     // PDS version 4[citation:5]
            yield return "votable";  // IVOA standard table format[citation:5]
            yield return "sbig";     // SBIG CCDOPS image[citation:5]
            yield return "saf";      // Standard Archive Format (USAF missile data)[citation:5]
            yield return "ndf";      // Starlink's Extensible N-Dimensional Data Format[citation:5]
            yield return "vicar";    // VICAR image format[citation:5]
            yield return "winmips";  // WinMiPS format[citation:5]

            // Biological and medical data formats
            yield return "ab1";      // Applied Biosystems chromatogram files[citation:5]
            yield return "abcd";     // Access to Biological Collection Data[citation:5]
            yield return "abcddna";  // ABCD DNA extension[citation:5]
            yield return "abcdefg";  // ABCD Extension For Geosciences[citation:5]
            yield return "ace";      // Sequence assembly format[citation:5]
            yield return "affy";     // Affymetrix Raw Intensity Format[citation:5]
            yield return "h5ad";     // AnnData Object[citation:5]
            yield return "arf";      // Axon Raw Format[citation:5]
            yield return "arlequin"; // ARLEQUIN Project Format[citation:5]
            yield return "axt";      // Axt Alignment Format[citation:5]
            yield return "bam";      // Binary compressed SAM format[citation:5]
            yield return "bed";      // Browser extensible display format[citation:5]
            yield return "bedgraph"; // BEDgraph format[citation:5]
            yield return "bigbed";   // Big Browser Extensible Data Format[citation:5]
            yield return "bigwig";   // Big Wiggle Format[citation:5]
            yield return "bam";      // Binary Alignement Map Format[citation:5]
            yield return "bpm";      // Binary Probe Map Format[citation:5]
            yield return "bsi";      // Binary sequence information Format[citation:5]
            yield return "bpx";      // Biological Pathway eXchange[citation:5]
            yield return "blat";     // BLAT alignment Format[citation:5]
            yield return "brix";     // BRIX generated O Format[citation:5]
            yield return "caf";      // Common Assembly Format[citation:5]
            yield return "castep";   // CASTEP format[citation:5]
            yield return "cellml";   // CellML format[citation:5]
            yield return "chadoxml"; // CHADO XML interchange Format[citation:5]
            yield return "chain";    // Chain Format for pairwise alignment[citation:5]
            yield return "charmm";   // CHARMM Card File Format[citation:5]
            yield return "clustal";  // CLUSTAL-W Alignment Format[citation:5]
            yield return "dendro";   // CLUSTAL-W Dendrogram Guide File Format[citation:5]
            yield return "cdt";      // Clustered Data Table Format[citation:5]
            yield return "cg";       // Complete Genomics format[citation:5]
            yield return "cram";     // CRAM format[citation:5]
            yield return "delta";    // DELTA (DEscription Language for TAxonomy)[citation:5]
            yield return "das";      // Distributed Sequence Annotation System[citation:5]
            yield return "dbn";      // Dot Bracket Notation (Vienna Format)[citation:5]
            yield return "embl";     // EMBL flatfile format[citation:5]
            yield return "eml";      // Environmental Markup Language[citation:5]
            yield return "encode";   // ENCODE Peak information Format[citation:5]
            yield return "fast5";    // FAST5 format[citation:5]
            yield return "fugeflow"; // FuGEFlow format[citation:5]
            yield return "fugeml";   // Functional Genomics Experiment Markup Language[citation:5]
            yield return "gatingml"; // Gating-ML[citation:5]
            yield return "gcdml";    // Genomic Contextual Data Markup Language[citation:5]
            yield return "gelml";    // Gel electrophoresis Markup Language[citation:5]
            yield return "genbank";  // GenBank flatfile format[citation:5]
            yield return "gff";      // General feature format[citation:5]
            yield return "gtf";      // Gene transfer format[citation:5]
            yield return "hmmer";    // HMMER format[citation:5]
            yield return "icb";      // ICM binary file Format[citation:5]
            yield return "ice";      // Image Cytometry Experiment[citation:5]
            yield return "ics";      // Image Cytometry Standard[citation:5]
            yield return "imzml";    // imaging mz Markup Language[citation:5]
            yield return "isatab";   // ISA-Tab (Investigation Study Assay Tabular)[citation:5]
            yield return "isnd";     // ISND sequence record XML[citation:5]
            yield return "kgml";     // KEGG Mark-up Language[citation:5]
            yield return "magetab";  // MAGE-Tab (MicroArray Gene Expression Tabular)[citation:5]
            yield return "mcl";      // Microbiological Common Language[citation:5]
            yield return "miaret";   // MIARE-TAB[citation:5]
            yield return "miniml";   // MINiML (MIAME Notation in Markup Language)[citation:5]
            yield return "miqas";    // MIQAS-TAB[citation:5]
            yield return "mitab";    // MITAB format[citation:5]
            yield return "mmcif";    // macromolecular Crystallographic Information File[citation:5]
            yield return "mzdata";   // mzData (deprecated)[citation:5]
            yield return "mzid";     // mzIdentML[citation:5]
            yield return "mzml";     // mzML[citation:5]
            yield return "mzquant";  // mzQuantML[citation:5]
            yield return "mzxml";    // mzXML (deprecated)[citation:5]
            yield return "ncd";      // Natural Collections Descriptions[citation:5]
            yield return "ndtf";     // Neurophysiology Data Translation Format[citation:5]
            yield return "neuroml";  // NeuroML (Neuroscience eXtensible Markup Language)[citation:5]
            yield return "nhx";      // New Hampshire eXtended Format[citation:5]
            yield return "nexus";    // NEXUS format[citation:5]
            yield return "nh";       // Newick tree Format[citation:5]
            yield return "ndf";      // Nimblegen Design File Format[citation:5]
            yield return "ngd";      // Nimblegen Gene Data Format[citation:5]
            yield return "nmrstar";  // NMR-STAR format[citation:5]
            yield return "odm";      // Operational Data Model[citation:5]
            yield return "obo";      // Open Biomedical Ontology Flat File Format[citation:5]
            yield return "pgf";      // Personal Genome SNP Format[citation:5]
            yield return "phd";      // Phred basecalling output[citation:5]
            yield return "phyloxml"; // phyloXML[citation:5]
            yield return "pcf";      // Pre-Clustering File Format[citation:5]
            yield return "prm";      // Protocol Representation Model[citation:5]
            yield return "psimi";    // PSI-MI XML[citation:5]
            yield return "psipar";   // PSI-PAR format[citation:5]
            yield return "rdml";     // Real-time PCR Data Markup Language[citation:5]
            yield return "sam";      // Sequence Alignment/Map format[citation:5]
            yield return "scf";      // Staden chromatogram files[citation:5]
            yield return "sbml";     // Systems Biology Markup Language[citation:5]
            yield return "sdd";      // Structured Descriptive Data[citation:5]
            yield return "sedml";    // SED-ML[citation:5]
            yield return "soft";     // Simple Omnibus Format in Text[citation:5]
            yield return "spml";     // Separation Markup Language[citation:5]
            yield return "sra";      // SRA-XML[citation:5]
            yield return "sbn";      // SBGN format[citation:5]
            yield return "sbrml";    // SBRML format[citation:5]
            yield return "stockholm"; // Stockholm Multiple Alignment Format[citation:5]
            yield return "tair";     // TAIR annotation data Format[citation:5]
            yield return "tapir";    // TDWG Access Protocol for Information Retrieval[citation:5]
            yield return "tcs";      // Taxonomic Concept transfer Schema[citation:5]
            yield return "traml";    // TraML (Transition Markup Language)[citation:5]
            yield return "uniprot";  // UniProtKB XML Format[citation:5]
            yield return "vcf";      // Variant Call Format[citation:5]
            yield return "wig";      // Wiggle Format[citation:5]

            // Chemical and crystallography formats
            yield return "ccp4";     // X-ray crystallography voxels[citation:5]
            yield return "cdx";      // ChemDraw file format[citation:5]
            yield return "cdxml";    // ChemDraw XML format[citation:5]
            yield return "chm";      // ChemDraw file format[citation:5]
            yield return "cif";      // Crystallographic Information File[citation:5]
            yield return "cml";      // Chemical markup language[citation:5]
            yield return "ctab";     // Chemical table file[citation:5]
            yield return "hitran";   // HITRAN spectroscopic data[citation:5]
            yield return "jcamp";    // JCAMP-DX format[citation:5]
            yield return "mop";      // MOPAC format[citation:5]
            yield return "mrc";      // Cryo-electron microscopy voxels[citation:5]
            yield return "mst";      // ACD/ChemSketch v1 file[citation:5]
            yield return "pdb";      // Protein Data Bank format[citation:5]
            yield return "rpt";      // Waters OpenLynx reports[citation:5]
            yield return "rxn";      // Reaction file format[citation:5]
            yield return "sk2";      // ACD/ChemSketch v2 file format[citation:5]
            yield return "skc";      // ISIS/Draw file format[citation:5]
            yield return "smiles";   // SMILES format[citation:5]
            yield return "spc";      // Spectroscopic Data[citation:5]
            yield return "tgf";      // ISIS/Draw reaction file format[citation:5]
            yield return "xyz";      // XYZ coordinate format[citation:5]

            // Earth and environmental sciences
            yield return "asdf";     // Adaptable Seismic Data Format[citation:5]
            yield return "ndtf";     // Network-Day Tape format[citation:5]
            yield return "quakeml";  // QuakeML[citation:5]
            yield return "seed";     // SEED format[citation:5]
            yield return "segd";     // SEG-D seismic data[citation:5]
            yield return "segy";     // SEG Y Reflection seismology data[citation:5]
            yield return "seisprov"; // SEIS-PROV[citation:5]
            yield return "station";  // StationXML[citation:5]
            yield return "hyt";      // AquiferTest format[citation:5]

            // Geospatial and geographic formats
            yield return "dem";      // Digital Elevation Model[citation:5]
            yield return "doq";      // Digital Orthophotos[citation:5]
            yield return "e00";      // ESRI ArcInfo Interchange File[citation:5]
            yield return "fgdc";     // Content Standard for Digital Geospatial Metadata[citation:5]
            yield return "geotiff";  // GeoTIFF[citation:5][citation:9]
            yield return "gml";      // Geography Markup Language[citation:5]
            yield return "hdfeos";   // HDF-Earth Observing System[citation:5]
            yield return "kml";      // Keyhole Markup Language[citation:5]
            yield return "mrsid";    // MrSID image format[citation:5]
            yield return "saif";     // Spatial Archive and Interchange Format[citation:5]
            yield return "sdts";     // Spatial Data Transfer Standard[citation:5]
            yield return "bag";      // Bathymetric Attributed Grid[citation:5]

            // Mathematical and statistical formats
            yield return "asciimath"; // AsciiMath format[citation:5]
            yield return "dot";      // Graph description language[citation:5]
            yield return "gexf";     // Graph Exchange XML Format[citation:5]
            yield return "graph6";   // graph6 encoding[citation:5]
            yield return "sparse6";  // sparse6 encoding[citation:5]
            yield return "graphml";  // Graph Markup Language[citation:5]
            yield return "prism";    // GraphPad Prism format[citation:5]
            yield return "jmp";      // JMP data format[citation:5]
            yield return "qda";      // KaleidaGraph format[citation:5]
            yield return "qdc";      // KaleidaGraph format[citation:5]
            yield return "life105";  // Life 1.05 format[citation:5]
            yield return "life106";  // Life 1.06 format[citation:5]
            yield return "macwave";  // MacWavelets format[citation:5]
            yield return "mcell";    // MCell format[citation:5]
            yield return "mathml";   // MathML format[citation:5]
            yield return "mat";      // MATLAB data format[citation:5]
            yield return "mdl";      // MATLAB Model[citation:5]
            yield return "slx";      // MATLAB Model (newer)[citation:5]
            yield return "minit";    // Minit format[citation:5]
            #endregion

            #region Niche CAD & Engineering Formats (~100 extensions)
            // Obscure CAD formats from Wikipedia's comprehensive list
            yield return "3dxml";    // Dassault Systèmes graphic representation[citation:1]
            yield return "acp";      // VA Software VA - Virtual Architecture CAD file[citation:1]
            yield return "aec";      // DataCAD drawing format[citation:1]
            yield return "aedt";     // Ansys Electronic Desktop - Project file[citation:1]
            yield return "ar";       // Ashlar-Vellum Argon - 3D Modeling[citation:1]
            yield return "art";      // ArtCAM model[citation:1]
            yield return "asc";      // BRL-CAD Geometry File (old ASCII format)[citation:1]
            yield return "brep";     // Open CASCADE 3D model (shape)[citation:1]
            yield return "c3d";      // C3D Toolkit File Format[citation:1]
            yield return "c3p";      // Construct3 Files[citation:1]
            yield return "ccc";      // CopyCAD Curves[citation:1]
            yield return "ccm";      // CopyCAD Model[citation:1]
            yield return "ccs";      // CopyCAD Session[citation:1]
            yield return "cad";      // CadStd format[citation:1]
            yield return "catdrawing"; // CATIA V5 Drawing document[citation:1]
            yield return "catpart";  // CATIA V5 Part document[citation:1]
            yield return "catproduct"; // CATIA V5 Assembly document[citation:1]
            yield return "catprocess"; // CATIA V5 Manufacturing document[citation:1]
            yield return "cgr";      // CATIA V5 graphic representation file[citation:1]
            yield return "ckd";      // KeyCreator CAD parts, assemblies, and drawings[citation:1]
            yield return "ckt";      // KeyCreator template file[citation:1]
            yield return "co";       // Ashlar-Vellum Cobalt - parametric drafting and 3D modeling[citation:1]
            yield return "dab";      // AppliCad 3D model CAD file[citation:1]
            yield return "drw";      // Caddie Early version of Caddie drawing[citation:1]
            yield return "dft";      // Solidedge Draft[citation:1]
            yield return "dgk";      // Delcam Geometry[citation:1]
            yield return "dmt";      // Delcam Machining Triangles[citation:1]
            yield return "dwb";      // VariCAD drawing file[citation:1]
            yield return "dwf";      // Autodesk's Web Design Format[citation:1]
            yield return "easm";     // SolidWorks eDrawings assembly file[citation:1]
            yield return "edrw";     // SolidWorks eDrawings file[citation:1]
            #endregion

            #region Obscure Application & System Packages (~80 extensions)
            // Specialized application package formats
            yield return "aab";      // Android App Bundle[citation:1]
            yield return "app";      // HarmonyOS APP Packs file format[citation:1]
            yield return "dmg";      // Macintosh disk image/application file[citation:1]
            yield return "hpkg";     // Haiku application package format[citation:1]
            yield return "ipg";      // iPod games package format[citation:1]
            yield return "sis";      // Symbian Application Package[citation:1]
            yield return "sisx";     // Symbian Signed Application Package[citation:1]
            yield return "xap";      // Windows Phone Application Package[citation:1]

            // Enterprise and specialized package formats
            yield return "ad1";      // AD1 Evidence file[citation:3]
            yield return "aes";      // AES Multiplus Comm format[citation:3]
            yield return "alis";     // ALIS format[citation:3]
            yield return "ampro";    // AMI Pro Draw[citation:3]
            yield return "ampl";     // AMPL Source Code[citation:3]
            yield return "apl";      // APL Source Code[citation:3]
            yield return "asn1";     // ASN.1 Source Code[citation:3]
            yield return "ats";      // ATS Source Code[citation:3]
            yield return "abaqus";   // Abaqus ODB format[citation:3]
            yield return "ability";  // Ability format[citation:3]
            yield return "acorn";    // Acorn RISC ARMovie video[citation:3]
            yield return "agda";     // Agda Source Code[citation:3]
            yield return "alloy";    // Alloy Source Code[citation:3]
            yield return "apex";     // Apex Source Code[citation:3]
            yield return "applescript"; // AppleScript Binary Source Code[citation:3]
            yield return "applix";   // Applix formats[citation:3]
            yield return "arduino";  // Arduino Source Code[citation:3]
            yield return "asciidoc"; // AsciiDoc Source Code[citation:3]
            yield return "aspectj";  // AspectJ Source Code[citation:3]
            yield return "blitzmax"; // BlitzMax Source Code[citation:3]
            yield return "bluespec"; // Bluespec Source Code[citation:3]
            yield return "brainfuck"; // Brainfuck Source Code[citation:3]
            yield return "brightscript"; // Brightscript Source Code[citation:3]
            yield return "ceylon";   // Ceylon Source Code[citation:3]
            yield return "chapel";   // Chapel Source Code[citation:3]
            yield return "clean";    // Clean Source Code[citation:3]
            yield return "clojure";  // Clojure Source Code[citation:3]
            yield return "coffeescript"; // CoffeeScript Source Code[citation:3]
            yield return "componentpascal"; // Component Pascal Source Code[citation:3]
            yield return "cool";     // Cool Source Code[citation:3]
            yield return "coq";      // Coq Source Code[citation:3]
            yield return "creole";   // Creole Source Code[citation:3]
            yield return "crystal";  // Crystal Source Code[citation:3]
            yield return "csound";   // Csound Source Code[citation:3]
            yield return "cuda";     // Cuda Source Code[citation:3]
            yield return "d";        // D Source Code[citation:3]
            yield return "eiffel";   // Eiffel Source Code[citation:3]
            yield return "erlang";   // Erlang Source Code[citation:3]
            yield return "fsharp";   // F# Source Code[citation:3]
            yield return "groovy";   // Groovy Source Code[citation:3]
            yield return "haskell";  // Haskell Source Code[citation:3]
            yield return "java";     // Java Source Code[citation:3]
            yield return "javascript"; // Javascript Source Code[citation:3]
            yield return "lua";      // Lua Source Code[citation:3]
            yield return "perl";     // Perl Source Code[citation:3]
            yield return "python";   // Python Source Code[citation:3]
            yield return "ruby";     // Ruby Source Code[citation:3]
            yield return "scala";    // Scala Source Code[citation:3]
            yield return "tcl";      // Tcl Source Code[citation:3]
            yield return "typescript"; // TypeScript Source Code[citation:3]
            yield return "vb";       // Visual Basic Source Code[citation:3]
            yield return "xml";      // XML Source Code[citation:3]
            #endregion

            #region Specialized Media & Container Formats (~100 extensions)
            // Obscure audio formats
            yield return "act";      // Adaptive Multi-Rate audio[citation:3]
            yield return "amr";      // Adaptive Multi-Rate audio[citation:3]
            yield return "awb";      // Adaptive Multi-Rate WideBand[citation:3]
            yield return "au";       // Sun/NeXT audio format[citation:3]
            yield return "snd";      // Generic sound file[citation:3]
            yield return "ulaw";     // μ-law audio[citation:3]
            yield return "vox";      // Dialogic ADPCM audio[citation:3]
            yield return "dss";      // Digital Speech Standard[citation:3]
            yield return "dvf";      // Sony Voice File[citation:3]
            yield return "msv";      // Sony Memory Stick Voice[citation:3]
            yield return "ivs";      // 3GPP2 audio format[citation:3]
            yield return "m4b";      // MPEG-4 audiobook[citation:3]
            yield return "m4p";      // MPEG-4 protected audio[citation:3]
            yield return "m4r";      // MPEG-4 ringtone[citation:3]
            yield return "mmf";      // Samsung ringtone format[citation:3]
            yield return "nmf";      // Nokia ringtone format[citation:3]
            yield return "xmf";      // Extended Mobile File[citation:3]
            yield return "mxmf";     // Mobile XMF format[citation:3]
            yield return "imy";      // iMelody ringtone format[citation:3]
            yield return "rtx";      // Ringtone text transfer format[citation:3]
            yield return "ota";      // Over-the-air ringtone format[citation:3]
            yield return "qcp";      // Qualcomm PureVoice format[citation:3]
            yield return "sln";      // Asterisk raw audio format[citation:3]
            yield return "vms";      // Sony PS2 audio format[citation:3]
            yield return "voc";      // Creative Voice format[citation:3]
            yield return "8svx";     // 8-bit sampled voice (Amiga)[citation:3]
            yield return "nist";     // NIST audio format[citation:3]
            yield return "sph";      // NIST sphere audio format[citation:3]
            yield return "ircam";    // IRCAM sound format[citation:3]
            yield return "sd2";      // Sound Designer II format[citation:3]
            yield return "avr";      // Audio Visual Research format[citation:3]
            yield return "paf";      // Ensoniq PARIS audio format[citation:3]
            yield return "svx";      // Amiga IFF-8SVX audio[citation:3]
            yield return "wve";      // Psion Series 3 audio format[citation:3]
            yield return "txw";      // Yamaha TX-16W sampler format[citation:3]
            yield return "sds";      // MIDI sample dump format[citation:3]
            yield return "mpc";      // Musepack audio format[citation:3]
            yield return "ofr";      // OptimFROG audio format[citation:3]
            yield return "ofs";      // OptimFROG streamable format[citation:3]
            yield return "spx";      // Ogg Speex audio format[citation:3]
            yield return "tta";      // True Audio lossless format[citation:3]
            yield return "wv";       // WavPack audio format[citation:3]
            yield return "wvc";      // WavPack correction file[citation:3]

            // Specialized video and container formats
            yield return "3g2";      // 3GPP2 multimedia container[citation:3]
            yield return "3gp";      // 3GPP multimedia container[citation:3]
            yield return "f4v";      // Flash MP4 video[citation:3]
            yield return "f4p";      // Flash protected MP4[citation:3]
            yield return "f4a";      // Flash MP4 audio[citation:3]
            yield return "f4b";      // Flash MP4 audiobook[citation:3]
            yield return "nsv";      // Nullsoft Streaming Video[citation:3]
            yield return "roq";      // Quake III Arena video[citation:3]
            yield return "smk";      // Smacker video format[citation:3]
            yield return "bik";      // Bink video format[citation:3]
            yield return "bk2";      // Bink video 2 format[citation:3]
            yield return "str";      // PlayStation video format[citation:3]
            yield return "pss";      // PlayStation video format[citation:3]
            yield return "tod";      // JVC Everio video format[citation:3]
            yield return "mod";      // JVC MOD video format[citation:3]
            yield return "xesc";     // Sony XAVC S format[citation:3]
            yield return "mcf";      // Matroska Container Format (old)[citation:3]
            yield return "264";      // H.264 elementary stream[citation:3]
            yield return "265";      // H.265 elementary stream[citation:3]
            yield return "evt";      // MPEG elementary stream video[citation:3]
            yield return "m1v";      // MPEG-1 video[citation:3]
            yield return "m2v";      // MPEG-2 video[citation:3]
            yield return "mpv";      // MPEG elementary stream[citation:3]
            yield return "tts";      // MPEG Transport Stream (trick mode)[citation:3]
            yield return "vro";      // DVD-VR video format[citation:3]
            yield return "ogv";      // Ogg video container[citation:3]
            yield return "ogm";      // Ogg media (old)[citation:3]
            yield return "anx";      // Ogg Annodex[citation:3]
            yield return "axa";      // Ogg Annodex audio[citation:3]
            yield return "axv";      // Ogg Annodex video[citation:3]
            #endregion

            #region System & Network Specialized Formats (~80 extensions)
            // Network and packet capture formats
            yield return "pcap";     // Packet capture format
            yield return "pcapng";   // Next generation packet capture
            yield return "cap";      // Packet capture (alternative)
            yield return "dmp";      // Memory dump/crash dump
            yield return "hdmp";     // Minidump format
            yield return "mdmp";     // Minidump format
            yield return "core";     // Core dump (Unix)
            yield return "crash";    // Crash report file
            yield return "stackdump"; // Stack dump file
            yield return "tombstone"; // Android crash report

            // System and configuration files
            yield return "plist";    // Property List (Apple)[citation:1]
            yield return "vdhx";     // Virtual disk created by Hyper-V[citation:1]
            yield return "crdownload"; // Chrome partial download file[citation:1]
            yield return "part";     // Partial download file
            yield return "partial";  // Partial download file
            yield return "download"; // Download in progress
            yield return "tmp";      // Temporary file
            yield return "temp";     // Temporary file
            yield return "bak";      // Backup file
            yield return "backup";   // Backup file
            yield return "old";      // Old version
            yield return "orig";     // Original backup
            yield return "new";      // New version
            yield return "swp";      // Swap file
            yield return "swo";      // Swap file (alternative)
            yield return "swn";      // Swap file (alternative)
            yield return "pid";      // Process ID file
            yield return "lock";     // Lock file
            yield return "lck";      // Lock file (alternative)
            yield return "sem";      // Semaphore file
            yield return "socket";   // Socket file
            yield return "fifo";     // FIFO file
            yield return "ctl";      // Control file
            yield return "conf";     // Configuration file
            yield return "config";   // Configuration file
            yield return "properties"; // Properties file
            yield return "prefs";    // Preferences file
            yield return "settings"; // Settings file
            yield return "ini";      // Initialization file[citation:3]
            yield return "inf";      // Setup information file[citation:3]
            yield return "reg";      // Registry file[citation:3]
            yield return "pol";      // Policy file[citation:3]
            yield return "adm";      // Administrative template[citation:3]
            yield return "admx";     // Administrative template XML[citation:3]
            yield return "adml";     // Administrative template language[citation:3]
            yield return "msc";      // Microsoft Management Console[citation:3]
            yield return "mscf";     // Microsoft Management Console saved[citation:3]
            yield return "msp";      // Windows Installer patch[citation:3]
            yield return "mst";      // Windows Installer transform[citation:3]
            yield return "msm";      // Windows Installer merge module[citation:3]
            yield return "cat";      // Security catalog file
            #endregion

            #region Database & Enterprise Specialized Formats (~60 extensions)
            // Legacy and specialized database formats
            yield return "dbf";      // dBASE database file[citation:3]
            yield return "nsf";      // Lotus Notes database[citation:3]
            yield return "ntf";      // Lotus Notes template[citation:3]
            yield return "box";      // Lotus Notes mailbox[citation:3]
            yield return "edb";      // Exchange database[citation:3]
            yield return "stm";      // Exchange streaming media[citation:3]
            yield return "mdb";      // Microsoft Access database
            yield return "accdb";    // Microsoft Access database (newer)
            yield return "accde";    // Microsoft Access execute-only
            yield return "accdr";    // Microsoft Access runtime
            yield return "accdt";    // Microsoft Access database template
            yield return "accdu";    // Microsoft Access add-in
            yield return "ade";      // Microsoft Access project
            yield return "adp";      // Microsoft Access data project
            yield return "laccdb";   // Microsoft Access lock file
            yield return "maf";      // Microsoft Access form
            yield return "mar";      // Microsoft Access report
            yield return "maw";      // Microsoft Access data access page
            yield return "mdn";      // Blank Access template
            yield return "mdt";      // Microsoft Access add-in data
            yield return "mdw";      // Microsoft Access workgroup
            yield return "sdf";      // SQL Server Compact database
            yield return "udl";      // Universal Data Link
            yield return "dsn";      // Data Source Name
            yield return "ora";      // Oracle configuration
            yield return "tns";      // Oracle Net configuration
            yield return "pks";      // Oracle Package Spec
            yield return "pkb";      // Oracle Package Body
            yield return "trc";      // Oracle/SQL Server trace
            yield return "aud";      // Oracle audit file
            yield return "dmp";      // Oracle database export
            yield return "exp";      // Oracle export
            yield return "imp";      // Oracle import
            yield return "rman";     // Oracle Recovery Manager
            yield return "arc";      // Oracle archive log
            yield return "rdo";      // Oracle Forms resource
            yield return "fmx";      // Oracle Forms executable
            yield return "mmb";      // Oracle Forms menu
            yield return "olb";      // Oracle Forms library
            yield return "pld";      // Oracle Forms PL/SQL library
            yield return "pll";      // Oracle Forms PL/SQL library (linked)
            yield return "plx";      // Oracle Forms PL/SQL (compiled)
            yield return "realm";    // Realm Mobile database
            yield return "crypt";    // WhatsApp encrypted database
            yield return "crypt12";  // WhatsApp encrypted database v12
            yield return "crypt14";  // WhatsApp encrypted database v14
            #endregion

            #region Security & Digital Forensics Formats (~40 extensions)
            // Security and forensics formats
            yield return "p7s";      // PKCS#7 signature
            yield return "p7m";      // PKCS#7 message
            yield return "p7c";      // PKCS#7 certificate
            yield return "p7b";      // PKCS#7 certificate bundle
            yield return "spc";      // Software Publisher Certificate
            yield return "jks";      // Java Keystore
            yield return "keystore"; // Java Keystore
            yield return "truststore"; // Java Truststore
            yield return "bks";      // Bouncy Castle Keystore
            yield return "p8";       // PKCS#8 private key
            yield return "pk8";      // PKCS#8 private key
            yield return "crl";      // Certificate Revocation List
            yield return "ocsp";     // OCSP response
            yield return "sig";      // Signature file
            yield return "asc";      // ASCII armored (PGP)
            yield return "gpg";      // GnuPG file
            yield return "pgp";      // Pretty Good Privacy file
            yield return "pub";      // Public key file
            yield return "sec";      // Secret key file
            yield return "skr";      // Secret key ring
            yield return "pkr";      // Public key ring
            yield return "nkr";      // Netware key ring
            yield return "jwt";      // JSON Web Token
            yield return "jwks";     // JSON Web Key Set
            yield return "pwd";      // Password file
            yield return "htpasswd"; // HTTP password file
            yield return "kdbx";     // KeePass database
            yield return "kdb";      // KeePass 1 database
            yield return "agilekeychain"; // 1Password format
            yield return "opvault";  // 1Password vault format
            yield return "bitwarden"; // Bitwarden export
            yield return "lastpass"; // LastPass export
            yield return "enex";     // Evernote export
            yield return "enlx";     // Evernote export format
            #endregion

            #region Miscellaneous Highly Specialized Formats (~40 extensions)
            // Various other specialized formats
            yield return "gcode";    // G-code (CNC machining)
            yield return "nc";       // Numerical control
            yield return "apt";      // Automatically Programmed Tool
            yield return "cls";      // LaTeX class file
            yield return "sty";      // LaTeX style file
            yield return "bib";      // BibTeX bibliography
            yield return "bst";      // BibTeX style
            yield return "dtx";      // Documented LaTeX
            yield return "ins";      // LaTeX installation file
            yield return "ltx";      // LaTeX document
            yield return "tex";      // TeX document
            yield return "mf";       // Metafont
            yield return "tfm";      // TeX font metrics
            yield return "vf";       // Virtual font
            yield return "enc";      // Encoding file
            yield return "map";      // Font mapping
            yield return "fd";       // Font definition
            yield return "csl";      // Citation Style Language
            yield return "ris";      // Research Information Systems
            yield return "enw";      // EndNote format
            yield return "ens";      // EndNote style
            yield return "enl";      // EndNote library
            yield return "rdf";      // Resource Description Framework
            yield return "tei";      // Text Encoding Initiative
            yield return "mods";     // Metadata Object Description Schema
            yield return "marc";     // MARC record
            yield return "mrc";      // MARC record (binary)
            yield return "mrk";      // MARC record (text)
            yield return "iso";      // ISO disk image
            yield return "cue";      // Cuesheet for disk images
            yield return "ccd";      // CloneCD control file
            yield return "sub";      // CloneCD subchannel file
            yield return "mdf";      // Media Disc Image data file
            yield return "isz";      // Compressed ISO image
            yield return "udf";      // Universal Disk Format
            yield return "cso";      // Compressed ISO image
            yield return "ecm";      // Error Code Modeler format
            #endregion
        }
    }
}
