using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;
using _01_FrameWork.Infrastructure;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
        {
            this._context = context;
        }

        //public List<ArticleCategory> GetList()
        //{
        //    return _context.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
        //}

        //public void Add(ArticleCategory entity)
        //{
        //    _context.ArticleCategories.Add(entity);
        //    Save();
        //}

        //public ArticleCategory Get(long id)
        //{
        //    return _context.ArticleCategories.FirstOrDefault(x => x.Id==id);
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
        
        //public bool Exist(string name)
        //{
        //    return _context.ArticleCategories.Any(x => x.Name == name);
        //}
    }
}
