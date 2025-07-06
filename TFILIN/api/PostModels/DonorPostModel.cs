using core.Models;

namespace api.PostModels
{
    public class DonorPostModel
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        public string Email { get; set; }
    }
}
