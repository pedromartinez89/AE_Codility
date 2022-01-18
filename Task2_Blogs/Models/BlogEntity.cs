using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Blogs.Models
{
    [Table("Blogs")]
    public class BlogEntity
    {

        [Key]
        [Required, Column("blog_id")]
        public int BlogId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name may not be longer than 50")]
        [MinLength(10, ErrorMessage = "Name may not be shorter than 10")]
        public string Name { get; set; }

        //private string _isActive;

        [Column("IsActive", TypeName = "nvarchar(50)"), Required]
        public bool IsActive { get; set; }
        //[Column("IsActive", TypeName = "nvarchar(50)"), Required]
        //public bool IsActive
        //{
        //    get
        //    {
        //        if (_isActive == "blog is active")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    set
        //    {
        //        if (value == true)
        //        {
        //            _isActive = "blog is active";
        //        }
        //        else
        //        {
        //            _isActive = "blog is not active";
        //        }
        //    }
        //}

        public List<PostEntity> Articles { get; set; }

    }
}
