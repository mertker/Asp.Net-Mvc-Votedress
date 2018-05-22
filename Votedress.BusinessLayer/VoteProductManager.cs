using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.DataAccessLayer;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class VoteProductManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public VoteProductManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public void OylamaUrunuEkle(Vote vote,string urun_id)
       {          
            ProductManager product_manager = new ProductManager();
            VoteProduct voteProduct = new VoteProduct();

            Guid urun_guid = new Guid(urun_id);
            voteProduct.Product = product_manager.UrunGetir(urun_guid);
            voteProduct.Vote = vote;

            unitOfWork.Repository<VoteProduct>().Insert(voteProduct);
            unitOfWork.SaveChanges();
        }

    }
}
