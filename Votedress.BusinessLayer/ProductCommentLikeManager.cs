using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class ProductCommentLikeManager
    {
        private GenericUnitOfWork unitOfWork =null;

        public ProductCommentLikeManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }

        public ProductCommentLike UrunAnaYorumaBegeniEkle(Guid kullaniciId,int yorumId)
        {

            ProductCommentLike oncedenBegenmismiyim= unitOfWork.Repository<ProductCommentLike>().Find(x => x.VotedressUser.id == kullaniciId && x.ProductComment.id == yorumId);

            if (oncedenBegenmismiyim == null)
            {
                ProductCommentLike productCommentLike = new ProductCommentLike()
                {
                    LikeDate = DateTime.Now,
                    ProductComment = unitOfWork.Repository<ProductComment>().Find(x => x.id == yorumId),
                    VotedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullaniciId)
                };

                ProductCommentLike like = unitOfWork.Repository<ProductCommentLike>().Insert(productCommentLike);
                unitOfWork.SaveChanges();

                return like;
            }

            return null;
        }



        public bool UrunAnaYorumaBegeniSil(Guid kullaniciId,int yorumId)
        {

            ProductCommentLike like= unitOfWork.Repository<ProductCommentLike>().Find(x => x.VotedressUser.id==kullaniciId && x.ProductComment.id==yorumId);
            if(like!=null)
            {
                unitOfWork.Repository<ProductCommentLike>().Delete(like);
                unitOfWork.SaveChanges();

                return true;
            }
            return false;
        }
        

    }
}
