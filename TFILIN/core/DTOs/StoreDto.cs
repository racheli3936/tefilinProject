using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class StoreDto
    {
        public int Id { get; set; }
        public int StoreOwnerId { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        public double Latitude { get; set; }//קו רוחב
        public double Longitude { get; set; }//קו אורך
        public string MoreDetails { get; set; }
        public string StandPlace { get; set; }
        public bool Status { get; set; }
        public bool PermitRoles { get; set; }
        public List<StoreStandDto> StoreStand { get; set; }
    }
}
