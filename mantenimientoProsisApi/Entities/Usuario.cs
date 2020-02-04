using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(80)]
        public string UserName { get; set; }
        [MaxLength(120)]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<DTCTechnical> DTCTechnicians { get; set; }
    }
}
