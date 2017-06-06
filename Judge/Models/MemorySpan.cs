namespace Judge.Models
{
    public class MemorySpan
    {
        private readonly long _bytes;
        public long TotalKilobytes => _bytes / 1024;
        public long TotalMegabytes => _bytes / 1024 / 1024;

        public MemorySpan(long bytes)
        {
            _bytes = bytes;
        }
    }
}
