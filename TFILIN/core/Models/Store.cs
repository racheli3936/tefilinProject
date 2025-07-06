using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
   public class Store
    {
        [Key]
        public int Id { get; set; }
        public int StoreOwnerId {  get; set; }
        public string StoreName { get; set; }
        public string Phone  { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public double Latitude { get; set; }//קו רוחב
        [Column(TypeName = "decimal(9,6)")]
        public double Longitude { get; set; }//קו אורך
        public string MoreDetails { get; set; }
        public string StandPlace { get; set; }
        public bool Status { get; set; }
        public bool PermitRoles { get; set; }
        
        public List<StoreStand> StoreStand {  get; set; }
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
