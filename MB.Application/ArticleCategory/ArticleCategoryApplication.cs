using System.Collections.Generic;
using System.Globalization;
using _01_FrameWork.Infrastructure;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application.ArticleCategory
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();

            var result = new List<ArticleCategoryViewModel>();

            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Name = articleCategory.Name,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }

            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Name, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            if(articleCategory == null)
                return;

            articleCategory.Rename(command.Name, _articleCategoryValidatorService);
            _unitOfWork.CommitTran();
            //_articleCategoryRepository.Save();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);

            return new RenameArticleCategory()
            {
                Id = articleCategory.Id,
                Name = articleCategory.Name
            };
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            if (articleCategory == null)
                return;

            articleCategory.Delete();
            _unitOfWork.CommitTran();
            // _articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            if (articleCategory == null)
                return;

            articleCategory.Restore();
            _unitOfWork.CommitTran();
            //_articleCategoryRepository.Save();
        }
    }
}
