using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
   
    public class Donation
    {
        [Key]
        public int Id { get; set; }
        public int DonorId {  get; set; }
        public int StandId {  get; set; }
        public DateOnly StartDonation { get; set; }
        public DateOnly EndDonation { get;set; }
        public double SumDonation {  get; set; }
        public bool Status { get; set; }
        public Item Destination {  get; set; }
        public List<MonthlyDonation> MonthlyDonations { get; set; }=new List<MonthlyDonation>();
        public List<Dedication> Dedications { get; set; } = new List<Dedication>();
        public List<DonorsConversation> PhonesWithDonors { get; set; }= new List<DonorsConversation>();
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
