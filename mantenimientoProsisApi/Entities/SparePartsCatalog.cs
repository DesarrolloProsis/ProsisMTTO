using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Entities
{
    public class SparePartsCatalog
    {
        [Key]
        [MaxLength(50)]
        public string NumPart { get; set; }
        [Required]
        [MaxLength(25)]
        public string TypeService { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string Brand { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Unit { get; set; }
        [Required]
        [MaxLength(5)]
        public string PieceYear { get; set; }
        public string SparePartImage { get; set; }
        public string Description { get; set; }

        public DTCTechnical DTCTecnico { get; set; }
    }
}
