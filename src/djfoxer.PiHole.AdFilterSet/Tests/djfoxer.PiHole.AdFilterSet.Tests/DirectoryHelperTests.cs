using AutoFixture.Xunit2;
using djfoxer.PiHole.AdFilterSet.Configure;
using Xunit;

namespace djfoxer.PiHole.AdFilterSet.Tests
{
    public class DirectoryHelperTests
    {
        public const string FileToCheck = "adfilterset.txt";

        [Theory]
        [InlineAutoData]
        public void FindParentFile_NotExists(string fileName)
        {
            //arrange&act
            var fullPath = DirectoryHelper.FindPathToParentFile(fileName);
            //assert
            Assert.Null(fullPath);
        }

        [Fact]
        public void FindParentFile_Exists()
        {
            //arrange
            var fileName = FileToCheck;
            //act
            var fullPath = DirectoryHelper.FindPathToParentFile(fileName);
            //assert
            Assert.NotNull(fullPath);
        }
    }
}
