using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PublishYear { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("TypeId")]
        public virtual ArticleType ArticleType { get; set; }
        public int TypeId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}
