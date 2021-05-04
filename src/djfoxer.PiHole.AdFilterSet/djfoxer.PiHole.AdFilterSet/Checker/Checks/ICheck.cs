using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Checker.Checks
{
    public interface ICheck
    {
        Task<bool> CheckFile(ValidationInfo validationInfo);
    }
}
