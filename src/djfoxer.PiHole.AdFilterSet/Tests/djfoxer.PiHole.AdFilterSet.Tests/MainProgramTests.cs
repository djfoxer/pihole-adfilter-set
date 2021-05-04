using djfoxer.PiHole.AdFilterSet.Configure;
using djfoxer.PiHole.AdFilterSet.set;
using System.Threading.Tasks;
using Xunit;

namespace djfoxer.PiHole.AdFilterSet.Tests
{
    public class MainProgramTests
    {
        [Fact]
        public async Task CheckAdFilterSet_AllUrlValid()
        {
            //arrange
            var pathUrl = DirectoryHelper.FindPathToParentFile(DirectoryHelperTests.FileToCheck);
            //act
            var checkResult = await Program.CheckAdFilterSet(pathUrl, false);
            //assert
            Assert.True(checkResult);
        }
    }
}
