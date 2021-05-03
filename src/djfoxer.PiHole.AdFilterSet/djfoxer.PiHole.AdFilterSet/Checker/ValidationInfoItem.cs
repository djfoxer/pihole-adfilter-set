using System;

namespace djfoxer.PiHole.AdFilterSet.Checker
{
    public class ValidationInfoItem
    {
        public ValidationInfoItem(string url)
        {
            Url = url;
        }
        public string Url { get; set; }
        public Exception Exception { get; set; }
    }
}
