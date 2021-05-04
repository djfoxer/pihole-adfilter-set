using djfoxer.PiHole.AdFilterSet.Exceptions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker.Checks
{
    public class DuplicateCheck : BaseCheck, ICheck
    {
        public DuplicateCheck(ILogger logger) : base(logger)
        { }

        public Task<bool> CheckFile(ValidationInfo validationInfo)
        {
            var currentUrl = validationInfo.ValidationInfoItems.Last().Url.ToLower();
            if (validationInfo.ValidationInfoItems.SkipLast(1).Any(x => x.Url.ToLower() == currentUrl))
            {
                _logger.LogInformation($"Duplica url{currentUrl}");
                throw new DuplicateLineException(currentUrl);
            }
            return Task.FromResult(true);
        }
    }
}
