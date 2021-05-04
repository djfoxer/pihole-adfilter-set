using djfoxer.PiHole.AdFilterSet.Checker.Checks;
using djfoxer.PiHole.AdFilterSet.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker
{
    public class AdFilterSetChecker : IAdFilterSetChecker
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AdFilterSetChecker> _logger;

        public AdFilterSetChecker(ILogger<AdFilterSetChecker> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }

        public async Task<bool> CheckAdFilterSet(string pathToAdFilterSet, bool cleanFile)
        {
            var items = await Check(pathToAdFilterSet);
            if (items.FileReadException != null)
            {
                _logger.LogInformation(items.FileReadException, "CheckError");
                return false;
            }

            var correctItems = items.ValidationInfoItems.Where(x => x.Exception == null).Select(x => x.Url).OrderBy(x => x);
            if (cleanFile && correctItems.Any())
            {
                await File.WriteAllLinesAsync(pathToAdFilterSet, correctItems, Encoding.UTF8);
                _logger.LogInformation("File updated");
            }

            return !items.ValidationInfoItems.Any(x => x.Exception != null);
        }

        public async Task<ValidationInfo> Check(string pathToAdFilterSet)
        {
            var validation = new ValidationInfo();
            try
            {
                var allChecks = CheckerFactory.GetAllChecks(_logger, _httpClient);
                foreach (var url in await File.ReadAllLinesAsync(pathToAdFilterSet))
                {
                    var validationItem = new ValidationInfoItem(url);
                    validation.ValidationInfoItems.Add(validationItem);
                    try
                    {
                        foreach (var check in allChecks)
                        {
                            await check.CheckFile(validation);
                        }
                    }
                    catch (Exception e)
                    {
                        validationItem.Exception = e;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"File exception");
                validation.FileReadException = new FileReadException($"Exception for path: {pathToAdFilterSet}", e);
            }
            return validation;
        }
    }
}
