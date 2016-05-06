using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoloProject.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


        public Post(string content, int id = 0)
        {
            Content = content;
        }

        public Post() { }
    }
}
