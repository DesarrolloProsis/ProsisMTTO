using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Entities
{
    public class SquaresCatalog
    {
        [Key]
        public int SquareNum { get; set; }
        [MaxLength(20)]
        [Required]
        public string SquareName { get; set; }
        [MaxLength(20)]
        [Required]
        public string Delegation { get; set; }

        public List<LanesCatalog> LanesCatalog { get; set; }
    }
}
