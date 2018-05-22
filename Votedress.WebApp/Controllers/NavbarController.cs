using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Votedress.BusinessLayer;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim;
using Votedress.WebApp.App_Start;

namespace Votedress.WebApp.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        [LoginFilter]
        public ActionResult KısaYollar()
        {
            VotedressUser kullanici = Session["login"] as VotedressUser;

            KısaYollarViewModel view_model = new KısaYollarViewModel();
            PrivateMessageManager privatemessage_manager = new PrivateMessageManager();
            view_model.GorulmemisMesajlar = privatemessage_manager.GorulmemisMesajlariGetir(kullanici.id).Select(x => new PrivateMessage_sade() {

                userId=x.User.id,
                adSoyad = x.User.UserDetail.Name + " " + x.User.UserDetail.SurName,
                GonderilmeTarihi = x.GöndermeTarihi.ToString(),
                Message=x.Message,
                ProfilImage=x.User.ProfileImage,
                Sahip = (x.User.id == kullanici.id) ? true : false

            }).ToList();


            BahsedilenManager bahsedilenManager = new BahsedilenManager();
            List<Bahsedilen_sade> bahsedenler = bahsedilenManager.BahsedenleriGetir(kullanici.id);
            view_model.Bahsedenler = bahsedenler;


            FriendManager friendManager = new FriendManager();
            List<Friend> arkadaslikIstekleri = friendManager.ArkadaslikIsteklerimiGetir(kullanici.id);
            view_model.ArkadaslikIsteklerim = arkadaslikIstekleri.Select(x => new Friend_sade()
            {
                UserId=x.User.id,
                UserNameSurname=x.User.UserDetail.Name+" "+ x.User.UserDetail.SurName,
                UserProfileImage=x.User.ProfileImage,
                Tarih=x.ArkadaslikTarihi,

            }).ToList();

            CartManager cartManager = new CartManager();

            Cart carts = cartManager.SepetimiGetir(kullanici.id);
            if(carts!=null)
            {
                List<Cart_sade> cart_Sades = carts.CartDetail.Select(x => new Cart_sade()
                {

                    id = x.id,
                    Count = x.ProductCount,
                    ProductId = x.Product.id,
                    ProductName = x.Product.ProductName,
                    ProductImage = x.Product.ProductImage,
                    ProductPrice = x.Product.Price,
                    ProductColorId = x.ProductColorId,
                    Size = x.Size


                }).ToList();
                view_model.Cart_Sades = cart_Sades;
            }
         

            return View(view_model);
        }
    }
}