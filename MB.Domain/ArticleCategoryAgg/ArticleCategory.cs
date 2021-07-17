using System;
using System.Collections.Generic;
using _01_FrameWork.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : DomainBase<long>
    {
        // public long Id { get;private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }
        // public DateTime CreationDate { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        public ArticleCategory(string name, IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyName(name);
            validatorService.CheckThisRecordAlreadyExist(name);
            Name = name;
            IsDeleted = false;
          //  CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }
        protected ArticleCategory()
        {
        }

        public void Rename(string name,IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyName(name);
            validatorService.CheckThisRecordAlreadyExist(name);
            Name = name;
        }

        public void GuardAgainstEmptyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
       
    }
}
