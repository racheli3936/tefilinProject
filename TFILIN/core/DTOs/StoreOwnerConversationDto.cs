using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class StoreOwnerConversationDto
    {
        public int Id { get; set; }
        public int StoreOwnerId { get; set; }
        public int StoreStandId { get; set; }
        public int UserId { get; set; }
        public DateTime ConversationDate { get; set; }
        public StatusCallDto StatusCall { get; set; }
        public string Notes { get; set; }
        public List<ToDoVisitDto> ToDoVisits { get; set; }
        public string Image { get; set; }
    }
}
