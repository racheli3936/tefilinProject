using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class DedicationDto
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public string Name { get; set; }
        public EGender Gender { get; set; }
        public string ParentName { get; set; }
        public DedicationKindDto DedicationKind { get; set; }
    }
}
