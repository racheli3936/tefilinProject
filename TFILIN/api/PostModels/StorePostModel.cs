using core.Models;
using System.ComponentModel.DataAnnotations;

namespace api.PostModels
{
    public class StorePostModel
    {
        public int StoreOwnerId { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        public string MoreDetails { get; set; }
        public string StandPlace { get; set; }
        public bool Status { get; set; }
        public bool PermitRoles { get; set; }
    }
}
