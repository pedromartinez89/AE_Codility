using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Blogs.Models
{
    [Table("Articles")]
    public class PostEntity
    {
        [Key, Column("post_id")]
        public int PostId { get; set; }
       

        [Required]
        [MaxLength(50, ErrorMessage = "Name may not be longer than 50")]
        [MinLength(10,ErrorMessage = "Name may not be shorter than 10")]
        public string Name { get; set; }
        //[StringLength(1000)]
        [StringLength(1000), Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }        
        
        [ForeignKey("blog_id")]
        [Column("blog_id")]
        public int ParentId { get; set; }

    }
}
