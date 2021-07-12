using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetList();
        void Add(ArticleCategory entity);
        ArticleCategory Get(long id);
        void Save();
        bool Exist(string name);
    }
}
