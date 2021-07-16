using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article entity);
        Article Get(long id);
        void SaveChanges();
        bool Exist(string title);
    }
}
