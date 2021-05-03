using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker
{
    public interface IAdFilterSetChecker
    {
        Task ValidAndUpdate(string pathToAdFilterSet);
    }
}