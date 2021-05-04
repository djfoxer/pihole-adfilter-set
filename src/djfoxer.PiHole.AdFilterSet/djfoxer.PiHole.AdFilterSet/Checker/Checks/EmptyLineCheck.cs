using djfoxer.PiHole.AdFilterSet.Exceptions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker.Checks
{
    public class EmptyLineCheck : BaseCheck, ICheck
    {
        public EmptyLineCheck(ILogger logger) : base(logger)
        { }

        public Task<bool> CheckFile(ValidationInfo validationInfo)
        {
            if (string.IsNullOrWhiteSpace(validationInfo.ValidationInfoItems.Last().Url))
            {
                _logger.LogInformation("Ignore empty line");
                throw new EmptyLineException(validationInfo.ValidationInfoItems.Last().Url);
            }
            return Task.FromResult(true);
        }
    }
}
