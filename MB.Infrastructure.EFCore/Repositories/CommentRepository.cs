using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using _01_FrameWork.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : BaseRepository<long,Comment> , ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Message = x.Message,
                Name = x.Name,
                Email = x.Email,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title
            }).ToList();

        }
        //public void CreateAndSave(Comment entity)
        //{
        //    _context.Comments.Add(entity);
        //    Save();
        //}
        //public Comment Get(long id)
        //{
        //    return _context.Comments.FirstOrDefault(x => x.Id == id);
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

       
    }
}
