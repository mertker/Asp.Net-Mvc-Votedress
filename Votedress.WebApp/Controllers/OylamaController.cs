using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Votedress.BusinessLayer;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.WebApp.App_Start;

namespace Votedress.WebApp.Controllers
{
    public class OylamaController : Controller
    {
        // GET: Oylama
        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        public ActionResult Index()
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            OylamaManager vote_manager = new OylamaManager();
            Vote_sade oylama = vote_manager.OylamaGetirOylamakIcin(user.id);

            if (oylama != null)
            {
                InVoteChatManager invoteChatManager = new InVoteChatManager();
                if (invoteChatManager.Chattemiyim(user.id, oylama.id) == null)
                {
                    VotedressUserDetailManager userdetail_Manager = new VotedressUserDetailManager();
                    UserDetail kullanici_detayi = new UserDetail();
                    kullanici_detayi = userdetail_Manager.GetUserDetail(user.id);
                    VotedressUser_sade sade_kullanici = new VotedressUser_sade()
                    {
                        id = kullanici_detayi.UserId,
                        SocialId = kullanici_detayi.User.SocialId,
                        SocialName = kullanici_detayi.User.SocialName,
                        Name = kullanici_detayi.Name,
                        SurName = kullanici_detayi.SurName,
                        Birthday = kullanici_detayi.Birthday,
                        Email = kullanici_detayi.User.Email,
                        ProfileImage = kullanici_detayi.User.ProfileImage,
                        Sex = kullanici_detayi.Sex,

                    };
                    InVoteChatManager repo_invotechatManager = new InVoteChatManager();
                    repo_invotechatManager.AddUserChat(user.id, oylama.id);
                }
            }
            else
            {
                return View(oylama);//Oylama yok sayfasına yönlerdircen 
            }
            return View(oylama);
        }
        [HttpGet]
        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]   
        public ActionResult OylamaBaslat()
        {
            return View();
        }


        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OylamaBaslat(string oylama_suresi, bool paylasima_acikmi, bool kimlik_durumu, string oylama_tipi, string urun_1, string urun_2, string urun_3, string urun_aciklamasi_1_1, string urun_aciklamasi_1_2, string urun_aciklamasi_1_3, string urun_aciklamasi_2_1, string urun_aciklamasi_2_2, string urun_aciklamasi_2_3, string urun_aciklamasi_3_1, string urun_aciklamasi_3_2, string urun_aciklamasi_3_3)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            OylamaManager oylama_manager = new OylamaManager();

            bool sonuc = oylama_manager.OylamaEkle(user.id, oylama_suresi, oylama_tipi, paylasima_acikmi, kimlik_durumu, Request.Files ,urun_1, urun_2, urun_3, urun_aciklamasi_1_1, urun_aciklamasi_1_2, urun_aciklamasi_1_3, urun_aciklamasi_2_1, urun_aciklamasi_2_2, urun_aciklamasi_2_3, urun_aciklamasi_3_1, urun_aciklamasi_3_2, urun_aciklamasi_3_3);


            if (sonuc == true)
            {
                return RedirectToAction("Oylamalarim","Profile");
            }

            return RedirectToAction("OylamaBaslatilamadi");

        }

        [LoginFilter]
        [BireyselUserFilter]
        [HttpPost]
        public JsonResult Oyla(int id)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            OylamaManager oylama_manager = new OylamaManager();

            bool sonuc = oylama_manager.Oyla(user, id);

            if (sonuc == true)
            {
                Vote_sade yeni_oylama = oylama_manager.OylamaGetirOylamakIcin(user.id);

                return Json(new { YeniOylama = yeni_oylama, IsSuccess = true, Message = "Oylama Başarılı" }, JsonRequestBehavior.AllowGet);

            }


            return Json(new { IsSuccess = false, Message = "Oylama Başarısız" }, JsonRequestBehavior.AllowGet);
        }

        [LoginFilter]
        [BireyselUserFilter]
        [HttpPost]
        public JsonResult OylamamiGetir(Guid oylamaId)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;


            OylamaManager oylamaManager = new OylamaManager();
            Vote_sade vote_Sade= oylamaManager.OylamaGetir(oylamaId,user.id);


            return Json(vote_Sade, JsonRequestBehavior.AllowGet);
        }


    }
}