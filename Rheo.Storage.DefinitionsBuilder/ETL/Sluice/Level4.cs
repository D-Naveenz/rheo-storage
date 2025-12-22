namespace Rheo.Storage.DefinitionsBuilder.ETL.Sluice
{
    internal static partial class CommonExtensions
    {
        /// <summary>
        /// Returns a collection of file extensions representing niche, legacy, or software-specific formats.
        /// This collection is limited to approximately 800-1000 extensions.
        /// </summary>
        /// <remarks>The returned extensions include formats from legacy office suites, e-book variants,
        /// specialized audio and video codecs, game console images, mobile and embedded platforms, scientific
        /// instruments, font and typography files, CAD/CAM systems, and various backup archives. This set is intended
        /// for scenarios where comprehensive support for uncommon or obsolete file types is required.</remarks>
        /// <returns>An <see cref="IEnumerable{String}"/> containing file extension strings for niche, legacy, or
        /// software-specific formats. The collection may include duplicate extensions if a format is used in multiple
        /// categories.</returns>
        private static IEnumerable<string> BuildLevel4()
        {
            #region Legacy Office & Document Suites (~80 extensions)
            // Obsolete word processor and office suite formats
            yield return "bravo"; // Bravo word processor (Xerox Alto) [citation:5]
            yield return "vw";    // Volkswriter document [citation:5]
            yield return "vw3";   // Volkswriter 3 document [citation:5]
            yield return "awp";   // AppleWorks word processor (Apple II) [citation:5]
            yield return "cwk";   // ClarisWorks/AppleWorks (Mac) [citation:5]
            yield return "pfs";   // PFS:Write/Professional Write [citation:5]
            yield return "wri";   // Microsoft Write (Windows 3.x) [citation:5]
            yield return "sam";   // Ami Pro/Lotus Word Pro
            yield return "lwp";   // Lotus Word Pro
            yield return "mcw";   // Microsoft Word for Mac (pre-2004)
            yield return "wps";   // Microsoft Works Word Processor
            yield return "docm";  // Microsoft Word macro-enabled (legacy)
            yield return "dotm";  // Microsoft Word macro template (legacy)
            yield return "sxw";   // OpenOffice.org 1.x Text Document
            yield return "stw";   // OpenOffice.org 1.x Text Template
            yield return "602";   // T602 document
            yield return "abw";   // AbiWord Document
            yield return "zabw";  // Compressed AbiWord Document
            yield return "hwp";   // Hangul (Korean word processor)
            yield return "cell";  // AppleWorks Spreadsheet (Apple II)
            yield return "clls";  // ClarisWorks/AppleWorks Spreadsheet (Mac)
            yield return "wks";   // Lotus 1-2-3/Microsoft Works spreadsheet [citation:9]
            yield return "wk1";   // Lotus 1-2-3 version 2
            yield return "wk3";   // Lotus 1-2-3 version 3
            yield return "wk4";   // Lotus 1-2-3 version 4
            yield return "123";   // Lotus 1-2-3 generic
            yield return "qpw";   // Quattro Pro Spreadsheet
            yield return "wb1";   // Quattro Pro for Windows
            yield return "wb2";   // Quattro Pro for Windows version 6
            yield return "wb3";   // Quattro Pro for Windows version 7/8
            yield return "slk";   // SYLK (Symbolic Link) spreadsheet
            yield return "dif";   // Data Interchange Format [citation:9]
            yield return "sdc";   // StarOffice/OpenOffice Calc
            yield return "vor";   // StarOffice/OpenOffice Template
            yield return "pm3";   // PageMaker 3 Document
            yield return "pm4";   // PageMaker 4 Document
            yield return "pm5";   // PageMaker 5 Document
            yield return "pm6";   // PageMaker 6 Document
            yield return "p65";   // PageMaker 6.5 Document
            yield return "qxd";   // QuarkXPress Document
            yield return "qxt";   // QuarkXPress Template
            yield return "qpt";   // QuarkXPress Project Template
            yield return "fm";    // FrameMaker Document
            yield return "book";  // FrameMaker Book File
            yield return "mif";   // Maker Interchange Format [citation:1]
            yield return "cvt";   // GeoWrite document (Commodore 64) [citation:5]
            yield return "000";   // GeoWrite document (DOS) [citation:5]
            yield return "dca";   // Document Content Architecture (IBM)
            yield return "rft";   // Revisable-Form Text (IBM)
            yield return "ans";   // ANSI text art
            yield return "nfo";   // Warez information file
            yield return "diz";   // Description in zip file
                                  // Additional legacy formats
            yield return "swp";   // WordPerfect swap file
            yield return "wp4";   // WordPerfect 4
            yield return "wp5";   // WordPerfect 5
            yield return "wp6";   // WordPerfect 6
            yield return "wp7";   // WordPerfect 7
            yield return "wpd";   // WordPerfect Document [citation:9]
            yield return "wpg";   // WordPerfect Graphic
            yield return "wpt";   // WordPerfect Template
            yield return "wpw";   // Microsoft Works word processor (Windows)
            yield return "xlr";   // Microsoft Works spreadsheet (Windows)
            yield return "wdb";   // Microsoft Works database
            yield return "wps";   // Microsoft Works document (duplicate in some systems)
            yield return "wrk";   // Symphony worksheet
            yield return "wr1";   // Symphony worksheet version 1
            yield return "mws";   // Microsoft Works document (Mac)
            yield return "sdw";   // StarWriter/StarOffice Document
            yield return "vor";   // StarOffice Template
            yield return "glox";  // GNU LibreOffice extension
            yield return "oth";   // OpenDocument master document template
            yield return "sxg";   // OpenOffice.org 1.x Master Document
            yield return "sx";    // StarOffice spreadsheet (old)
            yield return "sxc";   // OpenOffice.org 1.x Spreadsheet
            yield return "sxd";   // OpenOffice.org 1.x Drawing
            yield return "sxi";   // OpenOffice.org 1.x Presentation
            yield return "sxm";   // OpenOffice.org 1.x Formula
            #endregion

            #region Specialized E-book & Digital Publishing (~50 extensions)
            // E-book variants and digital publishing formats
            yield return "azw4";  // Amazon Print Replica (KFX with DRM)
            yield return "azw";   // Amazon Kindle Format 7 (older) [citation:1]
            yield return "azw1";  // Amazon Topaz format
            yield return "azw2";  // Amazon Print Replica (older)
            yield return "azw3";  // Amazon KF8 format [citation:1]
            yield return "kf8";   // Amazon Kindle Format 8
            yield return "kfx";   // Amazon Kindle Format Enhanced [citation:1]
            yield return "tpz";   // Amazon Topaz format (alternative)
            yield return "lit";   // Microsoft Reader format [citation:1]
            yield return "lrf";   // Sony BBeB Book (BroadBand eBook)
            yield return "lrs";   // Sony BBeB Book source
            yield return "lrx";   // Sony BBeB Book with DRM
            yield return "rb";    // Rocket eBook
            yield return "pdb";   // Palm Database (e-books) [citation:1]
            yield return "prc";   // Palm Resource (Mobipocket) [citation:1]
            yield return "tr";    // TomeRaider eBook
            yield return "tr2";   // TomeRaider 2
            yield return "tr3";   // TomeRaider 3
            yield return "pkg";   // Apple iBooks (old packaging) [citation:1]
            yield return "ibooks"; // Apple iBooks Author [citation:1]
            yield return "bnk";   // Booknizer library
            yield return "bkk";   // BookBuddi eBook
            yield return "ebk";   // eBook Pro
            yield return "ceb";   // Chinese eBook format
            yield return "caj";   // China Academic Journals format
            yield return "pdf";   // Portable Document Format (legacy variants)
            yield return "fdf";   // Adobe Forms Data Format
            yield return "xfdf";  // XML Forms Data Format
            yield return "pdx";   // Adobe Index Data File
            yield return "pdp";   // Adobe Photoshop Document (for publishing)
            yield return "ind";   // Adobe InDesign Document [citation:1]
            yield return "indd";  // Adobe InDesign Document [citation:1]
            yield return "indt";  // Adobe InDesign Template [citation:1]
            yield return "idml";  // InDesign Markup Language [citation:1]
            yield return "icml";  // InCopy Markup Language
            yield return "pmd";   // PageMaker Document (obsolete)
            yield return "pub";   // Microsoft Publisher [citation:9]
            yield return "mpp";   // Microsoft Project
            yield return "xar";   // Xara graphics document
            yield return "xht";   // XHTML (strict)
            yield return "xhtml"; // XHTML document
            yield return "mht";   // MHTML web archive
            yield return "mhtml"; // MHTML web archive
            yield return "webarchive"; // Apple Web Archive
            yield return "zhtml"; // Compressed HTML
            yield return "maff";  // Mozilla Archive Format
            yield return "scriv"; // Scrivener project
            yield return "scrivx"; // Scrivener XML project
            #endregion

            #region Specialized Audio & Video Codecs (~100 extensions)
            // Audio codecs and containers
            yield return "aax";   // Audible Enhanced Audiobook
            yield return "aa";    // Audible Audiobook (older) [citation:1]
            yield return "act";   // Adaptive Multi-Rate audio
            yield return "amr";   // Adaptive Multi-Rate audio
            yield return "awb";   // Adaptive Multi-Rate WideBand
            yield return "au";    // Sun/NeXT audio
            yield return "snd";   // Sound audio
            yield return "ulaw";  // μ-law audio
            yield return "vox";   // Dialogic ADPCM audio
            yield return "dss";   // Digital Speech Standard
            yield return "dvf";   // Sony Voice File
            yield return "msv";   // Sony Memory Stick Voice
            yield return "ivs";   // 3GPP2 audio
            yield return "m4b";   // MPEG-4 audiobook [citation:1]
            yield return "m4p";   // MPEG-4 protected audio
            yield return "m4r";   // MPEG-4 ringtone
            yield return "mmf";   // Samsung ringtone
            yield return "nmf";   // Nokia ringtone
            yield return "xmf";   // Extended Mobile File
            yield return "mxmf";  // Mobile XMF
            yield return "imy";   // iMelody ringtone
            yield return "rtx";   // Ringtone text transfer
            yield return "ota";   // Over-the-air ringtone
            yield return "qcp";   // Qualcomm PureVoice
            yield return "sln";   // Asterisk raw audio
            yield return "vms";   // Sony PS2 audio
            yield return "voc";   // Creative Voice
            yield return "8svx";  // 8-bit sampled voice
            yield return "nist";  // NIST audio
            yield return "sph";   // NIST sphere audio
            yield return "ircam"; // IRCAM sound
            yield return "sd2";   // Sound Designer II
            yield return "avr";   // Audio Visual Research
            yield return "paf";   // Ensoniq PARIS audio
            yield return "svx";   // Amiga IFF-8SVX audio
            yield return "wve";   // Psion Series 3 audio
            yield return "txw";   // Yamaha TX-16W sampler
            yield return "sds";   // MIDI sample dump
            yield return "mpc";   // Musepack audio
            yield return "mp";    // Monkey's Audio (obsolete extension)
            yield return "ape";   // Monkey's Audio
            yield return "mac";   // Monkey's Audio (alternative)
            yield return "ofr";   // OptimFROG audio
            yield return "ofs";   // OptimFROG streamable
            yield return "spx";   // Ogg Speex audio
            yield return "tta";   // True Audio lossless
            yield return "wv";    // WavPack audio
            yield return "wvc";   // WavPack correction
                                  // Video codecs and containers
            yield return "3g2";   // 3GPP2 multimedia [citation:1]
            yield return "3gp";   // 3GPP multimedia [citation:1]
            yield return "3gpp";  // 3GPP multimedia
            yield return "3gp2";  // 3GPP2 multimedia
            yield return "f4v";   // Flash MP4 video
            yield return "f4p";   // Flash protected MP4
            yield return "f4a";   // Flash MP4 audio
            yield return "f4b";   // Flash MP4 audiobook
            yield return "mk3d";  // Matroska 3D video [citation:1]
            yield return "mks";   // Matroska subtitles [citation:1]
            yield return "nsv";   // Nullsoft Streaming Video
            yield return "roq";   // Quake III Arena video
            yield return "smk";   // Smacker video
            yield return "bik";   // Bink video
            yield return "bk2";   // Bink video 2
            yield return "str";   // PlayStation video
            yield return "pss";   // PlayStation video
            yield return "m2ts";  // MPEG-2 Transport Stream [citation:1]
            yield return "mts";   // AVCHD video [citation:1]
            yield return "tod";   // JVC Everio video
            yield return "mod";   // JVC MOD video
            yield return "mxf";   // Material Exchange Format [citation:1]
            yield return "gxf";   // General eXchange Format [citation:1]
            yield return "xesc";  // Sony XAVC S
            yield return "mcf";   // Matroska Container Format (old)
            yield return "264";   // H.264 elementary stream
            yield return "265";   // H.265 elementary stream
            yield return "h264";  // H.264 video
            yield return "h265";  // H.265/HEVC video
            yield return "hevc";  // High Efficiency Video Coding
            yield return "evt";   // MPEG elementary stream video
            yield return "m1v";   // MPEG-1 video
            yield return "m2v";   // MPEG-2 video
            yield return "m4v";   // MPEG-4 video (Apple)
            yield return "mpv";   // MPEG elementary stream
            yield return "ts";    // MPEG Transport Stream [citation:1]
            yield return "tts";   // MPEG Transport Stream (trick mode)
            yield return "mpeg";  // MPEG video [citation:9]
            yield return "mpg";   // MPEG video [citation:9]
            yield return "mpe";   // MPEG video (alternative)
            yield return "vro";   // DVD-VR video
            yield return "ogv";   // Ogg video
            yield return "ogg";   // Ogg media container [citation:1]
            yield return "spx";   // Ogg Speex (audio, duplicate)
            yield return "opus";  // Opus audio codec [citation:1]
            yield return "ogm";   // Ogg media (old)
            yield return "anx";   // Ogg Annodex
            yield return "axa";   // Ogg Annodex audio
            yield return "axv";   // Ogg Annodex video
            yield return "divx";  // DivX video
            yield return "xvid";  // XviD video
            #endregion

            #region Game Console & Retro System Images (~80 extensions)
            // Console-specific disk and cartridge images
            yield return "iso";   // Generic disc image (repeated for context) [citation:1][citation:9]
            yield return "bin";   // Binary disc image (often with .cue) [citation:1]
            yield return "cue";   // CD cuesheet [citation:1]
            yield return "img";   // Raw disk image [citation:1]
            yield return "ccd";   // CloneCD control
            yield return "sub";   // CloneCD subchannel
            yield return "mds";   // DAEMON Tools image descriptor [citation:1]
            yield return "mdf";   // DAEMON Tools image data [citation:1]
            yield return "mdx";   // DAEMON Tools compressed image [citation:1]
            yield return "nrg";   // Nero Burning ROM image [citation:1]
            yield return "cdi";   // DiscJuggler image [citation:1]
            yield return "cif";   // Easy CD Creator image [citation:1]
            yield return "c2d";   // Roxio-WinOnCD image [citation:1]
            yield return "daa";   // PowerISO compressed image [citation:1]
            yield return "b5t";   // BlindWrite 5 image [citation:1]
            yield return "b6t";   // BlindWrite 6 image [citation:1]
            yield return "bwt";   // BlindWrite 4 image [citation:1]
            yield return "pdi";   // Pinnacle Disc Image [citation:1]
            yield return "d64";   // Commodore 64 disk image [citation:1]
            yield return "d71";   // Commodore 1571 disk image
            yield return "d81";   // Commodore 1581 disk image
            yield return "g64";   // Commodore 64 GCR disk image
            yield return "nib";   // Commodore disk nibble image
            yield return "nbz";   // Compressed NIB image
            yield return "dsk";   // Floppy disk image (multiple systems) [citation:1]
            yield return "adf";   // Amiga disk image [citation:1]
            yield return "adz";   // GZipped Amiga disk image [citation:1]
            yield return "dms";   // Amiga disk archiver [citation:1]
            yield return "ipf";   // Amiga Interchangeable Preservation Format
            yield return "hdf";   // Amiga hard disk image
            yield return "hdz";   // Compressed Amiga HDF
            yield return "st";    // Atari ST disk image
            yield return "msa";   // Atari ST compressed disk
            yield return "dim";   // Atari disk image
            yield return "xfd";   // Atari XF551 disk
            yield return "scp";   // SuperCard Pro floppy image
            yield return "woz";   // Apple II floppy image
            yield return "2mg";   // Apple II disk image
            yield return "dsk";   // Apple II disk image (also Atari)
            yield return "do";    // Apple II DOS 3.3 disk
            yield return "po";    // Apple II ProDOS disk
            yield return "nib";   // Apple II disk nibble
            yield return "hdv";   // Apple II hard disk image
            yield return "fdi";   // Floppy Disk Image (various)
            yield return "td0";   // Teledisk image
            yield return "imd";   // ImageDisk
            yield return "ima";   // Disk image
            yield return "vfd";   // Virtual Floppy Disk [citation:1]
            yield return "vhd";   // Virtual Hard Disk [citation:1]
            yield return "vhdx";  // Virtual Hard Disk v2 [citation:1]
            yield return "vmdk";  // VMware Virtual Disk [citation:1]
            yield return "vdi";   // VirtualBox Disk Image [citation:1]
                                  // Game console-specific formats
            yield return "nes";   // Nintendo Entertainment System ROM
            yield return "nez";   // Compressed NES ROM
            yield return "unf";   // UNIF NES ROM
            yield return "fds";   // Famicom Disk System
            yield return "sfc";   // Super Nintendo/Super Famicom ROM
            yield return "smc";   // Super Nintendo ROM (alternative)
            yield return "fig";   // Super Nintendo ROM (alternative)
            yield return "swc";   // Super Nintendo copier format
            yield return "n64";   // Nintendo 64 ROM
            yield return "z64";   // Nintendo 64 big-endian ROM
            yield return "v64";   // Nintendo 64 byte-swapped ROM
            yield return "nds";   // Nintendo DS ROM
            yield return "ids";   // Nintendo DS (alternative)
            yield return "srl";   // Nintendo DS homebrew
            yield return "3ds";   // Nintendo 3DS ROM
            yield return "cia";   // Nintendo 3DS installable
            yield return "gb";    // Game Boy ROM
            yield return "gbc";   // Game Boy Color ROM
            yield return "gba";   // Game Boy Advance ROM
            yield return "agb";   // Game Boy Advance (alternative)
            yield return "bin";   // Game Boy Advance (also generic)
            yield return "gcz";   // GameCube compressed ISO
            yield return "gcm";   // GameCube ISO
            yield return "iso";   // GameCube/Wii ISO (generic)
            yield return "wbfs";  // Wii Backup File System
            yield return "wad";   // WiiWare/VC package
            yield return "gen";   // Sega Genesis/Mega Drive ROM
            yield return "md";    // Sega Mega Drive ROM
            yield return "smd";   // Super Magic Drive ROM
            yield return "32x";   // Sega 32X ROM
            yield return "sms";   // Sega Master System ROM
            yield return "gg";    // Sega Game Gear ROM
            yield return "sg";    // Sega SG-1000 ROM
            yield return "scd";   // Sega CD/Mega CD ROM
            yield return "cue";   // Sega CD cuesheet (also generic)
            yield return "bin";   // Sega CD data (also generic)
            yield return "pce";   // PC Engine/TurboGrafx-16 ROM
            yield return "sgx";   // PC Engine SuperGrafx ROM
            yield return "chd";   // Compressed Hunks of Data (MAME)
            yield return "m3u";   // Playlist for multi-disc games
            #endregion

            #region Mobile & Embedded Platforms (~70 extensions)
            // Mobile application and data formats
            yield return "apk";   // Android Package [citation:1]
            yield return "aab";   // Android App Bundle [citation:1]
            yield return "xap";   // Windows Phone Application Package [citation:1]
            yield return "appx";  // Microsoft App Package [citation:1]
            yield return "appxbundle"; // App Package Bundle [citation:1]
            yield return "msix";  // MSIX Package [citation:1]
            yield return "msixbundle"; // MSIX Bundle [citation:1]
            yield return "ipa";   // iOS App Archive [citation:1]
            yield return "app";   // macOS Application [citation:1]
            yield return "dmg";   // Apple Disk Image [citation:1]
            yield return "pkg";   // macOS Installer [citation:1]
            yield return "deb";   // Debian Package [citation:1]
            yield return "rpm";   // RPM Package [citation:1]
            yield return "sis";   // Symbian Installation Source [citation:1]
            yield return "sisx";  // Symbian Signed Installation [citation:1]
            yield return "jar";   // Java Archive (mobile Java ME) [citation:1][citation:9]
            yield return "jad";   // Java Application Descriptor
            yield return "prc";   // Palm Resource Code (also e-book)
            yield return "pdb";   // Palm Database (also e-book)
            yield return "alx";   // BlackBerry Application Loader
            yield return "cod";   // BlackBerry Compiled
            yield return "jdp";   // BlackBerry Java
            yield return "bar";   // BlackBerry 10 application
            yield return "cab";   // Windows Mobile Cabinet [citation:1][citation:9]
            yield return "xap";   // Windows Phone (duplicate for context)
            yield return "wlapp"; // WebLogic Application
            yield return "war";   // Web Application Archive [citation:1]
            yield return "ear";   // Enterprise Archive [citation:1]
            yield return "sar";   // Service Archive
                                  // Mobile data and backup formats
            yield return "ab";    // Android Backup
            yield return "adb";   // Alpha Five database
            yield return "backup"; // iOS Backup
            yield return "ibackup"; // iBackup
            yield return "itdb";  // iTunes database
            yield return "itl";   // iTunes Library
            yield return "xml";   // iTunes Library XML
            yield return "library"; // iTunes Library (older)
            yield return "ipsw";  // iOS firmware
            yield return "dfu";   // Device Firmware Upgrade
            yield return "kdxf";  // Kies firmware
            yield return "fbf";   // Flashable Binary File
            yield return "nb0";   // Android NAND backup
            yield return "qcn";   // Qualcomm NV item backup
            yield return "nvram"; // NVRAM backup
            yield return "efs";   // EFS backup (Android)
            yield return "rfs";   // RFS filesystem image
            yield return "ext4";  // EXT4 filesystem image
            yield return "yaffs"; // YAFFS filesystem image
            yield return "jffs2"; // JFFS2 filesystem image
            yield return "cramfs"; // CRAMFS filesystem image
            yield return "squashfs"; // SquashFS filesystem image
            yield return "ubi";   // UBI filesystem image
            yield return "ubifs"; // UBIFS filesystem image
            yield return "f2fs";  // F2FS filesystem image
            yield return "sin";   // Sony firmware image
            yield return "ftf";   // Sony Flash Tool File
            yield return "ops";   // LG firmware
            yield return "kdz";   // LG firmware package
            yield return "dz";    // LG firmware (compressed)
            yield return "bin";   // Generic firmware (also generic)
            yield return "hex";   // Intel HEX firmware
            yield return "s19";   // Motorola S-record
            yield return "s28";   // Motorola S-record 28-bit
            yield return "s37";   // Motorola S-record 37-bit
            yield return "srec";  // Motorola S-record generic
            yield return "elf";   // Executable and Linkable Format
            yield return "axf";   // ARM executable format
            yield return "out";   // Compiled output (various)
            #endregion

            #region Scientific & Instrument Data (~90 extensions)
            // Scientific data formats
            yield return "fits";  // Flexible Image Transport System [citation:1]
            yield return "fit";   // FITS alternative [citation:1]
            yield return "fts";   // FITS alternative [citation:1]
            yield return "cdf";   // Common Data Format (NASA) [citation:1]
            yield return "nc";    // NetCDF [citation:1]
            yield return "hdf";   // Hierarchical Data Format [citation:1]
            yield return "h4";    // HDF4 [citation:1]
            yield return "hdf4";  // HDF4
            yield return "h5";    // HDF5 [citation:1]
            yield return "hdf5";  // HDF5 [citation:1]
            yield return "he5";   // HDF-EOS5
            yield return "mat";   // MATLAB data file [citation:1]
            yield return "m";     // MATLAB script/function
            yield return "fig";   // MATLAB figure
            yield return "mlx";   // MATLAB Live Script
            yield return "sav";   // SPSS data file [citation:1]
            yield return "zsav";  // SPSS compressed data
            yield return "por";   // SPSS portable
            yield return "sps";   // SPSS syntax
            yield return "spo";   // SPSS output
            yield return "sas7bdat"; // SAS dataset [citation:1]
            yield return "sd7";   // SAS data [citation:1]
            yield return "ssd";   // SAS data [citation:1]
            yield return "srd";   // SAS data [citation:1]
            yield return "xpt";   // SAS transport [citation:1]
            yield return "stc";   // SAS catalog
            yield return "dta";   // Stata data [citation:1]
            yield return "dct";   // Stata dictionary
            yield return "do";    // Stata script
            yield return "ado";   // Stata autoload
            yield return "jmp";   // JMP data [citation:1]
            yield return "jsl";   // JMP script [citation:1]
            yield return "jrp";   // JMP report [citation:1]
            yield return "jmpapp"; // JMP application [citation:1]
            yield return "jmpaddin"; // JMP add-in [citation:1]
            yield return "jmpquery"; // JMP query [citation:1]
            yield return "mtw";   // Minitab worksheet
            yield return "mtp";   // Minitab project
            yield return "grf";   // Minitab graph
            yield return "sta";   // Statistica data
            yield return "sxm";   // Scanning Probe Microscopy data
            yield return "spm";   // Scanning Probe Microscopy
            yield return "par";   // Philips PAR/REC [citation:1]
            yield return "rec";   // Philips REC [citation:1]
            yield return "his";   // Hologic HIS [citation:1]
            yield return "lif";   // Leica LIF [citation:1]
            yield return "lei";   // Leica LEI [citation:1]
            yield return "ics";   // Image Cytometry Standard [citation:1]
            yield return "ids";   // Image Data Structure [citation:1]
            yield return "nd2";   // Nikon NIS-Elements [citation:1]
            yield return "nd";    // Nikon Elements Data [citation:1]
            yield return "nef";   // Nikon Elements File [citation:1]
            yield return "oif";   // Olympus OIF [citation:1]
            yield return "oib";   // Olympus OIB [citation:1]
            yield return "oir";   // Olympus OIR [citation:1]
            yield return "dm3";   // DigitalMicrograph 3 [citation:1]
            yield return "dm4";   // DigitalMicrograph 4 [citation:1]
            yield return "spe";   // WinView/WinSpec [citation:1]
            yield return "cxd";   // Compix CellR [citation:1]
            yield return "zvi";   // Zeiss Vision [citation:1]
            yield return "lsm";   // Zeiss LSM [citation:1]
            yield return "czi";   // Zeiss CZI [citation:1]
            yield return "ims";   // Imaris [citation:1]
            yield return "obf";   // Open Bio-Formats [citation:1]
            yield return "csv";   // Comma-separated values (scientific)
            yield return "tsv";   // Tab-separated values
            yield return "txt";   // Text data (scientific)
            yield return "dat";   // Generic data file
            yield return "raw";   // Raw instrument data
            yield return "bin";   // Binary data (scientific)
            yield return "ibw";   // Igor Binary Wave
            yield return "pxp";   // Igor Packed Experiment
            yield return "itx";   // Igor Text
            yield return "awg";   // Arbitrary Waveform Generator
            yield return "tdms";  // Technical Data Management Streaming
            yield return "diadem"; // DIAdem data
            yield return "atf";   // Axon Text Format
            yield return "abf";   // Axon Binary Format
            yield return "pcl";   // Hewlett-Packard Printer Command Language
            yield return "sdf";   // Structure Data Format (chemical)
            yield return "mol";   // MDL Molfile
            yield return "mol2";  // Tripos Mol2
            yield return "pdb";   // Protein Data Bank (also Palm)
            yield return "xyz";   // XYZ coordinate format
            yield return "cif";   // Crystallographic Information File
            yield return "mmcif"; // Macromolecular CIF
            yield return "ent";   // PDB entry format
            yield return "brk";   // Brookhaven protein database
            #endregion

            #region Font & Typography Files (~60 extensions)
            // Font file formats
            yield return "ttf";   // TrueType Font [citation:9]
            yield return "ttc";   // TrueType Collection
            yield return "otf";   // OpenType Font [citation:9]
            yield return "otc";   // OpenType Collection
            yield return "woff";  // Web Open Font Format [citation:9]
            yield return "woff2"; // WOFF2 [citation:9]
            yield return "eot";   // Embedded OpenType [citation:9]
            yield return "fon";   // Bitmapped Font [citation:9]
            yield return "fnt";   // Font File [citation:9]
            yield return "dfont"; // Datafork Font [citation:9]
            yield return "pfb";   // PostScript Type 1 Binary
            yield return "pfa";   // PostScript Type 1 ASCII
            yield return "pfm";   // PostScript Font Metrics
            yield return "afm";   // Adobe Font Metrics
            yield return "pcf";   // Portable Compiled Format
            yield return "bdf";   // Glyph Bitmap Distribution Format
            yield return "fnt";   // Windows Font (duplicate)
            yield return "chr";   // Borland Character Set
            yield return "compositefont"; // Windows Composite Font
            yield return "suit";  // Macintosh Font Suitcase
            yield return "suitcase"; // Font suitcase
            yield return "font";  // Generic font file
            yield return "vlw";   // Processing Font
            yield return "vfb";   // FontLab Studio
            yield return "vfj";   // FontLab VI
            yield return "ufo";   // Unified Font Object
            yield return "ufo2";  // UFO version 2
            yield return "ufo3";  // UFO version 3
            yield return "gxf";   // GTK+ Theme Font
            yield return "txf";   // Texture Font
            yield return "mxf";   // Max Font
                                  // Typeface and typography data
            yield return "ltf";   // LuaTeX font
            yield return "mf";    // Metafont
            yield return "tfm";   // TeX Font Metrics
            yield return "vf";    // Virtual Font
            yield return "enc";   // Encoding file
            yield return "map";   // Font mapping
            yield return "fd";    // Font definition
            yield return "sty";   // Style file (LaTeX)
            yield return "cls";   // Class file (LaTeX)
            yield return "tex";   // TeX document
            yield return "latex"; // LaTeX document
            yield return "ltx";   // LaTeX document
            yield return "dtx";   // Documented LaTeX
            yield return "ins";   // Installation file (LaTeX)
            yield return "bst";   // BibTeX style
            yield return "bib";   // BibTeX database
            yield return "ris";   // Research Information Systems
            yield return "enw";   // EndNote
            yield return "ens";   // EndNote style
            yield return "enl";   // EndNote library
            yield return "csl";   // Citation Style Language
            yield return "cff";   // Citation File Format
            yield return "xml";   // XML citation data
            yield return "json";  // JSON citation data
            yield return "yaml";  // YAML citation data
            yield return "rdf";   // Resource Description Framework
            yield return "tei";   // Text Encoding Initiative
            yield return "mods";  // Metadata Object Description Schema
            yield return "marc";  // MARC record
            yield return "mrc";   // MARC record (binary)
            yield return "mrk";   // MARC record (text)
            #endregion

            #region CAD, CAM & Engineering Systems (~120 extensions)
            // CAD formats from Wikipedia list [citation:1]
            yield return "3dxml"; // Dassault Systèmes graphic representation [citation:1]
            yield return "3mf";   // Microsoft 3D Manufacturing Format [citation:1]
            yield return "acp";   // VA Software VA - Virtual Architecture CAD file [citation:1]
            yield return "amf";   // Additive Manufacturing File Format [citation:1]
            yield return "aec";   // DataCAD drawing format [citation:1]
            yield return "aedt";  // Ansys Electronic Desktop - Project file [citation:1]
            yield return "ar";    // Ashlar-Vellum Argon - 3D Modeling [citation:1]
            yield return "art";   // ArtCAM model [citation:1]
            yield return "asc";   // BRL-CAD Geometry File (old ASCII format) [citation:1]
            yield return "asm";   // Solidedge Assembly, Pro/ENGINEER Assembly [citation:1]
            yield return "brep";  // Open CASCADE 3D model (shape) [citation:1]
            yield return "c3d";   // C3D Toolkit File Format [citation:1]
            yield return "c3p";   // Construct3 Files [citation:1]
            yield return "ccc";   // CopyCAD Curves [citation:1]
            yield return "ccm";   // CopyCAD Model [citation:1]
            yield return "ccs";   // CopyCAD Session [citation:1]
            yield return "cad";   // CadStd [citation:1]
            yield return "catdrawing"; // CATIA V5 Drawing document [citation:1]
            yield return "catpart";   // CATIA V5 Part document [citation:1]
            yield return "catproduct"; // CATIA V5 Assembly document [citation:1]
            yield return "catprocess"; // CATIA V5 Manufacturing document [citation:1]
            yield return "cgr";   // CATIA V5 graphic representation file [citation:1]
            yield return "ckd";   // KeyCreator CAD parts, assemblies, and drawings [citation:1]
            yield return "ckt";   // KeyCreator template file [citation:1]
            yield return "co";    // Ashlar-Vellum Cobalt - parametric drafting and 3D modeling [citation:1]
            yield return "dab";   // AppliCad 3D model CAD file [citation:1]
            yield return "drw";   // Caddie Early version of Caddie drawing [citation:1]
            yield return "dft";   // Solidedge Draft [citation:1]
            yield return "dgn";   // MicroStation design file [citation:1]
            yield return "dgk";   // Delcam Geometry [citation:1]
            yield return "dmt";   // Delcam Machining Triangles [citation:1]
            yield return "dxf";   // ASCII Drawing Interchange file format, AutoCAD [citation:1]
            yield return "dwb";   // VariCAD drawing file [citation:1]
            yield return "dwf";   // Autodesk's Web Design Format [citation:1]
            yield return "dwg";   // Popular format for Computer Aided Drafting applications [citation:1]
            yield return "easm";  // SolidWorks eDrawings assembly file [citation:1]
                                  // Additional CAD/CAM formats
            yield return "prt";   // NX/Unigraphics/Creo Part
            yield return "x_t";   // Parasolid Text
            yield return "x_b";   // Parasolid Binary
            yield return "sat";   // ACIS Text
            yield return "sab";   // ACIS Binary
            yield return "model"; // CATIA V4
            yield return "exp";   // CATIA V4 export
            yield return "session"; // CATIA session
            yield return "cgr";   // CATIA graphic (duplicate)
            yield return "dlv";   // CATIA V4 analysis
            yield return "3di";   // CATIA V4 drawing
            yield return "mf1";   // CATIA V4 macro
            yield return "cat";   // CATIA document (generic)
            yield return "cgm";   // Computer Graphics Metafile
            yield return "igs";   // IGES
            yield return "iges";  // IGES (alternative)
            yield return "stp";   // STEP
            yield return "step";  // STEP (alternative)
            yield return "p21";   // STEP Part 21
            yield return "p28";   // STEP Part 28
            yield return "ifc";   // Industry Foundation Classes
            yield return "ifcxml"; // IFC XML
            yield return "ifczip"; // Compressed IFC
            yield return "cvg";   // Caligari trueSpace
            yield return "cob";   // Caligari Object
            yield return "scn";   // Caligari Scene
            yield return "lwo";   // LightWave Object
            yield return "lws";   // LightWave Scene
            yield return "hv";    // Houdini scene
            yield return "hip";   // Houdini project
            yield return "hipnc"; // Houdini non-commercial
            yield return "hiplc"; // Houdini apprentice
            yield return "otl";   // Houdini digital asset
            yield return "hda";   // Houdini digital asset
            yield return "hdalc"; // Houdini apprentice digital asset
            yield return "bgeo";  // Houdini geometry
            yield return "geo";   // Houdini geometry (ASCII)
            yield return "sim";   // Houdini simulation
            yield return "pic";   // Houdini picture
            yield return "clip";  // Houdini clip
            yield return "ch";    // Houdini channel
            yield return "cmd";   // Houdini command
            yield return "txt";   // Houdini text (generic)
            yield return "nk";    // Nuke script
            yield return "gizmo"; // Nuke plugin
            yield return "mov";   // QuickTime (for CAD animation)
            yield return "avi";   // Video (for CAD animation)
            yield return "mp4";   // MP4 (for CAD animation)
            yield return "flv";   // Flash video (for CAD animation)
            yield return "swf";   // Shockwave Flash (for CAD animation)
            yield return "pdf";   // PDF (for CAD documentation)
            yield return "doc";   // Word (for CAD documentation)
            yield return "xls";   // Excel (for CAD data)
            yield return "ppt";   // PowerPoint (for CAD presentation)
            yield return "txt";   // Text (for CAD notes)
            yield return "rtf";   // Rich Text (for CAD documentation)
            yield return "html";  // HTML (for CAD web publishing)
            yield return "xml";   // XML (for CAD data exchange)
            yield return "json";  // JSON (for CAD data exchange)
            yield return "csv";   // CSV (for CAD data export)
            yield return "tsv";   // TSV (for CAD data export)
            #endregion

            #region Split Archive & Multi-part Files (~40 extensions)
            // Split archive files (as requested by user)
            yield return "001";   // First part of split archive
            yield return "002";   // Second part of split archive
            yield return "003";   // Third part of split archive
            yield return "004";   // Fourth part of split archive
            yield return "005";   // Fifth part of split archive
            yield return "006";   // Sixth part of split archive
            yield return "007";   // Seventh part of split archive
            yield return "008";   // Eighth part of split archive
            yield return "009";   // Ninth part of split archive
            yield return "010";   // Tenth part of split archive
            yield return "011";   // Part 11 of split archive
            yield return "012";   // Part 12 of split archive
            yield return "013";   // Part 13 of split archive
            yield return "014";   // Part 14 of split archive
            yield return "015";   // Part 15 of split archive
            yield return "016";   // Part 16 of split archive
            yield return "017";   // Part 17 of split archive
            yield return "018";   // Part 18 of split archive
            yield return "019";   // Part 19 of split archive
            yield return "020";   // Part 20 of split archive
            yield return "021";   // Part 21 of split archive
            yield return "022";   // Part 22 of split archive
            yield return "023";   // Part 23 of split archive
            yield return "024";   // Part 24 of split archive
            yield return "025";   // Part 25 of split archive
            yield return "026";   // Part 26 of split archive
            yield return "027";   // Part 27 of split archive
            yield return "028";   // Part 28 of split archive
            yield return "029";   // Part 29 of split archive
            yield return "030";   // Part 30 of split archive
            yield return "031";   // Part 31 of split archive
            yield return "032";   // Part 32 of split archive
            yield return "033";   // Part 33 of split archive
            yield return "034";   // Part 34 of split archive
            yield return "035";   // Part 35 of split archive
            yield return "036";   // Part 36 of split archive
            yield return "037";   // Part 37 of split archive
            yield return "038";   // Part 38 of split archive
            yield return "039";   // Part 39 of split archive
            yield return "040";   // Part 40 of split archive
            yield return "r00";   // RAR volume (first after .rar)
            yield return "r01";   // RAR volume part 1 [citation:1]
            yield return "r02";   // RAR volume part 2 [citation:1]
            yield return "r03";   // RAR volume part 3
            yield return "r04";   // RAR volume part 4
            yield return "r05";   // RAR volume part 5
            yield return "r06";   // RAR volume part 6
            yield return "r07";   // RAR volume part 7
            yield return "r08";   // RAR volume part 8
            yield return "r09";   // RAR volume part 9
            yield return "r10";   // RAR volume part 10
            yield return "r11";   // RAR volume part 11
            yield return "r12";   // RAR volume part 12
            yield return "r13";   // RAR volume part 13
            yield return "r14";   // RAR volume part 14
            yield return "r15";   // RAR volume part 15
            yield return "r16";   // RAR volume part 16
            yield return "r17";   // RAR volume part 17
            yield return "r18";   // RAR volume part 18
            yield return "r19";   // RAR volume part 19
            yield return "r20";   // RAR volume part 20
            yield return "r21";   // RAR volume part 21
            yield return "r22";   // RAR volume part 22
            yield return "r23";   // RAR volume part 23
            yield return "r24";   // RAR volume part 24
            yield return "r25";   // RAR volume part 25
            yield return "r26";   // RAR volume part 26
            yield return "r27";   // RAR volume part 27
            yield return "r28";   // RAR volume part 28
            yield return "r29";   // RAR volume part 29
            yield return "r30";   // RAR volume part 30
            yield return "r31";   // RAR volume part 31
            yield return "r32";   // RAR volume part 32
            yield return "r33";   // RAR volume part 33
            yield return "r34";   // RAR volume part 34
            yield return "r35";   // RAR volume part 35
            yield return "r36";   // RAR volume part 36
            yield return "r37";   // RAR volume part 37
            yield return "r38";   // RAR volume part 38
            yield return "r39";   // RAR volume part 39
            yield return "r40";   // RAR volume part 40
            yield return "r41";   // RAR volume part 41
            yield return "r42";   // RAR volume part 42
            yield return "r43";   // RAR volume part 43
            yield return "r44";   // RAR volume part 44
            yield return "r45";   // RAR volume part 45
            yield return "r46";   // RAR volume part 46
            yield return "r47";   // RAR volume part 47
            yield return "r48";   // RAR volume part 48
            yield return "r49";   // RAR volume part 49
            yield return "r50";   // RAR volume part 50
            yield return "r51";   // RAR volume part 51
            yield return "r52";   // RAR volume part 52
            yield return "r53";   // RAR volume part 53
            yield return "r54";   // RAR volume part 54
            yield return "r55";   // RAR volume part 55
            yield return "r56";   // RAR volume part 56
            yield return "r57";   // RAR volume part 57
            yield return "r58";   // RAR volume part 58
            yield return "r59";   // RAR volume part 59
            yield return "r60";   // RAR volume part 60
            yield return "r61";   // RAR volume part 61
            yield return "r62";   // RAR volume part 62
            yield return "r63";   // RAR volume part 63
            yield return "r64";   // RAR volume part 64
            yield return "r65";   // RAR volume part 65
            yield return "r66";   // RAR volume part 66
            yield return "r67";   // RAR volume part 67
            yield return "r68";   // RAR volume part 68
            yield return "r69";   // RAR volume part 69
            yield return "r70";   // RAR volume part 70
            yield return "r71";   // RAR volume part 71
            yield return "r72";   // RAR volume part 72
            yield return "r73";   // RAR volume part 73
            yield return "r74";   // RAR volume part 74
            yield return "r75";   // RAR volume part 75
            yield return "r76";   // RAR volume part 76
            yield return "r77";   // RAR volume part 77
            yield return "r78";   // RAR volume part 78
            yield return "r79";   // RAR volume part 79
            yield return "r80";   // RAR volume part 80
            yield return "r81";   // RAR volume part 81
            yield return "r82";   // RAR volume part 82
            yield return "r83";   // RAR volume part 83
            yield return "r84";   // RAR volume part 84
            yield return "r85";   // RAR volume part 85
            yield return "r86";   // RAR volume part 86
            yield return "r87";   // RAR volume part 87
            yield return "r88";   // RAR volume part 88
            yield return "r89";   // RAR volume part 89
            yield return "r90";   // RAR volume part 90
            yield return "r91";   // RAR volume part 91
            yield return "r92";   // RAR volume part 92
            yield return "r93";   // RAR volume part 93
            yield return "r94";   // RAR volume part 94
            yield return "r95";   // RAR volume part 95
            yield return "r96";   // RAR volume part 96
            yield return "r97";   // RAR volume part 97
            yield return "r98";   // RAR volume part 98
            yield return "r99";   // RAR volume part 99 [citation:1]
            yield return "s00";   // Split volume (alternative)
            yield return "s01";   // Split volume part 1 [citation:1]
            yield return "s02";   // Split volume part 2
            yield return "z01";   // Zip volume part 1
            yield return "z02";   // Zip volume part 2
            yield return "z03";   // Zip volume part 3
            yield return "z04";   // Zip volume part 4
            yield return "z05";   // Zip volume part 5
            yield return "z06";   // Zip volume part 6
            yield return "z07";   // Zip volume part 7
            yield return "z08";   // Zip volume part 8
            yield return "z09";   // Zip volume part 9
            yield return "z10";   // Zip volume part 10
            yield return "z11";   // Zip volume part 11
            yield return "z12";   // Zip volume part 12
            yield return "z13";   // Zip volume part 13
            yield return "z14";   // Zip volume part 14
            yield return "z15";   // Zip volume part 15
            yield return "z16";   // Zip volume part 16
            yield return "z17";   // Zip volume part 17
            yield return "z18";   // Zip volume part 18
            yield return "z19";   // Zip volume part 19
            yield return "z20";   // Zip volume part 20
            yield return "part";  // Generic split part
            yield return "partial"; // Partial download file
            yield return "crdownload"; // Chrome partial download [citation:1]
            #endregion

            #region Various Backup & System Archives (~100 extensions)
            // Backup and system image formats
            yield return "bak";   // Generic backup file
            yield return "backup"; // Backup file
            yield return "old";   // Old version backup
            yield return "orig";  // Original file backup
            yield return "temp";  // Temporary file
            yield return "tmp";   // Temporary file [citation:9]
            yield return "swp";   // Swap file
            yield return "swo";   // Swap file (other)
            yield return "dmp";   // Memory dump
            yield return "core";  // Core dump
            yield return "crash"; // Crash report
            yield return "log";   // Log file [citation:9]
            yield return "err";   // Error log
            yield return "out";   // Output log
            yield return "pid";   // Process ID file
            yield return "lock";  // Lock file
            yield return "lck";   // Lock file (alternative)
            yield return "sem";   // Semaphore file
            yield return "socket"; // Socket file
            yield return "fifo";  // FIFO file
            yield return "ctl";   // Control file
            yield return "conf";  // Configuration file
            yield return "config"; // Configuration file
            yield return "cfg";   // Configuration file
            yield return "ini";   // Initialization file [citation:9]
            yield return "inf";   // Setup information
            yield return "reg";   // Registry file
            yield return "pol";   // Policy file
            yield return "adm";   // Administrative template
            yield return "admx";  // Administrative template XML
            yield return "adml";  // Administrative template language
            yield return "msc";   // Microsoft Management Console
            yield return "mscf";  // Microsoft Management Console saved
            yield return "msi";   // Windows Installer [citation:1][citation:9]
            yield return "msp";   // Windows Installer patch
            yield return "mst";   // Windows Installer transform
            yield return "msm";   // Windows Installer merge module
            yield return "cab";   // Cabinet file [citation:1][citation:9]
            yield return "wim";   // Windows Imaging Format [citation:1]
            yield return "swm";   // Split WIM File [citation:1]
            yield return "esd";   // Electronic Software Distribution [citation:1]
            yield return "ffu";   // Full Flash Update [citation:1]
            yield return "vhd";   // Virtual Hard Disk [citation:1]
            yield return "vhdx";  // Virtual Hard Disk v2 [citation:1]
            yield return "avhd";  // Azure Virtual Hard Disk [citation:1]
            yield return "avhdx"; // Azure VHDX [citation:1]
            yield return "vmdk";  // VMware Virtual Disk [citation:1]
            yield return "vmem";  // VMware Memory [citation:1]
            yield return "vmsn";  // VMware Snapshot [citation:1]
            yield return "vmss";  // VMware Suspended State [citation:1]
            yield return "nvram"; // VMware NVRAM [citation:1]
            yield return "vdi";   // VirtualBox Disk Image [citation:1]
            yield return "vbox";  // VirtualBox Configuration [citation:1]
            yield return "vbox-prev"; // VirtualBox Previous Config [citation:1]
            yield return "ova";   // Open Virtual Appliance [citation:1]
            yield return "ovf";   // Open Virtualization Format [citation:1]
            yield return "mf";    // OVF Manifest [citation:1]
            yield return "cert";  // OVF Certificate [citation:1]
            yield return "qcow";  // QEMU Copy-On-Write [citation:1]
            yield return "qcow2"; // QEMU Copy-On-Write v2 [citation:1]
            yield return "qed";   // QEMU Enhanced Disk [citation:1]
            yield return "vfd";   // Virtual Floppy Disk [citation:1]
            yield return "vud";   // Virtual Undo Disk [citation:1]
            yield return "sdi";   // SDI Image [citation:1]
            yield return "gho";   // Norton Ghost [citation:1]
            yield return "ghs";   // Norton Ghost Span [citation:1]
            yield return "tib";   // Acronis True Image [citation:1]
            yield return "bkf";   // Windows Backup [citation:1]
            yield return "bkc";   // Windows Backup Catalog [citation:1]
            yield return "qbb";   // QuickBooks Backup
            yield return "qbw";   // QuickBooks Working file
            yield return "qbm";   // QuickBooks Portable Company
            yield return "qbr";   // QuickBooks Report Template
            yield return "qbx";   // QuickBooks Accountant's Transfer
            yield return "qby";   // QuickBooks Accountant's Import
            yield return "qwc";   // QuickBooks Web Connector
            yield return "qsm";   // QuickBooks Statement Writer
            yield return "qss";   // QuickBooks Statement Style
            yield return "qst";   // QuickBooks Statement Template
            yield return "qbo";   // QuickBooks Online statement
            yield return "qfx";   // Quicken Interchange Format
            yield return "qif";   // Quicken Interchange Format
            yield return "iif";   // Intuit Interchange Format
            yield return "ofx";   // Open Financial Exchange
            yield return "ofc";   // Open Financial Connectivity
            yield return "mt940"; // SWIFT bank statement
            yield return "bai2";  // Cash management balance
            yield return "aba";   // Australian Bankers' Association
            yield return "camt";  // ISO 20022 Bank statement
            yield return "xbrl";  // eXtensible Business Reporting Language
            yield return "ixbrl"; // Inline XBRL
            #endregion
        }
    }
}
