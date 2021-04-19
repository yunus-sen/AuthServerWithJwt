using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsyn();
        void Commit();
    }
}
