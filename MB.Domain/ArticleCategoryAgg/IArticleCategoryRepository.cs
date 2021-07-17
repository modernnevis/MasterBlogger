using System;
using System.Collections.Generic;
using System.Text;
using _01_FrameWork.Infrastructure;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
        //List<> GetList();ArticleCategory
        //void Add(ArticleCategory entity);
        //ArticleCategory Get(long id);
        //void Save();
        //bool Exist(string name);
    }
}
