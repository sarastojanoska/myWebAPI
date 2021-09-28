﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Entities
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int Ocenka { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
