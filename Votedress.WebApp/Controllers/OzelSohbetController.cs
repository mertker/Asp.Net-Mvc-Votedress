using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Votedress.BusinessLayer;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.Entities.Modellerim.BusinessLayerResult;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim;
using Votedress.WebApp.App_Start;

namespace Votedress.WebApp.Controllers
{
    public class OzelSohbetController : Controller
    {
        // GET: OzelSohbet
        public ActionResult Sohbet()
        {

            VotedressUser kullanici = Session["login"] as VotedressUser;

            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<Messanger>();
            //hubContext.Clients.All.Hello();

            SohbetViewModel sohbetViewModel = new SohbetViewModel();

            FriendManager friend_manager = new FriendManager();

            List<OnOffArkadaslar> onoff_arkadaslar = friend_manager.OnOffArkadaslar(kullanici.id);

            WhisperManager whisperManager = new WhisperManager();
            List<Whisper_sade> whispers = whisperManager.GetWhispers(kullanici.id);

            sohbetViewModel.onOffArkadaslar = onoff_arkadaslar;
            sohbetViewModel.whisper_Sades = whispers;


            return View(sohbetViewModel);
        }
        [HttpPost]
        public JsonResult MesajlariGetir(Guid alanId)
        {
            VotedressUser kullanici = Session["login"] as VotedressUser;
            PrivateMessageManager res = new PrivateMessageManager();

            List<PrivateMessage> ozel_mesajlar = res.MesajlariGetir(kullanici.id, alanId);

            List<PrivateMessage_sade> sade_mesajlar = ozel_mesajlar.Select(x => new PrivateMessage_sade()
            {
                adSoyad = x.User.UserDetail.Name + " " + x.User.UserDetail.SurName,
                GonderilmeTarihi = x.GöndermeTarihi.ToString(),
                Message = x.Message,
                ProfilImage = x.User.ProfileImage,
                Sahip = (x.User.id == kullanici.id) ? true : false

            }).ToList();

            bool basarili = res.MesajlarGoruldu(kullanici.id, alanId);



            return Json(sade_mesajlar, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult WhisperEkle(Guid alanId)
        {
            VotedressUser kullanici = Session["login"] as VotedressUser;
            PrivateMessageManager res = new PrivateMessageManager();

            FriendManager friendManager = new FriendManager();
            Friend friend= friendManager.ArkadasKontrol(kullanici.id, alanId);

            if(friend==null)
            {
                WhisperManager whisperManager = new WhisperManager();
                whisperManager.AddWhisper(kullanici.id, alanId);

            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult FisiltiSil(Guid fisiltiSahibiId)
        {
            VotedressUser kullanici = Session["login"] as VotedressUser;

            WhisperManager whisperManager = new WhisperManager();
            whisperManager.HideWhisper(kullanici.id, fisiltiSahibiId);

            return Json(true,JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult FisiltiyiAktiflestir(Guid fisiltiSahibiId)
        {
            VotedressUser kullanici = Session["login"] as VotedressUser;

            WhisperManager whisperManager = new WhisperManager();
            whisperManager.ActivedWhisper(kullanici.id, fisiltiSahibiId);

            return Json(true, JsonRequestBehavior.AllowGet);

        }

        

        [HttpPost]
        public JsonResult KullaniciEngelle(Guid engellenenKullaniciId)
        {
            VotedressUser kullanici = Session["login"] as VotedressUser;

            BlockedUserManager blockedUserManager = new BlockedUserManager();
            blockedUserManager.Engelle(kullanici.id, engellenenKullaniciId);

            return Json(kullanici.id, JsonRequestBehavior.AllowGet);

        }

        


        [LoginFilter]
        public JavaScriptResult signalr_js()
        {
            VotedressUser kullanici = Session["login"] as VotedressUser;
            string js = "var kullanici_id = \"" + kullanici.id + "\"; $(function(){var chat = $.connection.messanger;$.connection.hub.start().done(function(){ chat.server.onlineOl(kullanici_id);$('#ozelMesaj_gonder').click(function(){var e=$('#ozelMesaj_gonder').attr('data-id'),a=$('#ozelMesaj_input').val();chat.server.ozel_sendMessage(\"" + kullanici.id + "\",e,a),$('#ozelMesaj_input').val(''); $('#ozelMesaj_input').focus(); var oylamaScroll = $('#messageArea');var scrollPosition = oylamaScroll.scrollTop(); var scrollTo_int = oylamaScroll.prop('scrollHeight');console.log(scrollTo_int - scrollPosition);if (scrollTo_int-scrollPosition <= 795){}   }); $('#ozelMesaj_input').keypress(function(d){if(13==d.which){var e=$('#ozelMesaj_gonder').attr('data-id'),f=$('#ozelMesaj_input').val();chat.server.ozel_sendMessage(kullanici_id,e,f),$('#ozelMesaj_input').val('')}}); }); });";
            return JavaScript(js);
        }
    }
}