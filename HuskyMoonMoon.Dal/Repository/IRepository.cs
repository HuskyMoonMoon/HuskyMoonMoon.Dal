using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuskyMoonMoon.Dal.UnitOfWork;

namespace HuskyMoonMoon.Dal.Repository
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
