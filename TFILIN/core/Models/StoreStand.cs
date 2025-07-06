using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class StoreStand
    {
        [Key]
        public int Id { get; set; }
        public int StandId { get; set; }
        public int StoreId {  get; set; }
        public DateOnly ActivityStartDate { get; set; }
        public DateOnly ActivityEndDate { get; set; }
        public int AlonimCount{ get; set;}
        public string Notes { get; set; }
        public TimeOnly ActivityHoursStart { get; set; }
        public TimeOnly ActivityHoursEnd { get; set; }
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
