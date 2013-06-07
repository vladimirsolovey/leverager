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
    [Table("SuggestProduct")]
    public class SuggestProduct
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name="Product Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Product SKU")]
        [StringLength(128)]
        public string SKU { get; set; }

        [Display(Name = "Product URL")]
        [StringLength(128)]
        public string URL { get; set; }

        [Display(Name = "Comment")]
        [StringLength(128)]
        public string Comment { get; set; }

        public int StatusId { get; set; }
        [Display(Name="Status")]
        public virtual Status Status { get; set; }
    }
}