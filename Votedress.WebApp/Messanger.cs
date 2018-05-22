using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Votedress.BusinessLayer;
using Votedress.Entities.VeritabaniModellerim;
using System.Threading;
using Votedress.Entities.SadeModeller;
using System.Threading.Tasks;

namespace Votedress.WebApp
{
    public class Messanger : Hub
    {
        public void OnlineOl(Guid kullanici_id)
        {
            MessangerManager messangerManager = new MessangerManager();

            int online_olundumu = messangerManager.OnlineOl(Context.ConnectionId, kullanici_id);

            if (online_olundumu == -1)
            {
                Clients.Client(Context.ConnectionId).OnlineOlunamadi();
            }
            else if (online_olundumu == 0)
            {


                Clients.Client(Context.ConnectionId).OnlineOlundu();
                List<OnlineUser> online_arkadaslar = messangerManager.OnlineArkadaslar(kullanici_id);

                if (online_arkadaslar != null)
                {
                    for (int i = 0; i < online_arkadaslar.Count; i++)
                    {
                        Clients.Client(online_arkadaslar[i].ConnectionId).BirisiOnlineOldu(kullanici_id);
                    }
                }
            }
            else
            {

                Clients.Client(Context.ConnectionId).ZatenOnlineydiniz();
            }


            VotedressUserManager votedressUserManager = new VotedressUserManager();
            ControllerLoglamaManager controllerLoglamaManager = new ControllerLoglamaManager();
            ControllerLoglama log = controllerLoglamaManager.LoglamaGetir(kullanici_id);

            if (log.Buraya == "Gardrop/Magaza" && log.Burdan != "Gardrop/Magaza")
            {
                votedressUserManager.MagazadakilerinSayisiniArttir(log.parameter);

                Groups.Remove(Context.ConnectionId, "Gardrop");
                Clients.OthersInGroup("Gardrop").BiriMagazayaGirdi(log.parameter);
            }

        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            MessangerManager messangerManager = new MessangerManager();
            Guid bosGuid = Guid.Empty;

            Guid kullanici_id = messangerManager.fakeOfflineOl(Context.ConnectionId);
            if (kullanici_id != bosGuid)
            {
                ControllerLoglamaManager controllerLoglamaManager = new ControllerLoglamaManager();
                ControllerLoglama log = controllerLoglamaManager.LoglamaGetir(kullanici_id);

                Thread.Sleep(8000);

                MessangerManager messangerManager2 = new MessangerManager();
                OnlineUser kullanici = messangerManager2.OnlineMi(kullanici_id);

                VotedressUserManager votedressUserManager = new VotedressUserManager();

                if (kullanici != null && kullanici.Disconnected == "reflesh")
                {
                    if ((log.Burdan == "Gardrop/Magaza" && log.Buraya == "Gardrop/Magaza") || (log.Burdan == "Gardrop/UrunDetayliIncele" && log.Buraya == "Gardrop/UrunDetayliIncele"))
                    {
                        //Demekki magazada reflesh olmuş birşey yapma
                    }
                    else if ((log.Burdan == "Gardrop/Magaza" && log.Buraya != "Gardrop/UrunDetayliIncele") || (log.Burdan == "Gardrop/UrunDetayliIncele" && log.Buraya != "Gardrop/Magaza"))//magazadan başka bir yere gidilmiş demekki magazadan çıkılmıs 
                    {
                        Groups.Remove(Context.ConnectionId, "Gardrop");
                        votedressUserManager.MagazadakilerinSayisiniAzalt(log.parameter);
                        Clients.Group("Gardrop").BiriMagazadanCikti(log.parameter);
                    }
                }
                else
                {
                    OnlineUser offline_olundumu = messangerManager.OfflineOl(kullanici_id);
                    List<OnlineUser> online_arkadaslar = messangerManager.OnlineArkadaslar(kullanici_id);

                    for (int i = 0; i < online_arkadaslar.Count; i++)
                    {
                        Clients.Client(online_arkadaslar[i].ConnectionId).BirisiOfflineOldu(kullanici_id);
                    }

                    if (log.Buraya == "Gardrop/Magaza" || log.Buraya == "Gardrop/UrunDetayliIncele")
                    {
                        votedressUserManager.MagazadakilerinSayisiniAzalt(log.parameter);

                        Groups.Remove(Context.ConnectionId, "Gardrop");
                        Clients.OthersInGroup("Gardrop").BiriMagazadanCikti(log.parameter);
                    }
                }
            }
            return base.OnDisconnected(stopCalled);
        }



        public void ozel_sendMessage(Guid gonderen_id, Guid alan_id, string mesaj)
        {
            MessangerManager messangerManager = new MessangerManager();

            if (gonderen_id != null && alan_id != null && mesaj != null)
            {
                BlockedUserManager blockedUserManager = new BlockedUserManager();
                bool banlimi = blockedUserManager.EngelKontrolCiftTarafli(gonderen_id, alan_id);

                if (!banlimi)
                {
                    PrivateMessageManager manager = new PrivateMessageManager();
                    DateTime gonderme_tarihi = DateTime.Now;
                    int mesaj_id = manager.MesajGonder(gonderen_id, alan_id, mesaj, gonderme_tarihi);

                    OnlineUser mesaj_gonderen = messangerManager.OnlineMi(gonderen_id);

                    if (mesaj_id != 0)
                    {

                        Clients.Client(mesaj_gonderen.ConnectionId).sendMessage_kendime(gonderen_id, mesaj, gonderme_tarihi.ToString(), mesaj_gonderen.User.UserDetail.Name + " " + mesaj_gonderen.User.UserDetail.SurName, mesaj_gonderen.User.ProfileImage);
                        OnlineUser mesaj_gonderilen_kullanici = messangerManager.OnlineMi(alan_id);
                        if (mesaj_gonderilen_kullanici != null)
                        {
                            Clients.Client(mesaj_gonderilen_kullanici.ConnectionId).sendMessage_karsiya(gonderen_id, mesaj, gonderme_tarihi.ToString(), mesaj_gonderen.User.UserDetail.Name + " " + mesaj_gonderen.User.UserDetail.SurName, mesaj_gonderen.User.ProfileImage, mesaj_id);
                        }
                    }
                    else
                    {
                        Clients.Client(mesaj_gonderen.ConnectionId).MesajGonderilemedi();

                    }
                }
                else
                {
                    Clients.Caller.Engelli();
                }
            }
        }

        public void MesajGoruldu(int mesaj_id)
        {
            PrivateMessageManager manager = new PrivateMessageManager();

            bool mesaj_goruldu = manager.MesajGoruldu(mesaj_id);
        }



        #region vote

        public void oyVerildi(Guid oylamaId, int oylamaUrunuId, Guid userId)
        {
            OnlineUserManager onlineUserManager = new OnlineUserManager();
            OnlineUser alanUser = onlineUserManager.OnlineKullaniciyiGetir(userId);

            if(alanUser!=null)
            {
                Clients.Client(alanUser.ConnectionId).OylamanizaOyVerildi(oylamaId,oylamaUrunuId);
            }
        }

        public void OylamaMesajGonder(Guid OylamaSahibiId, Guid OylamaId, Guid BahsedenId, string Mesaj, List<VotedressUser_sade> Bahsedilenler)
        {
            MessangerManager messangerManager = new MessangerManager();

            BlockedUserManager blockedUserManager = new BlockedUserManager();


            bool banlimi = blockedUserManager.EngelKontrol(BahsedenId, OylamaSahibiId);

            if (banlimi == true)
            {
                Clients.Caller.Engelli();
            }
            else
            {
                VoteMessageManager voteMessage_manager = new VoteMessageManager();
                VoteMessage_sade sonuc_Mesaj = voteMessage_manager.OylamaMesajEkle(BahsedenId, OylamaId, Mesaj);

                Clients.Group(OylamaId.ToString()).OylamaMesajGonder(sonuc_Mesaj);

                VotedressUserDetailManager userdetailManager = new VotedressUserDetailManager();

                UserDetail oylamaSahibi = userdetailManager.GetUserDetail(OylamaSahibiId);



                UserDetail bahseden = userdetailManager.GetUserDetail(BahsedenId);
                VotedressUser_sade serialize_hatasindan_bahseden = new VotedressUser_sade();
                serialize_hatasindan_bahseden.id = bahseden.UserId;
                serialize_hatasindan_bahseden.Name = bahseden.Name;
                serialize_hatasindan_bahseden.SurName = bahseden.SurName;
                serialize_hatasindan_bahseden.ProfileImage = bahseden.User.ProfileImage;
                serialize_hatasindan_bahseden.Sex = bahseden.Sex;
                serialize_hatasindan_bahseden.SocialName = bahseden.User.SocialName;
                serialize_hatasindan_bahseden.SocialId = bahseden.User.SocialId;
                serialize_hatasindan_bahseden.Email = bahseden.User.Email;
                serialize_hatasindan_bahseden.Birthday = bahseden.Birthday;

                string conId;
                BahsedilenManager bahsedilenManager = new BahsedilenManager();
                for (int i = 0; i < Bahsedilenler.Count; i++)
                {
                    Bahsedilen eklenen = bahsedilenManager.BahsedilenEkleOylama(OylamaId, BahsedenId, Bahsedilenler[i].id, Mesaj);

                    Bahsedilen_sade gidecek = new Bahsedilen_sade()
                    {
                        Bahseden = serialize_hatasindan_bahseden,
                        BahsetmeTarihi = eklenen.BahsedilmeTarihi,
                        GorulmeDurumu = eklenen.GorulmeDurumu,
                        bahsedilenYerAdi = oylamaSahibi.Name + " " + oylamaSahibi.SurName,
                        Mesaj = eklenen.Mesaj,
                        TipId = OylamaId,
                        Tip = "oylama"
                    };

                    conId = messangerManager.ConnectionIdGetir(Bahsedilenler[i].id);
                    Clients.Client(conId).SizdenBahsedildi(gidecek);
                }

            };


        }

        public void OylamaChatineKatil(Guid BaglananId, Guid OylamaId)
        {

            VotedressUserDetailManager userdetail_Manager = new VotedressUserDetailManager();

            UserDetail kullanici_detayi = new UserDetail();
            kullanici_detayi = userdetail_Manager.GetUserDetail(BaglananId);

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

            Clients.Group(OylamaId.ToString()).ChateBiriBaglandi(sade_kullanici);

            Groups.Add(Context.ConnectionId, OylamaId.ToString());

            InVoteChatManager invotechatManager = new InVoteChatManager();
            invotechatManager.AddUserChat(BaglananId, OylamaId);

        }

        public void OylamaChatindenAyril(Guid BaglananId, Guid OylamaId)
        {
            Groups.Remove(Context.ConnectionId, OylamaId.ToString());
        }




        #endregion


        #region product

        public void uruneKatil(Guid urunId)
        {
            Groups.Add(Context.ConnectionId, urunId.ToString());
        }

        public void uruneYorumYap(Guid urunId, Guid bahsedenId, string yorum, List<Guid> bahsedilenler)
        {

            if (urunId != Guid.Empty && bahsedenId != Guid.Empty)
            {
                VotedressUserManager votedressUserManager = new VotedressUserManager();
                VotedressUser bahseden = votedressUserManager.KullaniciGetir(bahsedenId);

                BahsedilenManager bahsedilenManager = new BahsedilenManager();


                for (int i = 0; i < bahsedilenler.Count; i++)
                {
                    bahsedilenManager.BahsedilenEkleUrun(urunId, bahsedenId, bahsedilenler[i], yorum);
                }

                ProductManager productManager = new ProductManager();
                ProductComment productComment = productManager.UruneYorumEkle(urunId, bahsedenId, yorum);

                OnlineUserManager onlineUserManager = new OnlineUserManager();
                List<OnlineUser> bahsedilenlerOnlineMi = onlineUserManager.OnlineKullaniciyiGetir(bahsedilenler);

                Clients.Group(urunId.ToString()).UruneYorumYapildi(productComment.id, bahseden.id, bahseden.UserDetail.Name + " " + bahseden.UserDetail.SurName, bahseden.ProfileImage, yorum, DateTime.Now);

                VotedressUser_sade votedressUser_sade_bahseden;
                Bahsedilen_sade bahsedilen_sade;

                for (int i = 0; i < bahsedilenlerOnlineMi.Count; i++)
                {
                    votedressUser_sade_bahseden = new VotedressUser_sade()
                    {
                        id = bahsedilenlerOnlineMi[i].UserId,
                        Birthday = bahsedilenlerOnlineMi[i].User.UserDetail.Birthday,
                        Email = bahsedilenlerOnlineMi[i].User.Email,
                        Name = bahsedilenlerOnlineMi[i].User.UserDetail.Name,
                        ProfileImage = bahsedilenlerOnlineMi[i].User.ProfileImage,
                        Sex = bahsedilenlerOnlineMi[i].User.UserDetail.Sex,
                        SocialId = bahsedilenlerOnlineMi[i].User.SocialId,
                        SocialName = bahsedilenlerOnlineMi[i].User.SocialName,
                        SurName = bahsedilenlerOnlineMi[i].User.UserDetail.SurName
                    };

                    bahsedilen_sade = new Bahsedilen_sade();

                    bahsedilen_sade.GorulmeDurumu = false;
                    bahsedilen_sade.BahsetmeTarihi = DateTime.Now;
                    bahsedilen_sade.Mesaj = yorum;
                    bahsedilen_sade.TipId = urunId;
                    bahsedilen_sade.Tip = "product";
                    bahsedilen_sade.bahsedilenYerAdi = productManager.UrunGetir(urunId).User.UserDetail.CompanyName;

                    bahsedilen_sade.Bahseden = votedressUser_sade_bahseden;


                    Clients.Client(bahsedilenlerOnlineMi[i].ConnectionId).SizdenBahsedildi(bahsedilen_sade);
                }


            }

        }

        public void urunYorumunaCevapYap(Guid urunId, int yorumId, Guid yorumaCevapYapanId, string yorum, List<Guid> bahsedilenler)
        {
            if (urunId != Guid.Empty && yorumaCevapYapanId != Guid.Empty && yorumId != 0)
            {
                VotedressUserManager votedressUserManager = new VotedressUserManager();
                VotedressUser bahseden = votedressUserManager.KullaniciGetir(yorumaCevapYapanId);

                BahsedilenManager bahsedilenManager = new BahsedilenManager();


                for (int i = 0; i < bahsedilenler.Count; i++)
                {
                    bahsedilenManager.BahsedilenEkleUrun(urunId, yorumaCevapYapanId, bahsedilenler[i], yorum);
                }

                ProductManager productManager = new ProductManager();
                ProductCommentReply productComment = productManager.UrunYorumunaYorumEkle(yorumId, yorumaCevapYapanId, yorum);

                OnlineUserManager onlineUserManager = new OnlineUserManager();
                List<OnlineUser> bahsedilenlerOnlineMi = onlineUserManager.OnlineKullaniciyiGetir(bahsedilenler);

                Clients.Group(urunId.ToString()).UrunYorumunaCevapYapildi(productComment.id, yorumId, bahseden.id, bahseden.UserDetail.Name + " " + bahseden.UserDetail.SurName, bahseden.ProfileImage, yorum, DateTime.Now);

                VotedressUser_sade votedressUser_sade_bahseden;
                Bahsedilen_sade bahsedilen_sade;

                for (int i = 0; i < bahsedilenlerOnlineMi.Count; i++)
                {
                    votedressUser_sade_bahseden = new VotedressUser_sade()
                    {
                        id = bahsedilenlerOnlineMi[i].UserId,
                        Birthday = bahsedilenlerOnlineMi[i].User.UserDetail.Birthday,
                        Email = bahsedilenlerOnlineMi[i].User.Email,
                        Name = bahsedilenlerOnlineMi[i].User.UserDetail.Name,
                        ProfileImage = bahsedilenlerOnlineMi[i].User.ProfileImage,
                        Sex = bahsedilenlerOnlineMi[i].User.UserDetail.Sex,
                        SocialId = bahsedilenlerOnlineMi[i].User.SocialId,
                        SocialName = bahsedilenlerOnlineMi[i].User.SocialName,
                        SurName = bahsedilenlerOnlineMi[i].User.UserDetail.SurName
                    };

                    bahsedilen_sade = new Bahsedilen_sade();

                    bahsedilen_sade.GorulmeDurumu = false;
                    bahsedilen_sade.BahsetmeTarihi = DateTime.Now;
                    bahsedilen_sade.Mesaj = yorum;
                    bahsedilen_sade.TipId = urunId;
                    bahsedilen_sade.Tip = "product";
                    bahsedilen_sade.bahsedilenYerAdi = productManager.UrunGetir(urunId).User.UserDetail.CompanyName;

                    bahsedilen_sade.Bahseden = votedressUser_sade_bahseden;


                    Clients.Client(bahsedilenlerOnlineMi[i].ConnectionId).SizdenBahsedildi(bahsedilen_sade);
                }


            }
        }


        public void urunAnaYorumBegen(Guid begenenId, int yorumId, Guid urunId)
        {
            if (begenenId != Guid.Empty && yorumId != 0)
            {
                ProductCommentLikeManager productCommentLikeManager = new ProductCommentLikeManager();
                ProductCommentLike productCommentLike = productCommentLikeManager.UrunAnaYorumaBegeniEkle(begenenId, yorumId);

                if (productCommentLike != null)
                {
                    VotedressUser begenen = new VotedressUserManager().KullaniciGetir(begenenId);

                    Clients.Group(urunId.ToString()).BiriAnaYorumuBegendi(begenen.id, begenen.UserDetail.Name + " " + begenen.UserDetail.SurName, yorumId);
                }

            }
        }

        public void urunAnaYorumBegenmektenVazgec(Guid begenmektenVazgecenId, int yorumId, Guid urunId)
        {
            if (begenmektenVazgecenId != Guid.Empty && yorumId != 0 && urunId != Guid.Empty)
            {
                ProductCommentLikeManager productCommentLikeManager = new ProductCommentLikeManager();


                if (productCommentLikeManager.UrunAnaYorumaBegeniSil(begenmektenVazgecenId, yorumId) == true)
                {
                    Clients.Group(urunId.ToString()).BiriAnaYorumuBegenmektenVazgecti(begenmektenVazgecenId, yorumId);
                }

            }
        }


        public void urunAnaYorumCevabiniBegen(Guid begenenId, int anaYorumId, int cevapYorumId, Guid urunId)
        {
            if (begenenId != Guid.Empty && cevapYorumId != 0 && urunId != Guid.Empty)
            {
                ProductCommentReplyLikeManager productCommentReplyLikeManager = new ProductCommentReplyLikeManager();
                ProductCommentReplyLike productCommentReplyLike = productCommentReplyLikeManager.UrunYorumCevabinaBegeniEkle(begenenId, cevapYorumId);

                if (productCommentReplyLike != null)
                {
                    VotedressUser begenen = new VotedressUserManager().KullaniciGetir(begenenId);

                    Clients.Group(urunId.ToString()).BiriAnaYorumCevabiniBegendi(begenen.id, begenen.UserDetail.Name + " " + begenen.UserDetail.SurName, anaYorumId, cevapYorumId);
                }

            }
        }

        public void urunAnaYorumCevabiniBegenmektenVazgec(Guid begenmektenVazgecenId, int anaYorumId, int cevapYorumId, Guid urunId)
        {
            if (begenmektenVazgecenId != Guid.Empty && cevapYorumId != 0 && urunId != Guid.Empty)
            {
                ProductCommentReplyLikeManager productCommentLikeManager = new ProductCommentReplyLikeManager();


                if (productCommentLikeManager.UrunAnaYorumCevapBegeniSil(begenmektenVazgecenId, cevapYorumId) == true)
                {
                    Clients.Group(urunId.ToString()).BiriAnaYorumCevabiniBegenmektenVazgecti(begenmektenVazgecenId, anaYorumId, cevapYorumId);
                }

            }
        }

        #endregion


        public void DeleteFriend(Guid silinenUserId)
        {
            OnlineUserManager onlineUserManager = new OnlineUserManager();
            OnlineUser silinenUser = onlineUserManager.OnlineKullaniciyiGetir(silinenUserId);
            OnlineUser silenUser = onlineUserManager.OnlineKullaniciyiGetirConId(Context.ConnectionId);

            if (silinenUser != null)
            {
                Clients.Client(silinenUser.ConnectionId).ArkadaslikdanCikarildiniz(silenUser.UserId);
            }
        }

        public void AddFriend(Guid eklenenUserId)
        {
            OnlineUserManager onlineUserManager = new OnlineUserManager();

            OnlineUser ekleyenUser = onlineUserManager.OnlineKullaniciyiGetirConId(Context.ConnectionId);

            if (ekleyenUser != null)
            {
                OnlineUser eklenenUser = onlineUserManager.OnlineKullaniciyiGetir(eklenenUserId);

                if (eklenenUser != null)
                {


                    Clients.Client(eklenenUser.ConnectionId).ArkadasIstegiVar(new Friend_sade()
                    {
                        Tarih = DateTime.Now,
                        UserId = ekleyenUser.UserId,
                        UserNameSurname = ekleyenUser.User.UserDetail.Name + " " + ekleyenUser.User.UserDetail.SurName,
                        UserProfileImage = ekleyenUser.User.ProfileImage

                    });
                }
            }

        }

        public void ArkadaslikIstegiKabulEdildi(Guid kabulEdilenUserId)
        {
            OnlineUserManager onlineUserManager = new OnlineUserManager();

            OnlineUser kabulEdilenUser = onlineUserManager.OnlineKullaniciyiGetir(kabulEdilenUserId);
            OnlineUser kabulEdenUser = onlineUserManager.OnlineKullaniciyiGetirConId(Context.ConnectionId);

            if (kabulEdilenUser != null)
            {


                Clients.Client(kabulEdilenUser.ConnectionId).ArkadaslikIsteginizKabulEdildi(new Friend_sade()
                {
                    UserId = kabulEdenUser.UserId,
                    UserNameSurname = kabulEdenUser.User.UserDetail.Name + " " + kabulEdenUser.User.UserDetail.SurName,
                    UserProfileImage = kabulEdenUser.User.ProfileImage
                });

                Clients.Caller.ArkadaslikIstegiKabulEdilenKisininDurumu(new Friend_sade()
                {
                    UserId = kabulEdilenUser.UserId,
                    UserNameSurname = kabulEdilenUser.User.UserDetail.Name + " " + kabulEdilenUser.User.UserDetail.SurName,
                    UserProfileImage = kabulEdilenUser.User.ProfileImage
                }, true);
            }
            else
            {
                VotedressUserManager votedressUserManager = new VotedressUserManager();

                VotedressUser votedressUser = votedressUserManager.KullaniciGetir(kabulEdilenUserId);

                Clients.Caller.ArkadaslikIstegiKabulEdilenKisininDurumu(new Friend_sade()
                {
                    UserId = votedressUser.id,
                    UserNameSurname = votedressUser.UserDetail.Name + " " + votedressUser.UserDetail.SurName,
                    UserProfileImage = votedressUser.ProfileImage
                }, false);
            }

            WhisperManager whisperManager = new WhisperManager();

            whisperManager.DeleteWhisper(kabulEdenUser.UserId, kabulEdilenUserId);//Benim whisperim
            whisperManager.DeleteWhisper(kabulEdilenUserId, kabulEdenUser.UserId);//Kabul ettigim kişinin whisperi

        }



        public void OylamalardanMesajlariniSil(Guid userId, Guid voteId)
        {

            OnlineUserManager onlineUserManager = new OnlineUserManager();
            VotedressUserManager votedressUserManager = new VotedressUserManager();
            VotedressUser engellenenUser = votedressUserManager.KullaniciGetir(userId);
            OnlineUser engelleyenKisi = onlineUserManager.OnlineKullaniciyiGetirConId(Context.ConnectionId);

            if (engelleyenKisi != null && engellenenUser != null)
            {

                VoteMessageManager voteMessageManager = new VoteMessageManager();
                voteMessageManager.OylamadanMesajlariSil(userId, voteId);



                Clients.Group(voteId.ToString()).OylamadanMesalariSil(userId, voteId);
            }
        }


        public void deneme()
        {
            Clients.All.deneme();
        }

        public void GardrobaKatil()
        {
            Groups.Add(Context.ConnectionId, "Gardrop");
        }
    }
}
