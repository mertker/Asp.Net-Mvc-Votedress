using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class SocialShareManager
    {

        private GenericUnitOfWork unitOfWork = null;

        public SocialShareManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }


        public List<SocialShare> UrunPaylasimlariniGetir(Guid UrunId)
        {
            return unitOfWork.Repository<SocialShare>().List(x=>x.Product.id==UrunId);
        }


    }
}
