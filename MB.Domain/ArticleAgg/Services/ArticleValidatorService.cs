using System;
using System.Collections.Generic;
using System.Text;
using MB.Domain.ArticleAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        public void CheckThisRecordAlreadyExist(string title)
        {
            if (_articleRepository.Exist(title))
                throw new DuplicatedRecordException("this record is already exist!");
        }
    }
}
