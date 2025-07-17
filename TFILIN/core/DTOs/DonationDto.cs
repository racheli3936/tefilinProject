using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class DonationDto
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public int StandId { get; set; }
        public DateOnly StartDonation { get; set; }
        public DateOnly EndDonation { get; set; }
        public double SumDonation { get; set; }
        public bool Status { get; set; }
        public Item Destination { get; set; }
       // public List<MonthlyDonation> MonthlyDonations { get; set; } = new List<MonthlyDonation>();
        public List<DedicationDto> Dedications { get; set; } = new List<DedicationDto>();
        ///public List<DonorsConversation> PhonesWithDonors { get; set; } = new List<DonorsConversation>();
    }
}
