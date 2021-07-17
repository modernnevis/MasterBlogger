using System;
using System.Collections.Generic;
using System.Text;
using _01_FrameWork.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application.Article
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _articleValidatorService;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService, IUnitOfWork unitOfWork)
        {
            this._articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
            _unitOfWork = unitOfWork;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Domain.ArticleAgg.Article(command.Title, command.ShortDescription, command.Content,
                command.Image, command.ArticleCategoryId, _articleValidatorService);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Content,
                command.Image, command.ArticleCategoryId, _articleValidatorService);
            _unitOfWork.CommitTran();
            // _articleRepository.SaveChanges();
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
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Delete();
            _unitOfWork.CommitTran();
            // _articleRepository.SaveChanges();

        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Restore();
            _unitOfWork.CommitTran();
            //_articleRepository.SaveChanges();
        }
    }
}
