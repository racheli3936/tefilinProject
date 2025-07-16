using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class StoreStandDto
    {
        public int Id { get; set; }
        public int StandId { get; set; }
        public int StoreId { get; set; }
        public DateOnly ActivityStartDate { get; set; }
        public DateOnly ActivityEndDate { get; set; }
        public int AlonimCount { get; set; }
        public string Notes { get; set; }
        public TimeOnly ActivityHoursStart { get; set; }
        public TimeOnly ActivityHoursEnd { get; set; }
    }
}
