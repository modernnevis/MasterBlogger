using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle Get(long id);
        void Remove(long id);
        void Activate(long id);
    }
}
