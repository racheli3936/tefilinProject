using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class MonthlyDonationDto
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public DateOnly DonationDate { get; set; }
        public double Sum { get; set; }
        public CreditStatus Status { get; set; }
        public string Suffix { get; set; }
    }
}
