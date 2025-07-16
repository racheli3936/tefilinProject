using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class StoreOwnerConversation
    {
        [Key]
        public int Id { get; set; }
        public int StoreOwnerId { get; set; }
        public int StoreStandId {  get; set; }
        public int UserId { get; set; }
        public DateTime ConversionDate { get; set; }
        public StatusCall StatusCall { get; set; }
        public string Notes { get; set; }
        public List<ToDoVisit> ToDoVisits { get; set; }
        public string Image {  get; set; }
        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
