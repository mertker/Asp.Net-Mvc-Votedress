using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim;

namespace Votedress.BusinessLayer
{
    public class CartManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public CartManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }

        public List<Cart> urunleriminOlduguSepetler(Guid magazaId)
        {
            return unitOfWork.Repository<Cart>().List(x => x.CartDetail.Any(k => k.Product.User.id == magazaId));

        }

        public Cart SepetimiGetir(Guid id)
        {
            return unitOfWork.Repository<Cart>().Find(x => x.User.id == id);

        }

        public CartDetail SepeteUrunEkle(Guid userId, SepeteEkleViewModel sepeteEkle)
        {
            Cart cart = unitOfWork.Repository<Cart>().Find(x => x.User.id == userId);
            VotedressUser votedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == userId);
            Product product = unitOfWork.Repository<Product>().Find(x => x.id == sepeteEkle.productId);

            CartDetail cartDetail = null;

            if (cart != null)
            {
                bool varmi = false;

                if (cart.CartDetail == null)
                {
                    cartDetail = new CartDetail()
                    {
                        AddToCartDate = DateTime.Now,
                        Cart = cart,
                        Product = product,
                        ProductColorId = sepeteEkle.productColorId,
                        ProductCount = sepeteEkle.productCount,
                        Size = sepeteEkle.productSize
                    };

                    unitOfWork.Repository<CartDetail>().Insert(cartDetail);
                    unitOfWork.SaveChanges();
                }
                else
                {
                    for (int i = 0; i < cart.CartDetail.Count; i++)
                    {
                        if (cart.CartDetail[i].Product.id == sepeteEkle.productId && cart.CartDetail[i].ProductColorId == sepeteEkle.productColorId && cart.CartDetail[i].Size == sepeteEkle.productSize)
                        {
                            cart.CartDetail[i].ProductCount = cart.CartDetail[i].ProductCount + sepeteEkle.productCount;
                            varmi = true;
                            unitOfWork.SaveChanges();

                            cartDetail = cart.CartDetail[i];

                            break;
                        }
                    }

                    if (varmi == false)
                    {
                        cartDetail = new CartDetail()
                        {
                            AddToCartDate = DateTime.Now,
                            Cart = cart,
                            Product = product,
                            ProductColorId = sepeteEkle.productColorId,
                            ProductCount = sepeteEkle.productCount,
                            Size = sepeteEkle.productSize
                        };

                        unitOfWork.Repository<CartDetail>().Insert(cartDetail);
                        unitOfWork.SaveChanges();
                    }
                }
            }
            else
            {
                cart = new Cart()
                {
                    User = votedressUser,
                };

                cartDetail = new CartDetail()
                {
                    AddToCartDate = DateTime.Now,
                    Cart = cart,
                    Product = product,
                    ProductColorId = sepeteEkle.productColorId,
                    ProductCount = sepeteEkle.productCount,
                    Size = sepeteEkle.productSize
                };
                unitOfWork.Repository<Cart>().Insert(cart);
                cartDetail = unitOfWork.Repository<CartDetail>().Insert(cartDetail);
                unitOfWork.SaveChanges();


            }

            return cartDetail;

        }

        public CartDetail SepetiGuncelle(Guid userId, int cartDetailId, int count)
        {
            Cart cart = unitOfWork.Repository<Cart>().Find(x => x.User.id == userId);
            if (cart != null)
            {
                CartDetail guncellenen = cart.CartDetail.Where(x => x.id == cartDetailId).FirstOrDefault();
                if (guncellenen != null)
                {
                    guncellenen.ProductCount = count;

                    unitOfWork.Repository<CartDetail>().Update(guncellenen);
                    unitOfWork.SaveChanges();
                }
                return guncellenen;
            }

            return null;
        }

        public void SepettenSil(Guid userId, int sepetId)
        {
            CartDetail cartDetail = unitOfWork.Repository<CartDetail>().Find(x => x.Cart.User.id == userId && x.id == sepetId);
            if (cartDetail != null)
            {
                unitOfWork.Repository<CartDetail>().Delete(cartDetail);
                unitOfWork.SaveChanges();
            }


        }

        public void SepetiBosalt(Guid id)
        {
            Cart cart = unitOfWork.Repository<Cart>().Find(x=>x.User.id==id);


            foreach (var cartDetail in cart.CartDetail.ToList())
            {
                unitOfWork.Repository<CartDetail>().Delete(cartDetail);
            }

            unitOfWork.Repository<Cart>().Delete(cart);

            unitOfWork.SaveChanges();
        }
    }
}
