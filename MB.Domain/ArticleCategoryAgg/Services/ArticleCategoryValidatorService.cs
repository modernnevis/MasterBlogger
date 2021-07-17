using System;
using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            this._articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThisRecordAlreadyExist(string name)
        {
            if(_articleCategoryRepository.Exists(x=>x.Name==name))
                throw new DuplicatedRecordException("this record is already exist!");
        }
    }
}