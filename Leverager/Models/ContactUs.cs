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
    public class ContactUs
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The First Name cannot be longer 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The Last Name cannot be longer 50 characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Email cannot be longer 256 characters")]
        public string Email { get; set; }
        [StringLength(20, ErrorMessage = "The Phone Number cannot be longer 256 characters")]
        public string Phone { get; set; }
        [Required]
        [StringLength(4096)]
        public string Message { get; set; }
    }
}
