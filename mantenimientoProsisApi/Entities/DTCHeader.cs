using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Entities
{
    public class DTCHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AgreementNum { get; set; }
        [Required]
        [MaxLength(20)]
        public string ManagerName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Position { get; set; }

        public DTCTechnical DTCTechnician { get; set; }
    }
}
