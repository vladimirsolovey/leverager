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

    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(128, ErrorMessage="The Category Name cannot be longer 128 characters")]
        public string Name { get; set; }
        public bool Root { get; set; }
        //----------------------------------
        public virtual ICollection<Category> Children {get; set; }
        public virtual ICollection<Category> Parents { get; set; }

        public bool HasParents()
        {
            if ((Parents == null) || (Parents.Count == 0)) return false;
            else return true;
        }

        public bool HasChildren()
        {
            if ((Children == null) || (Children.Count == 0)) return false;
            else return true;
        }
    }
}
