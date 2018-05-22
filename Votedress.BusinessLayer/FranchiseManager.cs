using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class FranchiseManager
    {
        private GenericUnitOfWork unitOfWork = null;

        public FranchiseManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }

        public List<Franchise> FranchiseleriGetir()
        {
            return unitOfWork.Repository<Franchise>().List().ToList();
        }
    }
}
