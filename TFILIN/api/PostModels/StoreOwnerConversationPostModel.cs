using core.Models;
using System.ComponentModel.DataAnnotations;

namespace api.PostModels
{
    public class StoreOwnerConversationPostModel
    {
        public int StoreOwnerId { get; set; }
        public int StoreStandId { get; set; }
        public int UserId { get; set; }
        public DateTime ConversionDate { get; set; }
        public int statusCallId { get; set; }
        public string notes { get; set; }
     //   public List<ToDoVisitPostModel> toDoVisits { get; set; }
        public string image { get; set; }
    }
}
