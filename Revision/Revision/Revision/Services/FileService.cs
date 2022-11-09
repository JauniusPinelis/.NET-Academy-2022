using Revision.Helpers;

namespace Revision.Services
{
    public class FileService : IFileService
    {


        public void Import(string url, int age, int type = 5)
        {
            string state = "";
            // write code which trims url
            StringHelpers.TrimUrl(url);
        }


    }
}
