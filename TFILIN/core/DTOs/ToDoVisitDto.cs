using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class ToDoVisitDto
    {
        public int Id { get; set; }
        public int ToDoId { get; set; }
        public int VisitId { get; set; }//אם זה תוצאה של ביקור
        public int StoreOwnerConversationId { get; set; }//אם זה תוצאה של שיחה 
        public string Description { get; set; }
        public string Source { get; set; }//אם צריך העברה של הסטנד או שצריך להביר חלקים ממנו  וכו
        public string Destination { get; set; }
    }
}
