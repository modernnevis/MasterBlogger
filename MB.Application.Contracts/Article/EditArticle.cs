using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.Contracts.Article
{
    public class EditArticle : CreateArticle
    {
        public long Id { get; set; }
    }
}
