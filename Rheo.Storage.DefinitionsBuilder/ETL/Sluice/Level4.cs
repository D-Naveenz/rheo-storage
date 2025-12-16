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
            #region Legacy Office & Documents
            yield return "wpd";      // WordPerfect
            yield return "wps";      // Works
            yield return "wri";      // Write
            yield return "mcw";      // MacWrite
            yield return "sam";      // AmiPro
            yield return "602";      // Text602
            yield return "pages";
            yield return "numbers";
            yield return "key";
            #endregion

            #region E-book Variants
            yield return "fb2";
            yield return "lit";
            yield return "pdb";      // Palm
            yield return "tr3";      // TomeRaider
            yield return "cbr";
            yield return "cbz";
            yield return "cb7";
            yield return "cbt";
            #endregion

            #region Audio Codecs & Containers
            yield return "ape";
            yield return "tta";
            yield return "wv";
            yield return "tak";
            yield return "ofr";
            yield return "ofs";
            yield return "spx";
            yield return "ra";
            yield return "rm";
            yield return "aa";
            yield return "aax";
            yield return "mka";
            #endregion

            #region Video Codecs & Containers
            yield return "rmvb";
            yield return "ogv";
            yield return "divx";
            yield return "xvid";
            yield return "h264";
            yield return "h265";
            yield return "hevc";
            yield return "vp9";
            yield return "av1";
            yield return "3gp";
            yield return "3g2";
            yield return "f4v";
            yield return "swf";
            #endregion

            #region Game Console Formats
            // Nintendo
            yield return "nsp";
            yield return "xci";
            yield return "nds";
            yield return "3ds";
            yield return "cia";
            yield return "gba";
            yield return "gbc";
            yield return "gb";
            yield return "nes";
            yield return "snes";
            yield return "n64";
            yield return "z64";

            // Sony
            yield return "pkg";
            yield return "iso";      // PS1/PS2
            yield return "bin";
            yield return "cue";
            yield return "eboot";
            yield return "vpk";      // Vita

            // Microsoft
            yield return "xex";
            yield return "xbe";
            yield return "god";
            yield return "iso";      // Xbox
            #endregion

            #region Mobile & Embedded
            yield return "apk";
            yield return "aab";
            yield return "ipa";
            yield return "deb";
            yield return "rpm";
            yield return "ipk";
            yield return "appx";
            yield return "appxbundle";
            yield return "xap";
            yield return "bar";      // BlackBerry
            #endregion

            #region Scientific Instruments
            yield return "cdf";
            yield return "fits";
            yield return "fts";
            yield return "hdf";
            yield return "h4";
            yield return "h5";
            yield return "sdf";
            yield return "mol";
            yield return "mol2";
            yield return "pdb";      // Protein Data Bank
            yield return "ent";
            yield return "mmcif";
            #endregion

            #region Fonts & Typography
            yield return "ttf";
            yield return "otf";
            yield return "ttc";
            yield return "woff";
            yield return "woff2";
            yield return "eot";
            yield return "dfont";
            yield return "pfa";
            yield return "pfb";
            yield return "afm";
            yield return "pfm";
            #endregion

            #region CAD/CAM Variants
            yield return "catpart";
            yield return "catproduct";
            yield return "cgr";
            yield return "model";
            yield return "session";
            yield return "exp";
            yield return "dlv";
            yield return "mf1";
            yield return "neu";
            #endregion

            #region Backup Variants
            yield return "arc";
            yield return "pak";
            yield return "zoo";
            yield return "ha";
            yield return "lha";
            yield return "lzh";
            yield return "pit";
            yield return "sea";
            yield return "sit";
            yield return "sitx";
            yield return "bz";
            yield return "tbz";
            yield return "tbz2";
            yield return "tgz";
            #endregion
        }
    }
}
