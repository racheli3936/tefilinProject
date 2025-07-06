using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class MonthlyDonation
    {
        [Key]
        public int Id { get; set; }
        public int DonationId {  get; set; }
        public DateOnly DonationDate { get; set; }
        public double Sum {  get; set; }
        public CreditStatus Status {  get; set; }
        public string Suffix {  get; set; }
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
