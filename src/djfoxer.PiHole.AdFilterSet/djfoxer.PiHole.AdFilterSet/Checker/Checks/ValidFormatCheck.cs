using djfoxer.PiHole.AdFilterSet.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker.Checks
{
    public class ValidFormatCheck : BaseCheck, ICheck
    {
        public ValidFormatCheck(ILogger logger) : base(logger)
        { }

        public Task<bool> CheckFile(ValidationInfo validationInfo)
        {
            var currentUrl = validationInfo.ValidationInfoItems.Last().Url;
            if (!Uri.IsWellFormedUriString(currentUrl, UriKind.Absolute))
            {
                _logger.LogError($"Url bad format:{currentUrl}");
                throw new WrongUrlException(currentUrl);
            }
            return Task.FromResult(true);
        }
    }
}
