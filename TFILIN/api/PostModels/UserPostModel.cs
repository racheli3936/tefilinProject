using core.Models;

namespace api.PostModels
{
    public class UserPostModel
    {
       
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RolePostModel Role { get; set; }
       
    }
}
