using System.ComponentModel.DataAnnotations;

namespace api.PostModels
{
    public class ToDoVisitPostModel
    {
        public int ToDoId { get; set; }
        public int VisitId {  get; set; }
        public int StoreOwnerConversationId { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }//אם צריך העברה של הסטנד או שצריך להביר חלקים ממנו  וכו
        public string Destination { get; set; }
    }
}
