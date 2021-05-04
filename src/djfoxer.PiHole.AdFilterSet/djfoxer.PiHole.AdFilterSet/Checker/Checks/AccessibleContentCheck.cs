using djfoxer.PiHole.AdFilterSet.Exceptions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker.Checks
{

    public class AccessibleContentCheck : BaseCheck, ICheck
    {
        private readonly HttpClient _httpClient;
        public AccessibleContentCheck(ILogger logger, HttpClient httpClient) : base(logger)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CheckFile(ValidationInfo validationInfo)
        {
            var currentUrl = validationInfo.ValidationInfoItems.Last().Url;
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.GetAsync(currentUrl);
            }
            catch (HttpRequestException)
            {
                _logger.LogError($"Incorrect url:{currentUrl}");
                throw new MissingHostException(currentUrl);
            }
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.LogError($"Missing data in:{currentUrl}");
                throw new MissingDataException(currentUrl);
            }
            else
            {
                _logger.LogInformation($"Valid url:{currentUrl}");
                return true;
            }
        }
    }
}
