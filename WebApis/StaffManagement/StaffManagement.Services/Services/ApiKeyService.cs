using StaffManagement.Repositories;
using StaffManagement.Repositories.Entities;
using System.Security.Cryptography;

namespace StaffManagement.Services.Services
{
    public class ApiKeyService
    {
        private readonly DataContext _context;

        public ApiKeyService(DataContext context)
        {
            _context = context;
        }

        public void CreateApiKey(string userId)
        {

            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);

            string apiKey = Convert.ToBase64String(key);

            var userApiKey = new UserApiKey
            {
                ApplicationUserId = userId,
                Value = apiKey,
            };

            _context.Add(userApiKey);

            _context.SaveChanges();
        }
    }
}
