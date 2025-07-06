using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }
        public int StoreStandId {  get; set; }
        public int UserId {  get; set; }
        public DateTime VisitDate { get; set; }
        public string Satisfaction { get; set; }
        public string Notes {  get; set; }
        public int Img {  get; set; }
        public List<ToDoVisit> ToDo {  get; set; }
        public double SumCharity {  get; set; }

        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
 