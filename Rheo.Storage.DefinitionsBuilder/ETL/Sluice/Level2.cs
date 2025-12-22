namespace Rheo.Storage.DefinitionsBuilder.ETL.Sluice
{
    internal static partial class CommonExtensions
    {
        /// <summary>
        /// Returns a collection of file extensions that are commonly used in professional and creative work across
        /// various domains. This collection is limited to approximately 300-400 extensions.
        /// </summary>
        /// <remarks>The returned set includes extensions for creative and design applications, audio and
        /// video production, photography, software development, data science, specialized documents, virtualization,
        /// and game asset formats. This list is intended to represent widely recognized file types in professional
        /// workflows and may be useful for applications that need to identify or filter such files.</remarks>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="string"/> values, where each string is a file extension
        /// (without the leading period) representing a professional or creative file type.</returns>
        private static IEnumerable<string> BuildLevel2()
        {
            #region Creative & Design (Raster & Vector)
            // Adobe Creative Suite native & industry standard formats[citation:3][citation:6][citation:9]
            yield return "psd"; // Photoshop Document[citation:3][citation:6]
            yield return "ai";  // Adobe Illustrator[citation:3][citation:6][citation:9]
            yield return "indd"; // InDesign Document[citation:3][citation:5]
            yield return "indt"; // InDesign Template
            yield return "aep";  // After Effects Project
            yield return "aet";  // After Effects Template
            yield return "prproj"; // Premiere Pro Project
            yield return "dn";   // Adobe Dimension
            yield return "xd";   // Adobe XD
            yield return "sketch"; // Sketch design file
            yield return "fig";  // Figma file
            yield return "afphoto"; // Affinity Photo
            yield return "afdesign"; // Affinity Designer
            yield return "afpub"; // Affinity Publisher
            yield return "c4d";  // Cinema 4D
            yield return "blend"; // Blender
            yield return "max";  // 3ds Max
            yield return "mb";   // Maya Binary
            yield return "ma";   // Maya ASCII
            yield return "ztl";  // ZBrush Tool
            yield return "unity"; // Unity scene
            yield return "unreal"; // Unreal Engine project
                                   // Print & high-fidelity graphics[citation:3][citation:6][citation:9]
            yield return "eps";  // Encapsulated PostScript[citation:3][citation:6][citation:9]
            yield return "tif";  // Tagged Image File[citation:3][citation:6]
            yield return "tiff"; // Tagged Image File
            yield return "bmp";  // Bitmap (in design context)
            yield return "pcx";  // PC Paintbrush
            yield return "pct";  // Macintosh PICT
            yield return "pict"; // PICT image
            yield return "riff"; // Resource Interchange File Format
            yield return "exr";  // OpenEXR High Dynamic-range Image
            yield return "hdr";  // High Dynamic Range image
            yield return "raw";  // Camera raw image (generic)
            yield return "cr2";  // Canon Raw 2
            yield return "nef";  // Nikon Electronic Format
            yield return "arw";  // Sony Alpha Raw
            yield return "dng";  // Digital Negative
            yield return "orf";  // Olympus Raw Format
            yield return "rw2";  // Panasonic Raw
            yield return "pef";  // Pentax Electronic File
            yield return "sr2";  // Sony Raw
            yield return "raf";  // Fujifilm Raw
            yield return "3fr";  // Hasselblad 3F Raw
            yield return "fff";  // Hasselblad Raw
            yield return "iiq";  // Phase One Raw
            yield return "nrw";  // Nikon Raw
            yield return "rwl";  // Leica Raw
            yield return "srf";  // Sony Raw
            yield return "srw";  // Samsung Raw
                                 // Desktop publishing & layout
            yield return "qxp";  // QuarkXPress
            yield return "qpt";  // QuarkXPress Template
            yield return "pub";  // Microsoft Publisher
            yield return "folio"; // Adobe Folio
            yield return "idml"; // InDesign Markup Language
            yield return "pmd";  // PageMaker
            yield return "fm";   // FrameMaker
            yield return "book"; // FrameMaker Book
            yield return "mif";  // Maker Interchange Format
            #endregion

            #region Audio Production & Engineering
            // Professional audio & studio formats[citation:4][citation:8][citation:10]
            yield return "flac"; // Free Lossless Audio Codec[citation:4][citation:10]
            yield return "alac"; // Apple Lossless Audio Codec[citation:4]
            yield return "aiff"; // Audio Interchange File Format[citation:4]
            yield return "aif";  // Audio Interchange File
            yield return "aifc"; // Audio Interchange File Compressed
            yield return "dsd";  // Direct Stream Digital[citation:4]
            yield return "dsf";  // DSD Stream File
            yield return "dff";  // DSDIFF File
            yield return "pcm";  // Pulse-Code Modulation[citation:4]
            yield return "ogg";  // Ogg Vorbis[citation:4]
            yield return "opus"; // Opus Audio
            yield return "wma";  // Windows Media Audio[citation:4]
            yield return "ra";   // RealAudio[citation:4]
            yield return "rm";   // RealMedia
            yield return "dts";  // DTS Audio
            yield return "ac3";  // Dolby Digital
            yield return "eac3"; // Dolby Digital Plus
            yield return "thd";  // Dolby TrueHD
            yield return "mka";  // Matroska Audio
                                 // Digital Audio Workstation (DAW) project files
            yield return "ptx";  // Pro Tools Session
            yield return "ptf";  // Pro Tools Session (older)
            yield return "logic"; // Logic Pro Project
            yield return "cpr";  // Cubase Project
            yield return "als";  // Ableton Live Set
            yield return "alp";  // Ableton Live Pack
            yield return "reason"; // Reason Project
            yield return "flp";  // FL Studio Project
            yield return "garageband"; // GarageBand Project
            yield return "band"; // Apple Band
            yield return "sesx"; // Studio One Project
            yield return "rpp";  // REAPER Project
            yield return "ardour"; // Ardour Session
            yield return "tracktion"; // Tracktion Project
            yield return "npr";  // Nuendo Project
            yield return "vip";  // Vienna Ensemble Pro
                                 // Audio samples & libraries
            yield return "sf2";  // SoundFont 2
            yield return "sfz";  // SFZ Soundfont
            yield return "gig";  // GigaSampler
            yield return "nki";  // Kontakt Instrument
            yield return "nkm";  // Kontakt Multisample
            yield return "exs";  // EXS24 Sampler
            yield return "iso";  // DVD-Audio image (for audio content)
            #endregion

            #region Video Production & Motion Graphics
            // Professional video & editing formats[citation:8][citation:10]
            yield return "mxf";  // Material Exchange Format
            yield return "prores"; // Apple ProRes
            yield return "dnxhd"; // Avid DNxHD
            yield return "r3d";  // REDCODE Raw
            yield return "ari";  // ARRIRAW
            yield return "braw"; // Blackmagic RAW
            yield return "cine"; // Phantom Cine
            yield return "dav";  // Dahua surveillance video
                                 // Editing project files
            yield return "fcp";  // Final Cut Pro Project (legacy)
            yield return "fcpxml"; // Final Cut Pro XML
            yield return "fcpbundle"; // Final Cut Pro Bundle
            yield return "drp";  // DaVinci Resolve Project
            yield return "veg";  // Vegas Pro Project
            yield return "vf";   // Video Fusion composition
            yield return "edl";  // Edit Decision List
            yield return "aaf";  // Advanced Authoring Format
            yield return "omf";  // Open Media Framework
            yield return "ale";  // Avid Log Exchange
                                 // Subtitles & captions
            yield return "srt";  // SubRip Subtitle
            yield return "ass";  // Advanced SubStation Alpha
            yield return "ssa";  // SubStation Alpha
            yield return "vtt";  // WebVTT
            yield return "smi";  // SAMI Captioning
            yield return "sub";  // SubViewer Subtitle
            yield return "idx";  // VOBSub Index
            yield return "sup";  // Blu-ray SUP
            #endregion

            #region Software Development & Engineering
            // Compiled code & binaries
            yield return "obj";  // Object file
            yield return "lib";  // Static library
            yield return "a";    // Archive library (Unix)
            yield return "dylib"; // Dynamic library (macOS)
            yield return "jar";  // Java Archive[citation:1]
            yield return "war";  // Web Application Archive
            yield return "ear";  // Enterprise Archive
            yield return "apk";  // Android Package[citation:1]
            yield return "aab";  // Android App Bundle[citation:1]
            yield return "ipa";  // iOS App Archive
            yield return "appx"; // Microsoft App Package[citation:1]
            yield return "appxbundle"; // App Package Bundle
            yield return "msix"; // MSIX Package[citation:1]
            yield return "msixbundle"; // MSIX Bundle
            yield return "deb";  // Debian Package[citation:1]
            yield return "rpm";  // RPM Package[citation:1]
            yield return "pkg";  // macOS Installer
            yield return "app";  // macOS Application
                                 // Development project files
            yield return "sln";  // Visual Studio Solution
            yield return "csproj"; // C# Project
            yield return "vbproj"; // VB.NET Project
            yield return "vcxproj"; // C++ Project
            yield return "xcodeproj"; // Xcode Project
            yield return "pbxproj"; // Xcode Project File
            yield return "gradle"; // Gradle Build File
            yield return "pom";  // Maven Project Object Model
            yield return "make"; // Makefile
            yield return "cmake"; // CMake File
            yield return "workspace"; // Eclipse/IDE Workspace
            yield return "project"; // Generic Project File
                                    // Data & configuration for development
            yield return "resx"; // .NET Resources
            yield return "resources"; // Compiled Resources
            yield return "manifest"; // Application Manifest
            yield return "snk";  // Strong Name Key
            yield return "pdb";  // Program Database (debug)
            yield return "map";  // Linker Map File
            yield return "def";  // Module Definition
            yield return "rc";   // Resource Script
            yield return "ico";  // Icon File (dev context)
            yield return "cur";  // Cursor File
            yield return "ani";  // Animated Cursor
                                 // Scripts & automation
            yield return "ps1";  // PowerShell Script[citation:1]
            yield return "psm1"; // PowerShell Module
            yield return "vbs";  // VBScript
            yield return "wsf";  // Windows Script File
            yield return "scpt"; // AppleScript
            yield return "applescript"; // AppleScript
            yield return "au3";  // AutoIt Script
            yield return "ahk";  // AutoHotkey Script
            yield return "lua";  // Lua Script
            yield return "pl";   // Perl Script
            yield return "pm";   // Perl Module
            yield return "r";    // R Script
            yield return "rb";   // Ruby Script
            yield return "gem";  // Ruby Gem
            #endregion

            #region Data Science, CAD & Engineering
            // Data science & analysis
            yield return "ipynb"; // Jupyter Notebook
            yield return "rdata"; // R Data File
            yield return "rds";  // R Single Object
            yield return "sav";  // SPSS Data File
            yield return "sas7bdat"; // SAS Dataset
            yield return "dta";  // Stata Data File
            yield return "mat";  // MATLAB Data File
            yield return "m";    // MATLAB Script/Function
            yield return "octave"; // Octave Script
            yield return "pickle"; // Python Pickle
            yield return "joblib"; // scikit-learn Joblib
            yield return "h5";   // Hierarchical Data Format 5
            yield return "hdf5"; // HDF5 File
            yield return "nc";   // NetCDF Data File
            yield return "fits"; // Flexible Image Transport System
            yield return "root"; // ROOT Data File (CERN)
                                 // CAD & 3D Engineering[citation:1]
            yield return "dwg";  // AutoCAD Drawing[citation:1]
            yield return "dxf";  // Drawing Exchange Format[citation:1]
            yield return "dgn";  // MicroStation Design[citation:1]
            yield return "stl";  // Stereolithography
            yield return "step"; // STEP 3D Model
            yield return "iges"; // IGES 3D Model
            yield return "obj";  // Wavefront 3D Object (already in dev)
            yield return "fbx";  // Autodesk FBX
            yield return "3ds";  // 3D Studio Scene
            yield return "ply";  // Polygon File Format
            yield return "off";  // Object File Format
            yield return "vrml"; // Virtual Reality Modeling Language
            yield return "x3d";  // X3D File
            yield return "collada"; // COLLADA 3D
            yield return "u3d";  // Universal 3D
            yield return "prt";  // CAD Part File
            yield return "asm";  // Assembly File[citation:1]
            yield return "drw";  // Drawing File
            yield return "idw";  // Inventor Drawing
            yield return "ipt";  // Inventor Part
            yield return "iam";  // Inventor Assembly
            yield return "catpart"; // CATIA Part[citation:1]
            yield return "catproduct"; // CATIA Product[citation:1]
            yield return "sldprt"; // SolidWorks Part
            yield return "sldasm"; // SolidWorks Assembly
            yield return "slddrw"; // SolidWorks Drawing
                                   // PCB & electronics design
            yield return "sch";  // Schematic
            yield return "brd";  // Board File
            yield return "pcb";  // PCB Layout
            yield return "kicad_pcb"; // KiCad PCB
            yield return "kicad_sch"; // KiCad Schematic
            yield return "kicad_mod"; // KiCad Module
            yield return "kicad_lib"; // KiCad Library
            yield return "kicad_wks"; // KiCad Worksheet
            yield return "kicad_pro"; // KiCad Project
            yield return "kicad_dru"; // KiCad Design Rules
            yield return "kicad_sym"; // KiCad Symbol
            yield return "kicad_fp"; // KiCad Footprint
            yield return "kicad_fp_lib_table"; // KiCad Footprint Library Table
            yield return "kicad_sym_lib_table"; // KiCad Symbol Library Table
            yield return "kicad_wks"; // KiCad Worksheet
            #endregion

            #region Specialized Documents & Publishing
            // E-books & digital publishing
            yield return "mobi"; // Mobipocket (already in Level1)
            yield return "azw3"; // Amazon Kindle Format 8
            yield return "kfx";  // Amazon KF8 Enhanced
            yield return "ibooks"; // Apple iBook
            yield return "lit";  // Microsoft Reader
            yield return "fb2";  // FictionBook 2.0
            yield return "djvu"; // DjVu Document
            yield return "xps";  // XML Paper Specification
            yield return "oxps"; // OpenXPS
                                 // Scientific & academic
            yield return "bib";  // BibTeX Bibliography
            yield return "enl";  // EndNote Library
            yield return "ris";  // Research Information Systems
            yield return "cff";  // Citation File Format
            yield return "tei";  // Text Encoding Initiative
            yield return "mbox"; // Email Mailbox[citation:1]
                                 // Geographic Information Systems (GIS)
            yield return "shp";  // ESRI Shapefile
            yield return "shx";  // Shapefile Index
            yield return "dbf";  // Database File (for shapes)
            yield return "prj";  // Projection File
            yield return "kml";  // Keyhole Markup Language
            yield return "kmz";  // Compressed KML
            yield return "gpx";  // GPS Exchange Format
            yield return "geojson"; // GeoJSON
            yield return "topojson"; // TopoJSON
            yield return "mif";  // MapInfo Interchange (already in design)
            yield return "tab";  // MapInfo Table
            yield return "lyr";  // ESRI Layer File
            yield return "mxd";  // ArcMap Document
            yield return "qgs";  // QGIS Project
            yield return "qgz";  // Compressed QGIS Project
            #endregion

            #region Game Development & Assets
            // Game engines & assets
            yield return "unitypackage"; // Unity Asset Package
            yield return "asset"; // Unity Asset
            yield return "prefab"; // Unity Prefab
            yield return "mat";  // Unity Material (clash with MATLAB)
            yield return "anim"; // Unity Animation
            yield return "controller"; // Unity Animator Controller
            yield return "physicmaterial"; // Unity Physics Material
            yield return "shader"; // Unity Shader
            yield return "guiskin"; // Unity GUI Skin
            yield return "fontsettings"; // Unity Font
            yield return "rendertexture"; // Unity Render Texture
            yield return "cubemap"; // Unity Cubemap
            yield return "flare"; // Unity Lens Flare
            yield return "lightmap"; // Unity Lightmap
            yield return "occlusion"; // Unity Occlusion Culling Data
            yield return "navmesh"; // Unity Navigation Mesh
            yield return "terrainlayer"; // Unity Terrain Layer
            yield return "spriteatlas"; // Unity Sprite Atlas
            yield return "asmdef"; // Unity Assembly Definition
            yield return "cginc"; // Unity Shader Include
            yield return "compute"; // Unity Compute Shader
            yield return "raytrace"; // Unity Raytracing Shader
            yield return "hlsl"; // High-Level Shading Language
            yield return "glsl"; // OpenGL Shading Language
                                 // Game data files
            yield return "pak";  // Game Archive Package[citation:1]
            yield return "vpk";  // Valve Package
            yield return "bsa";  // Bethesda Archive
            yield return "dat";  // Game Data File
            yield return "save"; // Game Save File
            yield return "sav";  // Game Save (clash with SPSS)
            yield return "slot"; // Save Slot
            yield return "profile"; // Player Profile
            yield return "cfg";  // Game Configuration
            yield return "ini";  // Game INI (already Level1)
            yield return "log";  // Game Log (already Level1)
            yield return "txt";  // Game Text (already Level1)
            #endregion

            #region Virtualization, Disk & System Images
            // Virtual machines & containers[citation:1]
            yield return "vdi";  // VirtualBox Disk Image
            yield return "vmdk"; // VMware Virtual Disk[citation:1]
            yield return "vhd";  // Virtual Hard Disk[citation:1]
            yield return "vhdx"; // Virtual Hard Disk v2[citation:1]
            yield return "avhd"; // Azure Virtual Hard Disk
            yield return "avhdx"; // Azure VHDX
            yield return "qcow"; // QEMU Copy-On-Write
            yield return "qcow2"; // QEMU Copy-On-Write v2
            yield return "vmem"; // VMware Memory
            yield return "vmsn"; // VMware Snapshot
            yield return "vmss"; // VMware Suspended State
            yield return "nvram"; // VMware NVRAM
            yield return "ova";  // Open Virtual Appliance[citation:1]
            yield return "ovf";  // Open Virtualization Format[citation:1]
                                 // System & disk images[citation:1]
            yield return "bin";  // Binary Disc Image (with cue)[citation:1]
            yield return "cue";  // Cue Sheet[citation:1]
            yield return "mds";  // DAEMON Tools Image[citation:1]
            yield return "mdf";  // Media Disc Image[citation:1]
            yield return "mdx";  // Media Data eXtended[citation:1]
            yield return "nrg";  // Nero Burning ROM Image[citation:1]
            yield return "cdr";  // CD-R Disc Image
            yield return "dmg";  // Apple Disk Image (already Level1)
            yield return "sparseimage"; // Sparse Disk Image
            yield return "sparsebundle"; // Sparse Bundle
            yield return "toast"; // Toast Disc Image
            yield return "pdi";  // Pinnacle Disc Image
                                 // Backup & recovery
            yield return "tib";  // Acronis True Image[citation:1]
            yield return "gho";  // Norton Ghost[citation:1]
            yield return "bkf";  // Windows Backup
            yield return "wim";  // Windows Imaging Format[citation:1]
            yield return "esd";  // Electronic Software Distribution[citation:1]
            yield return "swm";  // Split WIM File[citation:1]
            #endregion

            #region Archives & Specialized Packages
            // Professional archives & packages[citation:1]
            yield return "7z";   // 7-Zip Archive (already Level1)
            yield return "tar";  // Tape Archive (already Level1)
            yield return "gz";   // Gzip Compressed (already Level1)
            yield return "bz2";  // Bzip2 Compressed[citation:1]
            yield return "xz";   // XZ Compressed[citation:1]
            yield return "lz";   // Lzip Compressed[citation:1]
            yield return "lzma"; // LZMA Compressed[citation:1]
            yield return "z";    // Unix Compress[citation:1]
            yield return "lzh";  // LHA Archive[citation:1]
            yield return "lha";  // LHA Archive
            yield return "arj";  // ARJ Archive[citation:1]
            yield return "cab";  // Cabinet File[citation:1]
            yield return "deb";  // Debian Package (already in dev)
            yield return "rpm";  // RPM Package (already in dev)
            yield return "msi";  // Windows Installer (already Level1)
            yield return "msix"; // MSIX (already in dev)
            yield return "appx"; // APPX (already in dev)
            yield return "pkg";  // macOS Installer (already in dev)
            yield return "dmg";  // Disk Image (already listed)
                                 // Font files (for design workflow)
            yield return "ttf";  // TrueType Font (already Level1)
            yield return "otf";  // OpenType Font (already Level1)
            yield return "woff"; // Web Open Font Format (already Level1)
            yield return "woff2"; // WOFF2 (already Level1)
            yield return "eot";  // Embedded OpenType (already Level1)
            yield return "fon";  // Bitmapped Font (already Level1)
            yield return "fnt";  // Font File (already Level1)
            yield return "dfont"; // Datafork Font (already Level1)
            #endregion
        }
    }
}
