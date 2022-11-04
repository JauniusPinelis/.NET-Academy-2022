using Revision.Helpers;

namespace Revision.Services
{
    public class ImageService
    {
        public void Import(string url)
        {
            // write code which trims url
            StringHelpers.TrimUrl(url);
        }
    }
}
