using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public enum EGender { Male, Female };
     public class Dedication
    {
        [Key]
        public int Id { get; set; }
        public int DonationId {  get; set; }
        public string Name { get; set; }
        public EGender Gender { get; set; }
        public string ParentName { get; set; }
        public DedicationKind DedicationKind { get; set; }

        //___________________________________
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
