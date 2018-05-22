using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Votedress.BusinessLayer;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim;
using Votedress.WebApp.App_Start;

namespace Votedress.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        public ActionResult Index(string sekme)
        {

            if(sekme==null || sekme=="")
            {
                sekme = "anasayfa";
            }

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            VotedressUserManager votedressUserManager = new VotedressUserManager();

            VotedressUser votedressUser = votedressUserManager.KullaniciGetir(user.id);

            var JsonModel = new
            {
                myId = votedressUser.id,
                myFullName = votedressUser.UserDetail.Name + " " + user.UserDetail.SurName,
                myProfileImage = votedressUser.ProfileImage,
                myCollectionCount = votedressUser.Collections.Count,
                myVoteCount = votedressUser.Votes.Count,
                myVotedCount = votedressUser.MyVoteds.Count,
                sekme=sekme
            };

            return View(JsonModel);
        }

        [HttpGet]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult ArkadaslariGetir()
        {

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            VotedressUser votedressUser = new VotedressUser();
            VotedressUserManager votedressUserManager = new VotedressUserManager();

            votedressUser = votedressUserManager.KullaniciGetir(user.id);


            var JsonModel = new
            {

                friends = votedressUser.Friends.Where(x => x.Durum == true).Select(x => new
                {
                    friendId = x.MyFriend.id,
                    friendFullName = x.MyFriend.UserDetail.Name + " " + x.MyFriend.UserDetail.SurName,
                    friendProfileImage = x.MyFriend.ProfileImage,
                    friendDate = x.ArkadaslikTarihi,
                    friendCount = x.MyFriend.Friends.Count()
                })
            };

            string viewContent = ConvertViewToString("Arkadaslar", JsonModel);



            return Json(new { PartialView = viewContent }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult ArkadasSil(Guid SilinecekArkadasId)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            FriendManager friendManager = new FriendManager();

            friendManager.DeleteFriend(user.id, SilinecekArkadasId);


            return Json(new { IsSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult ArkadasEkle(Guid userId)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            FriendManager friendManager = new FriendManager();

            friendManager.AddFriend(user.id, userId);


            return Json(new { IsSuccess = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult ArkadaslikIstegiKabulEt(Guid userId)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            FriendManager friendManager = new FriendManager();

            friendManager.AcceptFriendRequest(user.id, userId);


            return Json(new { IsSuccess = true }, JsonRequestBehavior.AllowGet);
        }


        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        public ActionResult Oylamalarim()
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            OylamaManager oylamaManager = new OylamaManager();
            OylamalarimViewModel oylamalarimViewModel = new OylamalarimViewModel();
            oylamalarimViewModel = oylamaManager.OylamalarimSayfasi(user.id);

            return View(oylamalarimViewModel);
        }


        [HttpGet]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult SepetimiGetir()
        {

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            VotedressUser votedressUser = new VotedressUser();
            VotedressUserManager votedressUserManager = new VotedressUserManager();

            votedressUser = votedressUserManager.KullaniciGetir(user.id);

            CartManager cartManager = new CartManager();
            Cart myCart = cartManager.SepetimiGetir(user.id);

            string viewContent;


            if (myCart!=null)
            {

                var JsonModel = new
                {

                    carts = myCart.CartDetail.Select(x => new
                    {
                        id = x.id,
                        ProductId = x.Product.id,
                        ProductName = x.Product.ProductName,
                        ProductImage = x.Product.ProductImage,
                        ProductPrice = x.Product.Price,
                        Count = x.ProductCount,
                        ProductColor = x.ProductColor.ProductColorDetail.Select(k => new
                        {
                            colorName = k.Color.ColorName,
                            colorCode = k.Color.ColorCode
                        }),
                        Size = x.Size
                    })
                };

                viewContent = ConvertViewToString("Sepet", JsonModel);

                return Json(new { PartialView = viewContent }, JsonRequestBehavior.AllowGet);
            }

            viewContent = ConvertViewToString("Sepet", null);

            return Json(new { PartialView = viewContent }, JsonRequestBehavior.AllowGet);


        }


        [HttpGet]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult SiparislerimiGetir()
        {

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            OrderManager orderManager = new OrderManager();
            List<Order> orders = orderManager.BireyselSiparisleriGetir(user.id);


            //var JsonModel = new
            //{
            //    orders=orders.Select(x=>new {

            //        id=x.id,
            //        orderDate=x.OrderDate,
            //        orderStatus=x.Status,
            //        orderDetails=x.OrderDetails.Select(y=>new {

            //            id=y.id,
            //            Product= new
            //            {
            //                productId=y.Product.id,
            //                productName=y.Product.ProductName,
            //                productPrice=y.Product.Price,
            //                productCompanyName = y.Product.User.UserDetail.CompanyName,
            //                productImage=y.Product.ProductImage,
            //                productCount = y.ProductCount,
            //                productSize = y.Size,
            //                color = y.ProductColor.ProductColorDetail.Select(k => new
            //                {
            //                    colorName = k.Color.ColorName,
            //                    colorCode = k.Color.ColorCode
            //                }),
            //            },


            //        }),              
            //    })

            //};
            //@Model[i].adress_Sade.AdressTitle < br /> @Model[i].adress_Sade.Adress.Substring(0, 10)...< br /> @Model[i].adress_Sade.NeighborhoodName @Model[i].adress_Sade.CountyName / @Model[i].adress_Sade.CityName

            List<Order_sade> order_Sades = orders.Select(x => new Order_sade()
            {
                id = x.id,
                orderDate = x.OrderDate,
                orderStatus = x.Status,
                orderDetails=x.OrderDetails.Select(y=>new orderDetail_sade() {

                    id=y.id,
                    productId = y.Product.id,
                    productName = y.Product.ProductName,
                    productPrice = y.Product.Price,
                    productCompanyName = y.Product.User.UserDetail.CompanyName,
                    productImage = y.Product.ProductImage,
                    productCount = y.ProductCount,
                    productSize = y.Size,
                    colors=y.ProductColor.ProductColorDetail.Select(t=>t.Color).ToList()

                }).ToList(),
                adress_Sade=new Adress_sade() {
                    Adress= x.UserAdress.Adress,
                    Email=x.UserAdress.Email,
                    AdressTitle= x.UserAdress.AdressTitle,
                    CityName= x.UserAdress.City.CityName,
                    CountyName= x.UserAdress.County.CountyName,
                    Name= x.UserAdress.Name,
                    NeighborhoodName= x.UserAdress.Neighborhood.NeighborhoodName,
                    PhoneNumber= x.UserAdress.PhoneNumber,
                    SurName= x.UserAdress.SurName
                },
                toplamTutar= x.OrderDetails.Sum(z=>z.ProductCount*z.Product.Price)

            }).ToList();


            string viewContent = ConvertViewToString("Siparisler", order_Sades);



            return Json(new { PartialView = viewContent }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult SepetiGuncelle(int cartDetailId, int count)
        {

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            CartManager cartManager = new CartManager();
            CartDetail cartDetail = cartManager.SepetiGuncelle(user.id, cartDetailId, count);

            Cart_sade cart_Sade = new Cart_sade();

            if (cartDetail != null)
            {

                cart_Sade.id = cartDetail.id;
                cart_Sade.Count = cartDetail.ProductCount;
                cart_Sade.ProductId = cartDetail.Product.id;
                cart_Sade.ProductImage = cartDetail.Product.ProductImage;
                cart_Sade.ProductName = cartDetail.Product.ProductName;
                cart_Sade.ProductPrice = cartDetail.Product.Price;
                cart_Sade.Size = cartDetail.Size;
                cart_Sade.ProductColorId = cartDetail.ProductColorId;

            }

            return Json(cart_Sade, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Ayarlar()
        {

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            var JsonModel = new
            {


            };

            string viewContent = ConvertViewToString("Ayarlar", JsonModel);



            return Json(new { PartialView = viewContent }, JsonRequestBehavior.AllowGet);
        }


        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }

    }
}