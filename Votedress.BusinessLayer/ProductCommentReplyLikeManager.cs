using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class ProductCommentReplyLikeManager
    {
        private GenericUnitOfWork unitOfWork = null;

        public ProductCommentReplyLikeManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }

        public ProductCommentReplyLike UrunYorumCevabinaBegeniEkle(Guid kullanici_id, int yorumId)
        {
            ProductCommentReplyLike begenmismiyim = unitOfWork.Repository<ProductCommentReplyLike>().Find(x => x.VotedressUser.id == kullanici_id && x.ProductCommentReply.id == yorumId);

            if (begenmismiyim == null)
            {
                ProductCommentReplyLike productCommentReplyLike = new ProductCommentReplyLike()
                {
                    LikeDate = DateTime.Now,
                    ProductCommentReply = unitOfWork.Repository<ProductCommentReply>().Find(x => x.id == yorumId),
                    VotedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici_id)

                };

                ProductCommentReplyLike productCommentReplyLikeReturn = unitOfWork.Repository<ProductCommentReplyLike>().Insert(productCommentReplyLike);
                unitOfWork.SaveChanges();

                return productCommentReplyLikeReturn;
            }

            return null;
        }

        public bool UrunAnaYorumCevapBegeniSil(Guid kullaniciId,int yorumId)
        {

            ProductCommentReplyLike like = unitOfWork.Repository<ProductCommentReplyLike>().Find(x => x.VotedressUser.id == kullaniciId && x.ProductCommentReply.id == yorumId);
            if (like != null)
            {
                unitOfWork.Repository<ProductCommentReplyLike>().Delete(like);
                unitOfWork.SaveChanges();

                return true;
            }
            return false;
        }

    }
}
