using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Entities
{
    public class DTCTechnical
    {
        public string ReferenceNum { get; set; }
        [Required]
        public ICollection<DTCMovement> DTCMovements { get; set; }
        [Required]
        public int LanesCatalogId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DTCHeaderId { get; set; }
        [Required]
        [MaxLength(50)]
        public ICollection<SparePartsCatalog> SparePartsCatalogs { get; set; }
        
        [MaxLength(8)]
        public string AxaNum { get; set; }
        public int FailureNum { get; set; }
        [MaxLength(30)]
        public string Status { get; set; }
        public DateTime FailureDate { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ElaborationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        [MaxLength(30)]
        public string OpinionType { get; set; }
        public string Description { get; set; }
        [MaxLength(30)]
        public string Diagnostic { get; set; }
        public string Observation { get; set; }
        public string Image { get; set; }

        
    }
}
