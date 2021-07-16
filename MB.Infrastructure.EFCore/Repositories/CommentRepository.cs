using MB.Domain.CommentAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
