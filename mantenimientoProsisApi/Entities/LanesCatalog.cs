using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Entities
{
    public class LanesCatalog
    {
        [Key]
        public int CapufeLaneNum { get; set; }
        [MaxLength(4)]
        [Required]
        public string Lane { get; set; }
        [MaxLength(15)]
        [Required]
        public string LaneType { get; set; }
        public int SquareCatalogId { get; set; }

        public DTCTechnical DTCTechnician { get; set; }
    }
}
