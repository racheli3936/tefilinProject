using core.Models;

namespace api.PostModels
{
    public class StandPostModel
    {
        public int StandId { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }
        public int CountTefilin { get; set; }
        public bool IsThereLeftHanded { get; set; }
        public DateOnly LastCheckDate { get; set; }
        public int TefilinStatusId { get; set; }
    }
}
