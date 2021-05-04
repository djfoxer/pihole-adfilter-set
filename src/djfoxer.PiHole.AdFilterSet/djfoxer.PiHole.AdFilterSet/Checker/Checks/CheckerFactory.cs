using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;

namespace djfoxer.PiHole.AdFilterSet.Checker.Checks
{
    public static class CheckerFactory
    {
        public static List<ICheck> GetAllChecks(ILogger logger, HttpClient httpClient)
        {
            return new List<ICheck>()
            {
                new EmptyLineCheck(logger),
                new DuplicateCheck(logger),
                new ValidFormatCheck(logger),
                new AccessibleContentCheck(logger,httpClient),
            };
        }
    }
}
