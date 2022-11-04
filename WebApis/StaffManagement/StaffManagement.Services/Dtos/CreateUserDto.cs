namespace StaffManagement.Services.Dtos
{
    public class CreateUserDto
    {
        /// <summary>
        /// Ussername of the new users
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password in plain text
        /// </summary>
        public string Password { get; set; }
    }
}
