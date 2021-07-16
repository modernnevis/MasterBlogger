using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application.Article
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _articleValidatorService;
        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService)
        {
            this._articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            var article = new Domain.ArticleAgg.Article(command.Title, command.ShortDescription, command.Content,
                command.Image, command.ArticleCategoryId, _articleValidatorService);
            _articleRepository.CreateAndSave(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Content,
                command.Image, command.ArticleCategoryId, _articleValidatorService);
            _articleRepository.SaveChanges();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Content = article.Content,
                Image = article.Image,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public void Remove(long id)
        {
            var article = _articleRepository.Get(id);
            article.Delete();
            _articleRepository.SaveChanges();

        }

        public void Activate(long id)
        {
            var article = _articleRepository.Get(id);
            article.Restore();
            _articleRepository.SaveChanges();
        }
    }
}
