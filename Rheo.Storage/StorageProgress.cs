namespace Rheo.Storage
{
    public class StorageProgress
    {
        public long TotalBytes { get; set; }
        public long BytesTransferred { get; set; }
        public double BytesPerSecond { get; set; }
        public double ProgressPercentage => TotalBytes == 0 ? 0 : (double)BytesTransferred / TotalBytes * 100;
    }
}
