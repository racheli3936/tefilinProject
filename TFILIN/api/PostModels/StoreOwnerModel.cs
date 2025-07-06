using core.Models;
using System.ComponentModel.DataAnnotations;

namespace api.PostModels
{
    public class StoreOwnerModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
