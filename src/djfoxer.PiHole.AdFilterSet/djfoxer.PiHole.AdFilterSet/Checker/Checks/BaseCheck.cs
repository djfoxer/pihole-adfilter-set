using Microsoft.Extensions.Logging;

namespace djfoxer.PiHole.AdFilterSet.Checker.Checks
{
    public abstract class BaseCheck
    {
        protected readonly ILogger _logger;
        public BaseCheck(ILogger logger)
        {
            _logger = logger;
        }
    }
}
