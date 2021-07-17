using System.Collections.Generic;
using _01_FrameWork.Infrastructure;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        List<ArticleViewModel> GetList();
        //void CreateAndSave(Article entity);
        //Article Get(long id);
        //void SaveChanges();
        //bool Exist(string title);
    }
}
