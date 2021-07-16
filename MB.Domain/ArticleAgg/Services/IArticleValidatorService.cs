using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void CheckThisRecordAlreadyExist(string title);
    }
}
