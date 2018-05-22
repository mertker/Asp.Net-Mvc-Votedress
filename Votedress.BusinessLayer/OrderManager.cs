using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.Modellerim.AdminSayfasiModellerim;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class OrderManager
    {
        private GenericUnitOfWork unitOfWork = null;

        public OrderManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }



        public List<Order> MagazaSiparisleriGetir(Guid magazaId)
        {

            return unitOfWork.Repository<Order>().List(x=>x.OrderDetails.Any(k=>k.Product.User.id==magazaId));
           
        }


        public List<Order> BireyselSiparisleriGetir(Guid userId)
        {

            return unitOfWork.Repository<Order>().List(x => x.User.id==userId);

        }


        public void AddOrder(Guid id,int adressId)
        {

            VotedressUser votedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == id);

            if(votedressUser!=null)
            {

                UserAdress userAdress = unitOfWork.Repository<UserAdress>().Find(x=>x.User.id==id && x.id==adressId);

                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    User=votedressUser,
                    UserAdress= userAdress,
                    Status="Onay Bekliyor"
                };

                unitOfWork.Repository<Order>().Insert(order);
                unitOfWork.SaveChanges();

                CartManager cartManager = new CartManager();
                Cart carts = unitOfWork.Repository<Cart>().Find(x => x.User.id == id);


                OrderDetail orderDetail;

                foreach (var cartDetail in carts.CartDetail)
                {
                    orderDetail = new OrderDetail()
                    {
                        Order = order,
                        Product = cartDetail.Product,
                        ProductColorId = cartDetail.ProductColorId,
                        ProductCount = cartDetail.ProductCount,
                        Size = cartDetail.Size,
                    };

                    unitOfWork.Repository<OrderDetail>().Insert(orderDetail);
                }
                unitOfWork.SaveChanges();

            }        

        }
    }
}
