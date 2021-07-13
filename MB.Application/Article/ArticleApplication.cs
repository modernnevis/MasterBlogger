using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application.Article
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}
