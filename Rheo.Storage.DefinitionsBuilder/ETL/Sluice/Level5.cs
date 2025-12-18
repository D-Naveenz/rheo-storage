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
            #region Obsolete Office Formats
            yield return "wks";
            yield return "wk1";
            yield return "wk2";
            yield return "wk3";
            yield return "wk4";
            yield return "123";
            yield return "qpw";
            yield return "wq1";
            yield return "wq2";
            yield return "wr1";
            yield return "xlr";
            yield return "sdc";
            yield return "sdd";
            yield return "sdp";
            yield return "sdw";
            yield return "vor";
            yield return "stw";
            yield return "sxg";
            yield return "sxi";
            yield return "sxm";
            #endregion

            #region Legacy Audio Formats
            yield return "mod";
            yield return "xm";
            yield return "it";
            yield return "s3m";
            yield return "669";
            yield return "amf";
            yield return "dsm";
            yield return "far";
            yield return "gdm";
            yield return "imf";
            yield return "m15";
            yield return "med";
            yield return "mtm";
            yield return "okt";
            yield return "stm";
            yield return "stx";
            yield return "ult";
            yield return "uni";
            yield return "mpt";
            yield return "digi";
            yield return "dmf";
            #endregion

            #region Legacy Image Formats
            yield return "pcx";
            yield return "ras";
            yield return "sgi";
            yield return "rgb";
            yield return "rgba";
            yield return "bw";
            yield return "cin";
            yield return "dpx";
            yield return "fits";
            yield return "fts";
            yield return "hdr";
            yield return "ifl";
            yield return "iwi";
            yield return "jxr";
            yield return "wdp";
            yield return "lbm";
            yield return "iff";
            yield return "ilbm";
            yield return "ham";
            yield return "ham8";
            yield return "ehb";
            yield return "pbm";
            yield return "pgm";
            yield return "ppm";
            yield return "pam";
            yield return "pfm";
            #endregion

            #region Legacy Video Formats
            yield return "fli";
            yield return "flc";
            yield return "cel";
            yield return "ply";
            yield return "smk";
            yield return "bik";
            yield return "bk2";
            yield return "roq";
            yield return "cin";
            yield return "dpx";
            yield return "yuv";
            yield return "y4m";
            yield return "nut";
            yield return "nsv";
            yield return "mka";
            #endregion

            #region Emulator & Retro Computing
            yield return "adf";      // Amiga
            yield return "adz";
            yield return "dms";
            yield return "ipf";
            yield return "hdf";
            yield return "hfe";      // Floppy images
            yield return "fdi";
            yield return "imd";
            yield return "td0";
            yield return "cqm";
            yield return "d88";
            yield return "fdi";
            yield return "img";
            yield return "ima";
            yield return "vfd";
            yield return "vhd";
            yield return "vmdk";
            #endregion

            #region Network & Packet Captures
            yield return "pcap";
            yield return "cap";
            yield return "dmp";
            yield return "ncf";
            yield return "ncap";
            yield return "pcapng";
            yield return "erf";
            yield return "rf5";
            yield return "snoop";
            yield return "tcpdump";
            yield return "enc";
            yield return "tr1";
            #endregion

            #region BIOS/UEFI/Firmware
            yield return "bin";
            yield return "rom";
            yield return "efi";
            yield return "fd";
            yield return "cap";
            yield return "bio";
            yield return "ima";
            yield return "img";
            yield return "fl1";
            yield return "fl2";
            yield return "flp";
            yield return "fd0";
            yield return "fd1";
            yield return "hdd";
            yield return "fdd";
            #endregion

            #region Printer & Plotter Formats
            yield return "prn";
            yield return "plt";
            yield return "hpgl";
            yield return "hpg";
            yield return "gl";
            yield return "gl2";
            yield return "ps";
            yield return "eps";
            yield return "epsi";
            yield return "ai";
            yield return "pcl";
            yield return "pxl";
            yield return "px3";
            yield return "spl";
            yield return "shd";
            yield return "spl";
            #endregion

            #region Data Acquisition & Instruments
            yield return "tdms";
            yield return "tdm";
            yield return "dat";
            yield return "txt";
            yield return "csv";
            yield return "bin";
            yield return "raw";
            yield return "h5";
            yield return "hdf5";
            yield return "mat";
            yield return "m";
            yield return "mdf";
            yield return "mf4";
            yield return "rpc";
            yield return "rpd";
            yield return "rph";
            yield return "rpk";
            #endregion

            #region Archive Parts & Volumes
            yield return "001";
            yield return "002";
            yield return "003";
            yield return "r00";
            yield return "r01";
            yield return "r02";
            yield return "z01";
            yield return "z02";
            yield return "z03";
            yield return "part1";
            yield return "part2";
            yield return "part3";
            yield return "seg1";
            yield return "seg2";
            yield return "cd1";
            yield return "cd2";
            yield return "disk1";
            yield return "disk2";
            #endregion

            #region Very Specific Software
            yield return "mpp";      // Microsoft Project
            yield return "mpt";
            yield return "vsd";      // Visio
            yield return "vdx";
            yield return "vsdx";
            yield return "vsdm";
            yield return "vsdx";
            yield return "pub";      // Publisher
            yield return "xps";
            yield return "oxps";
            yield return "mht";
            yield return "mhtml";
            yield return "url";
            yield return "webloc";
            yield return "desktop";
            yield return "lnk";
            yield return "pif";
            yield return "scr";
            yield return "cpl";
            yield return "msc";
            yield return "gadget";
            yield return "theme";
            yield return "themepack";
            yield return "deskthemepack";
            #endregion
        }
    }
}
