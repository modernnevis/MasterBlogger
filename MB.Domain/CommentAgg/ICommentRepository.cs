using System.Collections.Generic;
using _01_FrameWork.Infrastructure;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long , Comment>
    {
        //void CreateAndSave(Comment entity);
        List<CommentViewModel> GetList();
        //Comment Get(long id);
        //void Save();
    }
}
