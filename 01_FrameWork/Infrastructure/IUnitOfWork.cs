using System;
using System.Collections.Generic;
using System.Text;

namespace _01_FrameWork.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollTran();
    }
}
