using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;


namespace Leverager.Models
{
    public class FAQ
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "The question cannot be longer 256 characters")]
        public string Question { get; set; }
        [StringLength(4096)]
        public string Answer { get; set; }
    }
}