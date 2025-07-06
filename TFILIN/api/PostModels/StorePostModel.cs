using core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.PostModels
{
    public class StorePostModel
    {
        public int StoreOwnerId { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public double Latitude { get; set; }//קו רוחב

        public double Longitude { get; set; }//קו אורך
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public string MoreDetails { get; set; }
        public string StandPlace { get; set; }
        public bool Status { get; set; }
        public bool PermitRoles { get; set; }
    }
}
