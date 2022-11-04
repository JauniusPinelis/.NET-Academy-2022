using Revision.Helpers;

namespace Revision.Services
{
    public class FileService : IFileService
    {


        public void Import(string url)
        {
            string state = "";
            // write code which trims url
            StringHelpers.TrimUrl(url);
        }


    }
}
