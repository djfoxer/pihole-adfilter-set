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
        private readonly HttpClient _hc;
        private readonly ILogger<AdFilterSetChecker> _logger;

        public AdFilterSetChecker(ILogger<AdFilterSetChecker> logger)
        {
            _hc = new HttpClient();
            _logger = logger;
        }

        public async Task ValidAndUpdate(string pathToAdFilterSet)
        {
            var items = await Check(pathToAdFilterSet);
            if (items.FileReadException != null)
            {
                _logger.LogInformation(items.FileReadException, "CheckError");
                return;
            }

            var correctItems = items.ValidationInfoItems.Where(x => x.Exception == null).Select(x => x.Url).OrderBy(x => x);
            if (correctItems.Any())
            {
                await File.WriteAllLinesAsync(pathToAdFilterSet, correctItems, Encoding.UTF8);
                _logger.LogInformation("File updated");
            }
            else
            {
                _logger.LogInformation("All data is incorrect");
            }
        }

        protected async Task<ValidationInfo> Check(string pathToAdFilterSet)
        {
            var validation = new ValidationInfo();
            try
            {
                foreach (var url in await File.ReadAllLinesAsync(pathToAdFilterSet))
                {
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        _logger.LogInformation("Ignore empty line");
                        continue;
                    }

                    var validationItem = new ValidationInfoItem(url);
                    try
                    {
                        IsUrlValid(url);
                        await CheckFile(url);
                    }
                    catch (Exception e)
                    {
                        validationItem.Exception = e;
                    }
                    finally
                    {
                        validation.ValidationInfoItems.Add(validationItem);
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

        protected bool IsUrlValid(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                _logger.LogError($"Url bad format:{url}");
                throw new WrongUrlException(url);
            }
            return true;
        }

        protected async Task CheckFile(string url)
        {
            var response = await _hc.GetAsync(url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.LogError($"Missing data in:{url}");
                throw new MissingDataException(url);
            }
            else
            {
                _logger.LogInformation($"Valid url:{url}");
            }
        }
    }
}
