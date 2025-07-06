using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class DonorsConversation
    {
        public int Id { get; set; }
        public int DonationId {  get; set; }
        public int UserId {  get; set; }
        public DateTime ConversionDate { get; set; }
        public StatusCall statusCall { get; set; }
        public string result {  get; set; }
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
