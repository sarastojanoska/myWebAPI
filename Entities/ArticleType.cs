﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Entities
{
    public class ArticleType
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
