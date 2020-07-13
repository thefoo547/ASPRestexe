using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIexe.Model
{
    public class Comment
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string creator { get; set; }
        [Required]
        public string text { get; set; }
    }
}
