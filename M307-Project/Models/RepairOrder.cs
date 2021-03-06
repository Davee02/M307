﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [RegularExpression(@"^[\d\s\-\+\(\)\/]*$", ErrorMessage = "The phone-number can only contain numbers, whitespaces and the characters +-/()")]
        [StringLength(200)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Severity")]
        public Enums.Severety Severety { get; set; }

        public Tool Tool { get; set; }

        [Required]
        [DisplayName("Tool")]
        public int ToolId { get; set; }

        [Required]
        [DisplayName("Repair status")]
        public Enums.RepairState RepairState { get; set; }

        [Required]
        public DateTime RepairStartDateTime { get; set; }

    }
}