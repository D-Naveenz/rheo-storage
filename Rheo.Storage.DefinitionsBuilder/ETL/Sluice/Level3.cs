namespace Rheo.Storage.DefinitionsBuilder.ETL.Sluice
{
    internal static partial class CommonExtensions
    {
        /// <summary>
        /// Returns a collection of file extension strings representing specialized but commonly used software formats
        /// across various domains. This collection is limited to approximately 500-600 extensions.
        /// </summary>
        /// <remarks>The returned extensions include formats from business and finance, engineering and
        /// CAD, GIS and mapping, medical and scientific, game development, backup and system, multimedia containers,
        /// compression and packaging, email and communication, and security and certificates. This method is intended
        /// to provide a comprehensive set of extensions for applications that need to recognize or filter a wide range
        /// of specialized file types.</remarks>
        /// <returns>An <see cref="IEnumerable{String}"/> containing file extension strings for specialized but common software
        /// formats. The collection includes, but is not limited to, extensions used in accounting, databases, CAD, GIS,
        /// medical imaging, game assets, system files, multimedia containers, compression archives, email storage, and
        /// security certificates.</returns>
        private static IEnumerable<string> BuildLevel3()
        {
            #region Business, Finance & Databases (~80 extensions)
            // Accounting & Financial data formats[citation:2][citation:8]
            yield return "qbo";  // QuickBooks Online statement
            yield return "qfx";  // Quicken Interchange Format
            yield return "qif";  // Quicken Interchange Format
            yield return "iif";  // Intuit Interchange Format
            yield return "qbj";  // QuickBooks Journal Entries[citation:2]
            yield return "qbm";  // QuickBooks Portable Company File[citation:2]
            yield return "qbr";  // QuickBooks Report Template[citation:2]
            yield return "qbx";  // QuickBooks Accountant's Transfer[citation:2]
            yield return "qby";  // QuickBooks Accountant's Import[citation:2]
            yield return "qwc";  // QuickBooks Web Connector[citation:2]
            yield return "qsm";  // QuickBooks Statement Writer[citation:2]
            yield return "qss";  // QuickBooks Statement Style[citation:2]
            yield return "qst";  // QuickBooks Statement Template[citation:2]
            yield return "mt940"; // Standard SWIFT bank statement format
            yield return "bai2"; // Cash management balance format
            yield return "ofx";  // Open Financial Exchange
            yield return "ofc";  // Open Financial Connectivity
            yield return "aba";  // Australian Bankers' Association
            yield return "camt"; // ISO 20022 Bank statement
            yield return "xbrl"; // eXtensible Business Reporting Language
            yield return "ixbrl"; // Inline XBRL

            // Database & data interchange formats[citation:3]
            yield return "mdf";  // SQL Server Database File
            yield return "ndf";  // SQL Server Secondary Database
            yield return "ldf";  // SQL Server Transaction Log
            yield return "bak";  // Database Backup (SQL Server)
            yield return "fdb";  // Firebird Database
            yield return "gdb";  // InterBase/GPS Database
            yield return "ib";   // InterBase Database
            yield return "pdb";  // Program Database (debug) / Palm Database
            yield return "sqlite"; // SQLite Database
            yield return "sqlite3"; // SQLite 3 Database
            yield return "db3";  // SQLite Database
            yield return "db-wal"; // SQLite Write-Ahead Log
            yield return "db-shm"; // SQLite Shared Memory
            yield return "db-journal"; // SQLite Rollback Journal
            yield return "myd";  // MySQL Data File
            yield return "myi";  // MySQL Index File
            yield return "ibd";  // MySQL InnoDB Table
            yield return "frm";  // MySQL Format File
            yield return "dbf";  // dBASE Database
            yield return "dbt";  // dBASE Text Memo
            yield return "nsf";  // Lotus Notes Database
            yield return "ntf";  // Lotus Notes Template
            yield return "box";  // Lotus Notes Mailbox
            yield return "edb";  // Exchange Database
            yield return "stm";  // Exchange Streaming Media
            yield return "pst";  // Outlook Personal Folders (also Level 1)
            yield return "ost";  // Outlook Offline Folders
            yield return "accde"; // Access Execute-Only Database
            yield return "accdr"; // Access Runtime Application
            yield return "accdt"; // Access Database Template
            yield return "accdu"; // Access Add-in
            yield return "ade";  // Access Project
            yield return "adp";  // Access Data Project
            yield return "laccdb"; // Access Lock File
            yield return "maf";  // Access Form
            yield return "mar";  // Access Report
            yield return "maw";  // Access Data Access Page
            yield return "mdn";  // Blank Access Template
            yield return "mdt";  // Access Add-in Data
            yield return "mdw";  // Access Workgroup
            yield return "sdf";  // SQL Server Compact Database
            yield return "udl";  // Universal Data Link
            yield return "dsn";  // Data Source Name
            yield return "ora";  // Oracle Configuration
            yield return "tns";  // Oracle Net Configuration
            yield return "pks";  // Oracle Package Spec
            yield return "pkb";  // Oracle Package Body
            yield return "trc";  // Oracle Trace / SQL Server Trace[citation:3]
            yield return "aud";  // Oracle Audit File
            yield return "dmp";  // Oracle Database Export
            yield return "exp";  // Oracle Export
            yield return "imp";  // Oracle Import
            yield return "rman"; // Oracle Recovery Manager
            yield return "arc";  // Oracle Archive Log
            yield return "rdo";  // Oracle Forms Resource
            yield return "fmx";  // Oracle Forms Executable
            yield return "mmb";  // Oracle Forms Menu
            yield return "olb";  // Oracle Forms Library
            yield return "pld";  // Oracle Forms PL/SQL Library
            yield return "pll";  // Oracle Forms PL/SQL Library (linked)
            yield return "plx";  // Oracle Forms PL/SQL (compiled)
            yield return "realm"; // Realm Mobile Database
            yield return "crypt"; // WhatsApp Encrypted Database[citation:3]
            yield return "crypt12"; // WhatsApp Encrypted Database v12[citation:3]
            yield return "crypt14"; // WhatsApp Encrypted Database v14[citation:3]
            #endregion

            #region Engineering, CAD & 3D Modeling (~110 extensions)
            // Native CAD formats[citation:4][citation:9]
            yield return "dgn";  // MicroStation Design[citation:9]
            yield return "dwg";  // AutoCAD Drawing (also Level 2)[citation:4]
            yield return "dxf";  // Drawing Exchange Format[citation:9]
            yield return "catpart"; // CATIA Part[citation:4][citation:9]
            yield return "catproduct"; // CATIA Assembly[citation:4][citation:9]
            yield return "catdrawing"; // CATIA Drawing
            yield return "cgr";  // CATIA Graphic[citation:9]
            yield return "model"; // CATIA V4[citation:9]
            yield return "prt";  // NX/Unigraphics/Creo Part[citation:4][citation:9]
            yield return "asm";  // Creo/NX Assembly[citation:4][citation:9]
            yield return "jt";   // Jupiter Tessellation (Siemens)[citation:4][citation:9]
            yield return "j_t";  // JT alternative[citation:9]
            yield return "sldprt"; // SOLIDWORKS Part[citation:4][citation:9]
            yield return "sldasm"; // SOLIDWORKS Assembly[citation:4][citation:9]
            yield return "slddrw"; // SOLIDWORKS Drawing
            yield return "ipt";  // Inventor Part[citation:4]
            yield return "iam";  // Inventor Assembly[citation:4]
            yield return "par";  // Solid Edge Part
            yield return "psm";  // Solid Edge Sheet Metal
            yield return "3dm";  // Rhino 3D Model[citation:9]

            // Neutral CAD formats[citation:4][citation:9]
            yield return "stp";  // STEP (ISO 10303)[citation:4][citation:9]
            yield return "step"; // STEP alternative[citation:4][citation:9]
            yield return "igs";  // IGES[citation:4][citation:9]
            yield return "iges"; // IGES alternative[citation:4][citation:9]
            yield return "qif";  // Quality Information Framework[citation:4]
            yield return "vda";  // VDA-FS Surface Model[citation:9]

            // Geometric kernel formats[citation:9]
            yield return "x_t";  // Parasolid Text[citation:9]
            yield return "x_b";  // Parasolid Binary[citation:9]
            yield return "sat";  // ACIS Text[citation:9]
            yield return "sab";  // ACIS Binary[citation:9]
            yield return "asat"; // ACIS Assembly Text[citation:9]
            yield return "asab"; // ACIS Assembly Binary[citation:9]
            yield return "xcgm"; // CATIA CGM Kernel[citation:9]

            // Tessellated & 3D printing formats[citation:4][citation:9]
            yield return "stl";  // Stereolithography (3D Printing)[citation:4][citation:9]
            yield return "obj";  // Wavefront Object[citation:9]
            yield return "fbx";  // Autodesk Filmbox[citation:9]
            yield return "3ds";  // 3D Studio Scene
            yield return "max";  // 3ds Max Scene (also Level 2)
            yield return "blend"; // Blender Project (also Level 2)
            yield return "mb";   // Maya Binary (also Level 2)
            yield return "ma";   // Maya ASCII (also Level 2)
            yield return "c4d";  // Cinema 4D (also Level 2)
            yield return "lwo";  // LightWave Object
            yield return "lws";  // LightWave Scene
            yield return "ply";  // Polygon File Format[citation:9]
            yield return "off";  // Object File Format
            yield return "wrl";  // VRML World[citation:9]
            yield return "vrml"; // VRML alternative
            yield return "x3d";  // X3D File
            yield return "x3dz"; // Compressed X3D
            yield return "dae";  // COLLADA Digital Asset[citation:9]
            yield return "collada"; // COLLADA alternative
            yield return "3dxml"; // Dassault 3DXML[citation:9]
            yield return "u3d";  // Universal 3D[citation:9]
            yield return "prc";  // Product Representation Compact[citation:9]
            yield return "3mf";  // 3D Manufacturing Format[citation:4][citation:9]
            yield return "amf";  // Additive Manufacturing Format
            yield return "ctm";  // OpenCTM Compressed Triangle Mesh

            // PCB & electronics design
            yield return "brd";  // Eagle/Altium Board
            yield return "sch";  // Eagle/Altium Schematic
            yield return "pcb";  // PCB Layout file
            yield return "kicad_pcb"; // KiCad PCB
            yield return "kicad_sch"; // KiCad Schematic
            yield return "kicad_mod"; // KiCad Module
            yield return "dsn";  // OrCAD Design
            yield return "opj";  // OrCAD Project
            yield return "lib";  // Component Library
            yield return "net";  // Netlist

            // Engineering analysis & simulation
            yield return "inp";  // Abaqus Input
            yield return "odb";  // Abaqus Output Database
            yield return "cae";  // Abaqus CAE Model
            yield return "ans";  // ANSYS Input
            yield return "cdb";  // ANSYS Input Deck
            yield return "rst";  // ANSYS Results
            yield return "db";   // ANSYS Database
            yield return "dat";  // ANSYS Data
            yield return "mac";  // ANSYS Macro
            yield return "lsdyna"; // LS-DYNA Input
            yield return "key";  // LS-DYNA Keyword
            yield return "dyn";  // LS-DYNA alternative
            yield return "nas";  // NASTRAN Input
            yield return "bdf";  // NASTRAN Bulk Data
            yield return "op2";  // NASTRAN Output
            yield return "f06";  // NASTRAN Output
            yield return "unv";  // Universal File Format
            yield return "med";  // MED Mesh Data
            yield return "msh";  // Gmsh Mesh
            yield return "cas";  // FLUENT Case
            yield return "dat";  // FLUENT Data
            yield return "jou";  // FLUENT Journal
            yield return "trn";  // FLUENT Transaction
            yield return "cfx";  // CFX Input
            yield return "def";  // CFX Definition
            yield return "res";  // CFX Results
            yield return "ccm";  // STAR-CCM+ File
            yield return "sim";  // STAR-CCM+ Simulation
            #endregion

            #region GIS, Mapping & Geospatial (~70 extensions)
            // Vector formats[citation:5][citation:10]
            yield return "shp";  // ESRI Shapefile geometry[citation:5][citation:10]
            yield return "shx";  // Shapefile index[citation:5][citation:10]
            yield return "dbf";  // Shapefile attributes[citation:5][citation:10]
            yield return "prj";  // Shapefile projection[citation:10]
            yield return "sbn";  // Shapefile spatial index[citation:10]
            yield return "sbx";  // Shapefile spatial index alternative[citation:10]
            yield return "cpg";  // Shapefile code page
            yield return "shp.xml"; // Shapefile metadata[citation:10]
            yield return "gdb";  // File Geodatabase folder
            yield return "gpx";  // GPS Exchange Format[citation:10]
            yield return "kml";  // Keyhole Markup Language[citation:5][citation:10]
            yield return "kmz";  // Compressed KML[citation:5][citation:10]
            yield return "geojson"; // Geographic JSON[citation:5][citation:10]
            yield return "json"; // JSON (geospatial variant)[citation:10]
            yield return "topojson"; // TopoJSON[citation:5]
            yield return "gml";  // Geography Markup Language[citation:10]
            yield return "tab";  // MapInfo Table[citation:10]
            yield return "dat";  // MapInfo Data[citation:10]
            yield return "map";  // MapInfo Map[citation:10]
            yield return "id";   // MapInfo Index[citation:10]
            yield return "ind";  // MapInfo Index[citation:10]
            yield return "mif";  // MapInfo Interchange Format
            yield return "mid";  // MapInfo Interchange Data
            yield return "osm";  // OpenStreetMap XML[citation:10]
            yield return "pbf";  // Protocolbuffer Binary Format (OSM)
            yield return "ov2";  // TomTom POI
            yield return "itn";  // TomTom Itinerary
            yield return "plt";  // OziExplorer Track
            yield return "wpt";  // OziExplorer Waypoint
            yield return "rte";  // OziExplorer Route
            yield return "axf";  // AlpineQuest Map
            yield return "rmap"; // AlpineQuest Package

            // Raster & imagery formats[citation:5][citation:10]
            yield return "tif";  // GeoTIFF[citation:5][citation:10]
            yield return "tiff"; // GeoTIFF alternative[citation:5][citation:10]
            yield return "tfw";  // TIFF World File[citation:10]
            yield return "twf";  // TIFF World File alternative
            yield return "jgw";  // JPEG World File
            yield return "pgw";  // PNG World File
            yield return "bpw";  // BMP World File
            yield return "wld";  // ESRI World File
            yield return "img";  // ERDAS Imagine[citation:5][citation:10]
            yield return "ige";  // ERDAS Imagine Geo
            yield return "hdr";  // ENVI/ERDAS Header
            yield return "rst";  // IDRISI Raster[citation:10]
            yield return "rdc";  // IDRISI Documentation[citation:10]
            yield return "vct";  // IDRISI Vector[citation:10]
            yield return "vdc";  // IDRISI Vector Doc[citation:10]
            yield return "dem";  // Digital Elevation Model
            yield return "dtm";  // Digital Terrain Model
            yield return "dsm";  // Digital Surface Model
            yield return "dt0";  // DTED Level 0
            yield return "dt1";  // DTED Level 1
            yield return "dt2";  // DTED Level 2
            yield return "hgt";  // SRTM Elevation
            yield return "asc";  // ASCII Grid[citation:10]
            yield return "grd";  // Surfer Grid
            yield return "blx";  // MBTiles Raster
            yield return "mbtiles"; // Mapbox Tileset
            yield return "bil";  // Band Interleaved by Line[citation:10]
            yield return "bip";  // Band Interleaved by Pixel[citation:10]
            yield return "bsq";  // Band Sequential[citation:10]
            yield return "sid";  // MrSID Compressed[citation:5]
            yield return "sdw";  // MrSID World
            yield return "ecw";  // Enhanced Compression Wavelet[citation:5][citation:10]
            yield return "jp2";  // JPEG2000 (geospatial)[citation:5][citation:10]
            yield return "j2k";  // JPEG2000 alternative
            yield return "nitf"; // National Imagery Transmission Format
            yield return "nsf";  // NITF Subheader

            // GIS project & workspace files
            yield return "mxd";  // ArcMap Document
            yield return "mxt";  // ArcMap Template
            yield return "pmf";  // Published Map
            yield return "lyr";  // ArcGIS Layer
            yield return "lpk";  // Layer Package
            yield return "gpk";  // Geoprocessing Package
            yield return "sxd";  // ArcScene Document
            yield return "3dd";  // ArcGlobe Document
            yield return "nmf";  // ArcGIS Explorer Map
            yield return "qgs";  // QGIS Project[citation:5]
            yield return "qgz";  // Compressed QGIS Project[citation:5]
            yield return "qlr";  // QGIS Layer Definition
            yield return "qml";  // QGIS Style
            yield return "mmz";  // MapManager Project
            yield return "gws";  // Global Mapper Workspace
            #endregion

            #region Medical, Scientific & Research (~60 extensions)
            // Medical imaging[citation:6]
            yield return "dcm";  // DICOM Image[citation:6]
            yield return "dicom"; // DICOM alternative
            yield return "ima";  // DICOM IMA
            yield return "img";  // Analyze/ECAT Image[citation:6]
            yield return "hdr";  // Analyze Header[citation:6]
            yield return "nii";  // NIfTI Image[citation:6]
            yield return "nii.gz"; // Compressed NIfTI
            yield return "hdr";  // NIfTI Header (old)
            yield return "img";  // NIfTI Image (old)
            yield return "mnc";  // MINC Image[citation:6]
            yield return "mgh";  // FreeSurfer MGH
            yield return "mgz";  // FreeSurfer Compressed MGH
            yield return "mhd";  // MetaImage Header
            yield return "raw";  // MetaImage Raw Data
            yield return "zraw"; // Compressed Raw
            yield return "par";  // Philips PAR/REC
            yield return "rec";  // Philips REC
            yield return "spr";  // StereoPlan
            yield return "xif";  // eFilm Image
            yield return "vff";  // Sun Microsystems VFF
            yield return "pic";  // MRI Pixel
            yield return "acr";  // ACR-NEMA
            yield return "his";  // Hologic HIS
            yield return "lif";  // Leica LIF

            // Microscopy & imaging
            yield return "lif";  // Leica LIF
            yield return "lei";  // Leica LEI
            yield return "ics";  // Image Cytometry Standard
            yield return "ids";  // Image Data Structure
            yield return "nd2";  // Nikon NIS-Elements
            yield return "nd";   // Nikon Elements Data
            yield return "nef";  // Nikon Elements File
            yield return "oif";  // Olympus OIF
            yield return "oib";  // Olympus OIB
            yield return "oir";  // Olympus OIR
            yield return "mtb";  // MetaMorph Stack
            yield return "stk";  // MetaMorph Stack
            yield return "dm3";  // DigitalMicrograph 3
            yield return "dm4";  // DigitalMicrograph 4
            yield return "spe";  // WinView/WinSpec
            yield return "cxd";  // Compix CellR
            yield return "zvi";  // Zeiss Vision
            yield return "lsm";  // Zeiss LSM
            yield return "czi";  // Zeiss CZI
            yield return "ims";  // Imaris
            yield return "obf";  // Open Bio-Formats

            // Scientific data & analysis
            yield return "cdf";  // Common Data Format (NASA)
            yield return "nc";   // NetCDF
            yield return "h5";   // HDF5
            yield return "hdf5"; // HDF5 alternative
            yield return "hdf";  // HDF4
            yield return "h4";   // HDF4 alternative
            yield return "fits"; // Flexible Image Transport System
            yield return "fit";  // FITS alternative
            yield return "fts";  // FITS alternative
            yield return "root"; // ROOT (CERN)
            yield return "sav";  // SPSS Data
            yield return "zsav"; // SPSS Compressed
            yield return "por";  // SPSS Portable
            yield return "sas7bdat"; // SAS Dataset
            yield return "sd7";  // SAS Data
            yield return "ssd";  // SAS Data
            yield return "srd";  // SAS Data
            yield return "dta";  // Stata Data
            yield return "xpt";  // SAS Transport
            yield return "jmp";  // JMP Data
            yield return "jsl";  // JMP Script
            yield return "jrp";  // JMP Report
            yield return "jmpapp"; // JMP Application
            yield return "jmpaddin"; // JMP Add-in
            yield return "jmpquery"; // JMP Query
            #endregion

            #region Game Development & Assets (~80 extensions)
            // Game engine project files
            yield return "uproject"; // Unreal Engine Project
            yield return "uplugin"; // Unreal Engine Plugin
            yield return "umap";   // Unreal Engine Map
            yield return "uasset"; // Unreal Engine Asset
            yield return "uexp";   // Unreal Engine Export
            yield return "ubulk";  // Unreal Engine Bulk
            yield return "uptnl";  // Unreal Engine Texture
            yield return "udic";   // Unreal Engine Dictionary
            yield return "usmap";  // Unreal Engine Script
            yield return "uheader"; // Unreal Engine Header

            // Unity engine files
            yield return "unity";  // Unity Scene (also Level 2)
            yield return "unitypackage"; // Unity Package (also Level 2)
            yield return "asset";  // Unity Asset (also Level 2)
            yield return "prefab"; // Unity Prefab (also Level 2)
            yield return "mat";    // Unity Material (also Level 2)
            yield return "anim";   // Unity Animation (also Level 2)
            yield return "controller"; // Unity Animator Controller (also Level 2)
            yield return "overridecontroller"; // Unity Override Controller
            yield return "mask";   // Unity Avatar Mask
            yield return "physicmaterial"; // Unity Physics Material (also Level 2)
            yield return "shader"; // Unity Shader (also Level 2)
            yield return "computeshader"; // Unity Compute Shader
            yield return "rayshader"; // Unity Raytracing Shader
            yield return "shadergraph"; // Unity Shader Graph
            yield return "shadersubgraph"; // Unity Shader Subgraph
            yield return "guiskin"; // Unity GUI Skin (also Level 2)
            yield return "fontsettings"; // Unity Font (also Level 2)
            yield return "rendertexture"; // Unity Render Texture (also Level 2)
            yield return "cubemap"; // Unity Cubemap (also Level 2)
            yield return "flare";  // Unity Lens Flare (also Level 2)
            yield return "lightmap"; // Unity Lightmap (also Level 2)
            yield return "lighting"; // Unity Lighting Data
            yield return "lightingsettings"; // Unity Lighting Settings
            yield return "occlusion"; // Unity Occlusion Culling (also Level 2)
            yield return "occlusioncullingdata"; // Unity Occlusion Data
            yield return "navmesh"; // Unity NavMesh (also Level 2)
            yield return "navmeshsettings"; // Unity NavMesh Settings
            yield return "terrainlayer"; // Unity Terrain Layer (also Level 2)
            yield return "terrain"; // Unity Terrain
            yield return "terrainraw"; // Unity Terrain Raw
            yield return "spriteatlas"; // Unity Sprite Atlas (also Level 2)
            yield return "sprite"; // Unity Sprite
            yield return "brush";  // Unity Terrain Brush
            yield return "colors"; // Unity Color Palette
            yield return "curves"; // Unity Animation Curves
            yield return "gradient"; // Unity Gradient
            yield return "preset"; // Unity Preset

            // Game data & assets
            yield return "pak";   // Game Archive Package (also Level 2)
            yield return "vpk";   // Valve Package (also Level 2)
            yield return "bsa";   // Bethesda Archive (also Level 2)
            yield return "forge"; // Forge Archive
            yield return "dat";   // Game Data File (also Level 2)
            yield return "data";  // Game Data
            yield return "bdt";   // Game Data Table
            yield return "bhd";   // Game Data Header
            yield return "save";  // Game Save File (also Level 2)
            yield return "sav";   // Game Save (also Level 2)
            yield return "slot";  // Save Slot (also Level 2)
            yield return "profile"; // Player Profile (also Level 2)
            yield return "cfg";   // Game Configuration (also Level 2)
            yield return "ini";   // Game INI (also Level 2)
            yield return "log";   // Game Log (also Level 2)
            yield return "txt";   // Game Text (also Level 2)
            yield return "xml";   // Game XML (also Level 1)
            yield return "json";  // Game JSON (also Level 1)
            yield return "yaml";  // Game YAML (also Level 1)
            yield return "toml";  // Game TOML (also Level 1)
            yield return "lua";   // Game Script (also Level 2)
            yield return "py";    // Game Script (also Level 1)
            yield return "js";    // Game Script (also Level 1)
            yield return "ts";    // Game TypeScript

            // Modding & community content
            yield return "mod";   // Game Mod
            yield return "esp";   // Elder Scrolls Plugin
            yield return "esm";   // Elder Scrolls Master
            yield return "esl";   // Elder Scrolls Light
            yield return "esu";   // Elder Scrolls Update
            yield return "bsa";   // Bethesda Archive (duplicate for clarity)
            yield return "ba2";   // Bethesda Archive 2
            yield return "fomod"; // FOMod Installer
            yield return "nexus"; // Nexus Mod Manager
            yield return "vortex"; // Vortex Mod Manager
            yield return "mo2";   // Mod Organizer 2
            #endregion

            #region System, Backup & Virtualization (~50 extensions)
            // System & backup files[citation:1]
            yield return "gho";   // Norton Ghost[citation:1]
            yield return "ghs";   // Norton Ghost Span[citation:1]
            yield return "tib";   // Acronis True Image[citation:1]
            yield return "bkf";   // Windows Backup[citation:1]
            yield return "bkc";   // Windows Backup Catalog
            yield return "wim";   // Windows Imaging Format[citation:1]
            yield return "swm";   // Split WIM File[citation:1]
            yield return "esd";   // Electronic Software Distribution[citation:1]
            yield return "ffu";   // Full Flash Update
            yield return "vhd";   // Virtual Hard Disk[citation:1]
            yield return "vhdx";  // Virtual Hard Disk v2[citation:1]
            yield return "avhd";  // Azure Virtual Hard Disk[citation:1]
            yield return "avhdx"; // Azure VHDX[citation:1]
            yield return "vmdk";  // VMware Virtual Disk[citation:1]
            yield return "vmem";  // VMware Memory[citation:1]
            yield return "vmsn";  // VMware Snapshot[citation:1]
            yield return "vmss";  // VMware Suspended State[citation:1]
            yield return "nvram"; // VMware NVRAM[citation:1]
            yield return "vdi";   // VirtualBox Disk Image[citation:1]
            yield return "vbox";  // VirtualBox Configuration
            yield return "vbox-prev"; // VirtualBox Previous Config
            yield return "ova";   // Open Virtual Appliance[citation:1]
            yield return "ovf";   // Open Virtualization Format[citation:1]
            yield return "mf";    // OVF Manifest
            yield return "cert";  // OVF Certificate
            yield return "qcow";  // QEMU Copy-On-Write[citation:1]
            yield return "qcow2"; // QEMU Copy-On-Write v2[citation:1]
            yield return "qed";   // QEMU Enhanced Disk
            yield return "vfd";   // Virtual Floppy Disk
            yield return "vfd";   // Virtual Floppy (alternative)
            yield return "vhd";   // Virtual Hard Disk (duplicate for clarity)
            yield return "vud";   // Virtual Undo Disk

            // Disk images[citation:1]
            yield return "iso";   // ISO Disk Image (also Level 2)[citation:1]
            yield return "dmg";   // Apple Disk Image (also Level 2)[citation:1]
            yield return "sparseimage"; // Sparse Disk Image[citation:1]
            yield return "sparsebundle"; // Sparse Bundle[citation:1]
            yield return "toast"; // Toast Disc Image[citation:1]
            yield return "cdr";   // CD-R Disc Image[citation:1]
            yield return "bin";   // Binary Disc Image[citation:1]
            yield return "cue";   // Cue Sheet[citation:1]
            yield return "mdf";   // Media Disc Image[citation:1]
            yield return "mds";   // Daemon Tools Image[citation:1]
            yield return "mdx";   // Media Data eXtended[citation:1]
            yield return "nrg";   // Nero Burning ROM Image[citation:1]
            yield return "pdi";   // Pinnacle Disc Image[citation:1]
            yield return "b5t";   // BlindWrite 5[citation:1]
            yield return "b6t";   // BlindWrite 6[citation:1]
            yield return "bwt";   // BlindWrite 4[citation:1]
            yield return "cdi";   // DiscJuggler[citation:1]
            yield return "cif";   // Easy CD Creator[citation:1]
            yield return "c2d";   // Roxio-WinOnCD[citation:1]
            yield return "daa";   // PowerISO[citation:1]
            yield return "d64";   // Commodore 64[citation:1]
            yield return "adf";   // Amiga Disk File[citation:1]
            yield return "adz";   // GZipped ADF[citation:1]
            yield return "dms";   // Amiga Disk Archiver[citation:1]
            yield return "dsk";   // Floppy Disk Image[citation:1]
            yield return "sdi";   // SDI Image[citation:1]
            #endregion

            #region Multimedia & Containers (~50 extensions)
            // Professional audio/video containers
            yield return "mxf";   // Material Exchange Format
            yield return "gxf";   // General eXchange Format
            yield return "bwf";   // Broadcast Wave Format
            yield return "rf64";  // RF64 Broadcast WAV
            yield return "caf";   // Core Audio Format
            yield return "ac3";   // Dolby Digital
            yield return "eac3";  // Dolby Digital Plus
            yield return "thd";   // Dolby TrueHD
            yield return "dts";   // DTS Audio
            yield return "dtshd"; // DTS-HD Master Audio
            yield return "dtsma"; // DTS Master Audio
            yield return "mlp";   // Meridian Lossless Packing
            yield return "atmos"; // Dolby Atmos
            yield return "aax";   // Audible Enhanced Audio
            yield return "aa";    // Audible Audio
            yield return "m4b";   // Audiobook MP4
            yield return "mka";   // Matroska Audio
            yield return "mks";   // Matroska Subtitles
            yield return "mk3d";  // Matroska 3D
            yield return "webm";  // WebM Video (also Level 1)

            // Editing & production formats
            yield return "aep";   // After Effects Project (also Level 2)
            yield return "aet";   // After Effects Template (also Level 2)
            yield return "prproj"; // Premiere Pro Project (also Level 2)
            yield return "plproj"; // Prelude Project
            yield return "dsr";   // DaVinci Resolve Project (also Level 2)
            yield return "drp";   // DaVinci Resolve Project (alternative)
            yield return "fcpxml"; // Final Cut Pro XML (also Level 2)
            yield return "fcp";   // Final Cut Pro Project (also Level 2)
            yield return "fcpbundle"; // Final Cut Pro Bundle (also Level 2)
            yield return "veg";   // Vegas Pro Project (also Level 2)
            yield return "vf";    // Video Fusion composition (also Level 2)
            yield return "edl";   // Edit Decision List (also Level 2)
            yield return "aaf";   // Advanced Authoring Format (also Level 2)
            yield return "omf";   // Open Media Framework (also Level 2)
            yield return "ale";   // Avid Log Exchange (also Level 2)
            yield return "braw";  // Blackmagic RAW (also Level 2)
            yield return "r3d";   // REDCODE Raw (also Level 2)
            yield return "ari";   // ARRIRAW (also Level 2)
            yield return "cine";  // Phantom Cine (also Level 2)
            yield return "dav";   // Dahua surveillance video (also Level 2)
            yield return "prores"; // Apple ProRes (also Level 2)
            yield return "dnxhd"; // Avid DNxHD (also Level 2)
            yield return "dnxhr"; // Avid DNxHR

            // Subtitle & caption formats
            yield return "srt";   // SubRip Subtitle (also Level 2)
            yield return "ass";   // Advanced SubStation Alpha (also Level 2)
            yield return "ssa";   // SubStation Alpha (also Level 2)
            yield return "vtt";   // WebVTT (also Level 2)
            yield return "smi";   // SAMI Captioning (also Level 2)
            yield return "sub";   // SubViewer Subtitle (also Level 2)
            yield return "idx";   // VOBSub Index (also Level 2)
            yield return "sup";   // Blu-ray SUP (also Level 2)
            yield return "ttml";  // Timed Text Markup Language
            yield return "dfxp";  // Distribution Format Exchange Profile
            yield return "mcc";   // MacCaption
            yield return "scc";   // Scenarist Closed Caption
            yield return "cap";   // Cheetah Caption
            yield return "pac";   // PAC Subtitle
            yield return "rcproject"; // iMovie Project
            #endregion

            #region Compression, Archives & Packaging (~40 extensions)
            // Archive formats[citation:1]
            yield return "ace";   // ACE Archive[citation:1]
            yield return "alz";   // ALZip Archive[citation:1]
            yield return "arc";   // ARC Archive[citation:1]
            yield return "arj";   // ARJ Archive[citation:1]
            yield return "cab";   // Cabinet File[citation:1]
            yield return "cpio";  // CPIO Archive
            yield return "egg";   // ALZip Egg Archive[citation:1]
            yield return "lha";   // LHA Archive[citation:1]
            yield return "lzh";   // LZH Archive[citation:1]
            yield return "lz";    // Lzip Archive[citation:1]
            yield return "lzma";  // LZMA Archive[citation:1]
            yield return "lzo";   // LZO Archive[citation:1]
            yield return "lzx";   // LZX Archive[citation:1]
            yield return "pak";   // PAK Archive[citation:1]
            yield return "par";   // PArchive[citation:1]
            yield return "par2";  // PArchive 2[citation:1]
            yield return "pea";   // PeaZip Archive[citation:1]
            yield return "sit";   // StuffIt Archive
            yield return "sitx";  // StuffIt X Archive[citation:1]
            yield return "sz";    // 7-Zip Split Archive
            yield return "tgz";   // Gzipped Tar
            yield return "tbz";   // Bzipped Tar
            yield return "tbz2";  // Bzip2 Tar
            yield return "txz";   // XZ Tar
            yield return "tlz";   // LZMA Tar
            yield return "tzst";  // Zstandard Tar
            yield return "war";   // Web Application Archive (also Level 2)
            yield return "ear";   // Enterprise Archive (also Level 2)
            yield return "sar";   // Service Archive
            yield return "xar";   // Extended Archive
            yield return "zoo";   // ZOO Archive[citation:1]
            yield return "zst";   // Zstandard Archive

            // Package & installer formats[citation:1]
            yield return "apk";   // Android Package (also Level 2)[citation:1]
            yield return "aab";   // Android App Bundle[citation:1]
            yield return "ipa";   // iOS App Archive (also Level 2)[citation:1]
            yield return "deb";   // Debian Package (also Level 2)[citation:1]
            yield return "rpm";   // RPM Package (also Level 2)[citation:1]
            yield return "pkg";   // macOS Installer (also Level 2)[citation:1]
            yield return "msi";   // Windows Installer (also Level 1)[citation:1]
            yield return "msp";   // Windows Installer Patch
            yield return "mst";   // Windows Installer Transform
            yield return "appx";  // Microsoft App Package (also Level 2)[citation:1]
            yield return "appxbundle"; // App Package Bundle (also Level 2)[citation:1]
            yield return "msix";  // MSIX Package (also Level 2)[citation:1]
            yield return "msixbundle"; // MSIX Bundle (also Level 2)[citation:1]
            yield return "sis";   // Symbian Package[citation:1]
            yield return "sisx";  // Symbian Signed Package[citation:1]
            yield return "xap";   // Windows Phone Package[citation:1]
            yield return "appxupload"; // Windows App Upload
            #endregion

            #region Email, Communication & Security (~50 extensions)
            // Email & messaging formats
            yield return "eml";   // Email Message (also Level 2)
            yield return "emlx";  // Apple Mail Message
            yield return "msg";   // Outlook Message (also Level 2)
            yield return "pst";   // Outlook Data File (also Level 2)
            yield return "ost";   // Outlook Offline File (also Level 2)
            yield return "mbox";  // Mailbox (also Level 2)
            yield return "mbx";   // Mailbox alternative
            yield return "dbx";   // Outlook Express Mailbox
            yield return "idx";   // Outlook Express Index
            yield return "nch";   // Outlook Express Folder
            yield return "olk14message"; // Outlook for Mac
            yield return "olk14contact"; // Outlook Contact
            yield return "olk14calendar"; // Outlook Calendar
            yield return "olk14note"; // Outlook Note
            yield return "olk14task"; // Outlook Task
            yield return "vcf";   // vCard (also Level 2)
            yield return "vcard"; // vCard alternative (also Level 2)
            yield return "ics";   // iCalendar (also Level 2)
            yield return "ical";  // iCalendar alternative (also Level 2)
            yield return "ifb";   // iCalendar Free/Busy

            // Security & certificates
            yield return "p7s";   // PKCS#7 Signature
            yield return "p7m";   // PKCS#7 Message
            yield return "p7c";   // PKCS#7 Certificate
            yield return "p7b";   // PKCS#7 Certificate Bundle
            yield return "p12";   // PKCS#12 Certificate (also Level 1)
            yield return "pfx";   // Personal Exchange Certificate (also Level 1)
            yield return "spc";   // Software Publisher Certificate
            yield return "cer";   // Certificate (also Level 1)
            yield return "crt";   // Certificate (also Level 1)
            yield return "der";   // DER Certificate (also Level 1)
            yield return "pem";   // Privacy Enhanced Mail (also Level 1)
            yield return "key";   // Private Key (also Level 1)
            yield return "jks";   // Java Keystore
            yield return "keystore"; // Java Keystore
            yield return "truststore"; // Java Truststore
            yield return "bks";   // Bouncy Castle Keystore
            yield return "p8";    // PKCS#8 Private Key
            yield return "pk8";   // PKCS#8 Private Key
            yield return "csr";   // Certificate Signing Request (also Level 1)
            yield return "crl";   // Certificate Revocation List
            yield return "ocsp";  // OCSP Response
            yield return "sig";   // Signature File
            yield return "asc";   // ASCII Armored (PGP)
            yield return "gpg";   // GnuPG
            yield return "pgp";   // Pretty Good Privacy
            yield return "pub";   // Public Key
            yield return "sec";   // Secret Key
            yield return "skr";   // Secret Key Ring
            yield return "pkr";   // Public Key Ring
            yield return "nkr";   // Netware Key Ring

            // Authentication & tokens
            yield return "jwt";   // JSON Web Token
            yield return "jwks";  // JSON Web Key Set
            yield return "pwd";   // Password File
            yield return "htpasswd"; // HTTP Password
            yield return "kdbx";  // KeePass Database
            yield return "kdb";   // KeePass 1 Database
            yield return "agilekeychain"; // 1Password
            yield return "opvault"; // 1Password Vault
            yield return "bitwarden"; // Bitwarden Export
            yield return "lastpass"; // LastPass Export
            #endregion
        }
    }
}
