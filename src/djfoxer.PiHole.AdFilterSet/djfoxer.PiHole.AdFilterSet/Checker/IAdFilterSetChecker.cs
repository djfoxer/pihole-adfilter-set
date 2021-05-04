using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker
{
    public interface IAdFilterSetChecker
    {
        Task<bool> CheckAdFilterSet(string pathToAdFilterSet, bool cleanFile);
    }
}