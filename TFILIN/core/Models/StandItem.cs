using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class StandItem
    {
        public int Id { get; set; }
        public int ItemId {  get; set; }
        public int StandId {  get; set; }
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
