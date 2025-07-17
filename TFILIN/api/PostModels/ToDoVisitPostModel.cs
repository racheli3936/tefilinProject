using System.ComponentModel.DataAnnotations;

namespace api.PostModels
{
    public class ToDoVisitPostModel
    {
        public int ToDoId { get; set; }
        public int? VisitId { get; set; } = null;
        public int? StoreOwnerConversationId { get; set; } = null;
        public string? Description { get; set; } = null;
        public string? Source { get; set; } = null;//אם צריך העברה של הסטנד או שצריך להביר חלקים ממנו  וכו
        public string? Destination { get; set; } = null;
    }
}
