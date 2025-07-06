using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
   public class Stand
    {
        [Key]
        public int Id { get; set; }
        public int StandId { get; set; }

        public bool Status { get; set; }
        public string Notes {  get; set; }
        public int CountTefilin { get; set; }
        public bool IsThereLeftHanded {  get; set; }
        public DateOnly LastCheckDate {  get; set;}
        public TefilinStatus TefilinStatus {  get; set; }
        public List<Visit> Visits { get; set; }=new List<Visit>();
        public List<StandItem> StandItems { get; set; } = new List<StandItem>();
        public List<Donation>Donations { get; set; }=new List<Donation>();
        public List<StoreStand> StoreStands { get; set; }
       
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
