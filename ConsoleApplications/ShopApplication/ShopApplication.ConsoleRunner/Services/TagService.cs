using ShopApplication.ConsoleRunner.Models;

namespace ShopApplication.ConsoleRunner.Services
{
    public class TagService
    {
        private TagFileService _fileService = new TagFileService();

        public void Create(Tag tag)
        {
            var tags = _fileService.GetAll();

            tags.Add(tag);

            _fileService.Write(tags);
        }

        public List<Tag> GetAll()
        {

            return _fileService.GetAll();
        }
    }
}
