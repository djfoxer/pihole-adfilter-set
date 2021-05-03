using djfoxer.PiHole.AdFilterSet.Exceptions;
using System.Collections.Generic;

namespace djfoxer.PiHole.AdFilterSet.Checker
{
    public class ValidationInfo
    {
        public ValidationInfo()
        {
            ValidationInfoItems = new List<ValidationInfoItem>();
        }
        public ICollection<ValidationInfoItem> ValidationInfoItems { get; set; }
        public FileReadException FileReadException { get; set; }
    }
}
