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
            #region Business & Finance
            // Accounting
            yield return "qbo";      // QuickBooks
            yield return "qbx";
            yield return "ofx";
            yield return "qif";

            // Database formats
            yield return "accdb";
            yield return "mdf";
            yield return "ldf";
            yield return "fdb";      // Firebird
            yield return "db3";
            #endregion

            #region Engineering & CAD
            yield return "ipt";      // Inventor
            yield return "iam";
            yield return "idw";
            yield return "dgn";      // MicroStation
            yield return "sat";      // ACIS
            yield return "step";
            yield return "iges";
            yield return "stp";
            yield return "igs";
            yield return "prt";      // NX/ProE
            yield return "asm";
            yield return "drw";
            #endregion

            #region GIS & Mapping
            yield return "shp";
            yield return "shx";
            yield return "dbf";
            yield return "prj";
            yield return "kml";
            yield return "kmz";
            yield return "gpx";
            yield return "geojson";
            yield return "mif";      // MapInfo
            yield return "tab";
            #endregion

            #region Medical & Scientific
            yield return "dicom";
            yield return "dcm";
            yield return "nii";
            yield return "nifti";
            yield return "mnc";
            yield return "analyze";
            yield return "imzml";
            yield return "mzml";
            yield return "mzxml";
            yield return "raw";      // Mass spec
            yield return "wiff";
            #endregion

            #region Game Development
            // Game engine assets
            yield return "ma";       // Maya ASCII
            yield return "mb";       // Maya Binary
            yield return "max";      // 3ds Max
            yield return "c4d";      // Cinema 4D
            yield return "lxo";      // Modo
            yield return "ztl";      // ZBrush

            // Game textures
            yield return "dds";
            yield return "tga";
            yield return "pvr";
            yield return "ktx";
            yield return "astc";

            // Audio game formats
            yield return "fsb";      // FMOD
            yield return "bank";     // Wwise
            yield return "wwise";
            #endregion

            #region Backup & System
            yield return "bak";
            yield return "tmp";
            yield return "swp";
            yield return "pagefile";
            yield return "hiberfil";
            yield return "dmp";      // Memory dump
            yield return "crash";
            #endregion

            #region Multimedia Containers
            yield return "mk3d";
            yield return "mka";
            yield return "mks";
            yield return "bdmv";
            yield return "clpi";
            yield return "mpls";
            #endregion

            #region Compression & Packaging
            yield return "bz2";
            yield return "xz";
            yield return "lz";
            yield return "lz4";
            yield return "lzma";
            yield return "zst";
            yield return "zstd";
            yield return "lzh";
            yield return "ace";
            yield return "arj";
            yield return "cab";
            #endregion

            #region Email & Communication
            yield return "pst";
            yield return "ost";
            yield return "eml";
            yield return "msg";
            yield return "mbox";
            yield return "dbx";
            yield return "tnef";
            #endregion

            #region Security & Certificates
            yield return "pem";
            yield return "cer";
            yield return "crt";
            yield return "key";
            yield return "pfx";
            yield return "p12";
            yield return "p7b";
            yield return "p7s";
            yield return "sig";
            #endregion
        }
    }
}
