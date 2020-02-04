using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Entities
{
    public class DTCMovement
    {
        [Key]
        public int MovementId { get; set; }
        [MaxLength(10)]
        public string DTCTechnicianId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }

        public DTCTechnical DTCTechnician { get; set; }
    }
}
