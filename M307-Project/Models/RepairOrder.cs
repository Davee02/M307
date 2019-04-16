using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace M307_Project.Models
{
    public class RepairOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(200)]
        public string Lastname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(200)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public Enums.Severety Severety { get; set; }

        [Required]
        public Tool Tool { get; set; }

        [Required]
        [DisplayName("Repair status")]
        public Enums.RepairState RepairState { get; set; }

    }
}
