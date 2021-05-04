using System.IO;

namespace djfoxer.PiHole.AdFilterSet.Configure
{
    public static class DirectoryHelper
    {
        public static string FindPathToParentFile(string parentFileName, string current = null)
        {
            current ??= Directory.GetCurrentDirectory();
            var filePath = Path.Combine(current, parentFileName);
            if (File.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                var parent = Directory.GetParent(current);
                if (parent != null)
                {
                    return FindPathToParentFile(parentFileName, parent.FullName);
                }
            }
            return null;
        }
    }
}
