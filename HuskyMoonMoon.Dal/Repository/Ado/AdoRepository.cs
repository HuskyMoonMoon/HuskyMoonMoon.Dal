using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuskyMoonMoon.Dal.UnitOfWork;

namespace HuskyMoonMoon.Dal.Repository.Ado
{
    /// <summary>
    /// Provide base implementation of ADO.NET based repository
    /// </summary>
    public abstract class AdoRepository: IRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        public AdoRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            if (UnitOfWork == null)
            {
                throw new NotSupportedException(nameof(unitOfWork) + "must be an instance of BaseAdoUnitOfWork");
            }
        }
    }
}
