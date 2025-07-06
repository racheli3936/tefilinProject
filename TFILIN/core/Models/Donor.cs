using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        public string Email { get; set; }
        public List<Donation> Donations { get; set; } = new List<Donation>();
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
