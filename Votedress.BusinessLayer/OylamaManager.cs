using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.Helpers;
using System.Linq;
using Votedress.Entities.SadeModeller;
using Votedress.DataAccessLayer;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.ViewModellerim;
using Votedress.Entities.Modellerim.Oylamalarim;

namespace Votedress.BusinessLayer
{
    public class OylamaManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public OylamaManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public bool OylamaEkle(Guid kullanici_id, string oylama_suresi, string oylama_tipi, bool paylasima_acikmi, bool profil_gorulsunmu, HttpFileCollectionBase files, string urun_1, string urun_2, string urun_3, string urun_aciklamasi_1_1, string urun_aciklamasi_1_2, string urun_aciklamasi_1_3, string urun_aciklamasi_2_1, string urun_aciklamasi_2_2, string urun_aciklamasi_2_3, string urun_aciklamasi_3_1, string urun_aciklamasi_3_2, string urun_aciklamasi_3_3)
        {
            try
            {
                Guid vote_id = Guid.NewGuid();

                Vote vote = new Vote();
                DateTime zaman = DateTime.Now;
                vote.StartTime = zaman;

                vote.id = vote_id;

                if (oylama_suresi == "15 dakika")
                {
                    vote.FinishTime = zaman.AddMinutes(15);
                }
                else if (oylama_suresi == "30 dakika")
                {
                    vote.FinishTime = zaman.AddMinutes(30);
                }
                else if (oylama_suresi == "1 saat")
                {
                    vote.FinishTime = zaman.AddHours(1);
                }
                else if (oylama_suresi == "2 saat")
                {
                    vote.FinishTime = zaman.AddHours(2);
                }
                else if (oylama_suresi == "3 saat")
                {
                    vote.FinishTime = zaman.AddHours(3);
                }
                else if (oylama_suresi == "1 gün")
                {
                    vote.FinishTime = zaman.AddDays(1);
                }
                else if (oylama_suresi == "2 gün")
                {
                    vote.FinishTime = zaman.AddDays(2);
                }
                else if (oylama_suresi == "3 gün")
                {
                    vote.FinishTime = zaman.AddDays(3);
                }


                if (oylama_tipi == "gizli")
                {
                    vote.TypeOfVote = "gizli";
                }
                else
                {
                    vote.TypeOfVote = "genel";
                }



                vote.User = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici_id);



                vote.VoteLink = Guid.NewGuid();

                unitOfWork.Repository<Vote>().Insert(vote);
                unitOfWork.SaveChanges();

                Guid oylama_id = vote_id;



                VoteImage vote_image;

                VoteProduct voteProduct1 = null;
                VoteProduct voteProduct2 = null;
                VoteProduct voteProduct3 = null;


                if (urun_1 != null)
                {
                    voteProduct1 = new VoteProduct()
                    {
                        Vote = vote,
                        VoteCount = 0,
                        Product = unitOfWork.Repository<Product>().Find(x => x.id == new Guid(urun_1))
                    };

                    unitOfWork.Repository<VoteProduct>().Insert(voteProduct1);
                }
                if (urun_2 != null)
                {
                    voteProduct2 = new VoteProduct()
                    {
                        Vote = vote,
                        VoteCount = 0,
                        Product = unitOfWork.Repository<Product>().Find(x => x.id == new Guid(urun_2))
                    };

                    unitOfWork.Repository<VoteProduct>().Insert(voteProduct2);
                }
                if (urun_3 != null)
                {
                    voteProduct3 = new VoteProduct()
                    {
                        Vote = vote,
                        VoteCount = 0,
                        Product = unitOfWork.Repository<Product>().Find(x => x.id == new Guid(urun_3))
                    };

                    unitOfWork.Repository<VoteProduct>().Insert(voteProduct3);
                }




                int i = 1;
                foreach (string name in files)
                {
                    var file = files[name];

                    if (file.ContentLength > 0)
                    {
                        vote_image = new VoteImage();

                        if (name == "urun_resim_1_1")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));

                            vote_image.VoteProduct = voteProduct1;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_1_1;
                        }
                        else if (name == "urun_resim_1_2")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));


                            vote_image.VoteProduct = voteProduct1;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_1_2;
                        }
                        else if (name == "urun_resim_1_3")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));

                            vote_image.VoteProduct = voteProduct1;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_1_3;
                        }
                        else if (name == "urun_resim_2_1")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));



                            vote_image.VoteProduct = voteProduct2;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_2_1;
                        }
                        else if (name == "urun_resim_2_2")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));


                            vote_image.VoteProduct = voteProduct2;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_2_2;
                        }
                        else if (name == "urun_resim_2_3")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));


                            vote_image.VoteProduct = voteProduct2;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_2_3;
                        }
                        else if (name == "urun_resim_3_1")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));

                            vote_image.VoteProduct = voteProduct3;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_3_1;
                        }
                        else if (name == "urun_resim_3_2")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));



                            vote_image.VoteProduct = voteProduct3;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_3_2;
                        }
                        else if (name == "urun_resim_3_3")
                        {
                            Image sourceimage = Image.FromStream(file.InputStream);
                            Image boyutlandirilmis_resim = ResizeImage.Resize(sourceimage, 600, 600);

                            string imagePath = "/Content/img/" + kullanici_id + "_" + oylama_id + "_" + i + ".jpg";

                            boyutlandirilmis_resim.Save(HttpContext.Current.Server.MapPath(imagePath));



                            vote_image.VoteProduct = voteProduct3;
                            vote_image.ImagePath = imagePath;
                            vote_image.ImageNo = i;
                            vote_image.Aciklama = urun_aciklamasi_3_3;
                        }

                        unitOfWork.Repository<VoteImage>().Insert(vote_image);

                        i++;

                    }
                }

                unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public Vote_sade OylamaGetir(Guid oylamaId, Guid userId)
        {
            Vote vote = unitOfWork.Repository<Vote>().Find(x => x.id == oylamaId);


            if (vote.User.id == userId)
            {

                Vote_sade vote_sade = new Vote_sade();

                vote_sade.id = vote.id;
                vote_sade.PaylasimaAcikmi = vote.PaylasimaAcikmi;
                vote_sade.ProfilGorunsunMu = vote.ProfilGorunsunMu;
                vote_sade.StartTime = vote.StartTime;
                vote_sade.TypeOfVote = vote.TypeOfVote;
                vote_sade.VoteLink = vote.VoteLink;
                vote_sade.FinishTime = vote.FinishTime;


                vote_sade.OylamaUrunleri = vote.VoteProduct.Select(x => new VoteProduct_sade()
                {

                    id = x.id,
                    ProductId = x.Product.id,
                    ProductName = x.Product.ProductName,
                    ProductImage = x.Product.ProductImage,
                    Price = x.Product.Price,
                    IsForSale = x.Product.IsForSale,
                    VoteCount = x.VoteCount,
                    LongDescription = x.Product.LongDescription,
                    ShortDescription = x.Product.ShortDescription,
                    UrunSahibi = new Magazalar_sade()
                    {
                        MagazaGuid = x.Product.User.id,
                        SirketAdi = x.Product.User.UserDetail.CompanyName,
                        SirketResmi = x.Product.User.ProfileImage,
                        TelNo = x.Product.User.UserDetail.PhoneNumber,
                        Email = x.Product.User.Email,
                        WebSite = "www.deneme.com",
                        MagazadakilerSayisi = x.Product.User.OnlineCount,
                        Sehir = x.Product.User.UserDetail.City.CityName,
                        Ilce = x.Product.User.UserDetail.County.CountyName,
                        Mahalle = x.Product.User.UserDetail.Neighborhood.NeighborhoodName,
                        Adres = x.Product.User.UserDetail.AdressDetail,
                        FranchiseAdi = x.Product.User.Franchise.FranchiseName,
                        FranchiseLogo = x.Product.User.Franchise.FranchiseLogo,
                    },

                    OylamaResimleri = x.VoteImages.Select(t => new VoteImage_sade()
                    {
                        id = t.id,
                        Aciklama = t.Aciklama,
                        ImageNo = t.ImageNo,
                        ImagePath = t.ImagePath

                    }).ToList()

                }).ToList();

                vote_sade.OylamaSahibi.id = vote.User.id;
                vote_sade.OylamaSahibi.Name = vote.User.UserDetail.Name;
                vote_sade.OylamaSahibi.SurName = vote.User.UserDetail.SurName;
                vote_sade.OylamaSahibi.Email = vote.User.Email;
                vote_sade.OylamaSahibi.Birthday = vote.User.UserDetail.Birthday;
                vote_sade.OylamaSahibi.Sex = vote.User.UserDetail.Sex;
                vote_sade.OylamaSahibi.ProfileImage = vote.User.ProfileImage;
                vote_sade.OylamaSahibi.SocialId = vote.User.SocialId;
                vote_sade.OylamaSahibi.SocialName = vote.User.SocialName;




                if (vote.VoteMessage != null)
                {
                    VoteMessage_sade voteMessage_sade;
                    for (int i = 0; i < vote.VoteMessage.Count; i++)
                    {
                        voteMessage_sade = new VoteMessage_sade();

                        voteMessage_sade.id = vote.VoteMessage[i].id;
                        voteMessage_sade.Message = vote.VoteMessage[i].Message;
                        voteMessage_sade.GondermeTarihi = vote.VoteMessage[i].GondermeTarihi;

                        voteMessage_sade.MesajSahibi.id = vote.VoteMessage[i].User.id;
                        voteMessage_sade.MesajSahibi.Name = vote.VoteMessage[i].User.UserDetail.Name;
                        voteMessage_sade.MesajSahibi.ProfileImage = vote.VoteMessage[i].User.ProfileImage;
                        voteMessage_sade.MesajSahibi.Sex = vote.VoteMessage[i].User.UserDetail.Sex;
                        voteMessage_sade.MesajSahibi.SocialId = vote.VoteMessage[i].User.SocialId;
                        voteMessage_sade.MesajSahibi.SocialName = vote.VoteMessage[i].User.SocialName;
                        voteMessage_sade.MesajSahibi.SurName = vote.VoteMessage[i].User.UserDetail.SurName;
                        voteMessage_sade.MesajSahibi.Email = vote.VoteMessage[i].User.Email;
                        voteMessage_sade.MesajSahibi.Birthday = vote.VoteMessage[i].User.UserDetail.Birthday;

                        vote_sade.OylamaMesajlari.Add(voteMessage_sade);
                    }
                }

                InVoteChatManager invotechatManager = new InVoteChatManager();
                vote_sade.Chattekiler = invotechatManager.ChattekileriGetir(vote.id);
                vote_sade.SessionUserId = userId;

                return vote_sade;
            }

            return null;
        }

        public List<Vote> OylamalarimiGetir(Guid id)
        {
            return unitOfWork.Repository<Vote>().List(x => x.User.id == id);
        }

        public Vote_sade OylamaGetirOylamakIcin(Guid kullanici_id)
        {

            List<Vote> oylamalar = unitOfWork.Repository<Vote>().List();
            List<Guid> oyverdiklerim = unitOfWork.Repository<MyVoted>().List(x => x.User.id == kullanici_id).Select(x => x.Vote.id).ToList();

            DateTime tarih = DateTime.Now;
            List<Vote> oylama = (from p in oylamalar where !oyverdiklerim.Contains(p.id) && p.FinishTime >= tarih && p.User.id != kullanici_id && p.TypeOfVote == "genel" select p).ToList();


            if (oylama.Count != 0)
            {
                int en_kucuk = oylama.Min(x => x.Counter);

                Vote oylama2 = oylama.Where(x => x.Counter == en_kucuk).FirstOrDefault();

                oylama2.Counter = oylama2.Counter + 1;

                unitOfWork.Repository<Vote>().Update(oylama2);
                unitOfWork.SaveChanges();

                Vote_sade vote_sade = new Vote_sade();

                vote_sade.id = oylama2.id;
                vote_sade.PaylasimaAcikmi = oylama2.PaylasimaAcikmi;
                vote_sade.ProfilGorunsunMu = oylama2.ProfilGorunsunMu;
                vote_sade.StartTime = oylama2.StartTime;
                vote_sade.TypeOfVote = oylama2.TypeOfVote;
                vote_sade.VoteLink = oylama2.VoteLink;
                vote_sade.FinishTime = oylama2.FinishTime;


                vote_sade.OylamaUrunleri = oylama2.VoteProduct.Select(x => new VoteProduct_sade()
                {

                    id = x.id,
                    ProductId = x.Product.id,
                    ProductName = x.Product.ProductName,
                    ProductImage = x.Product.ProductImage,
                    Price = x.Product.Price,
                    IsForSale = x.Product.IsForSale,
                    VoteCount = x.VoteCount,
                    LongDescription = x.Product.LongDescription,
                    ShortDescription = x.Product.ShortDescription,
                    UrunSahibi = new Magazalar_sade()
                    {
                        MagazaGuid = x.Product.User.id,
                        SirketAdi = x.Product.User.UserDetail.CompanyName,
                        SirketResmi = x.Product.User.ProfileImage,
                        TelNo = x.Product.User.UserDetail.PhoneNumber,
                        Email = x.Product.User.Email,
                        WebSite = "www.deneme.com",
                        MagazadakilerSayisi = x.Product.User.OnlineCount,
                        Sehir = x.Product.User.UserDetail.City.CityName,
                        Ilce = x.Product.User.UserDetail.County.CountyName,
                        Mahalle = x.Product.User.UserDetail.Neighborhood.NeighborhoodName,
                        Adres = x.Product.User.UserDetail.AdressDetail,
                        FranchiseAdi = x.Product.User.Franchise.FranchiseName,
                        FranchiseLogo = x.Product.User.Franchise.FranchiseLogo,
                    },

                    OylamaResimleri = x.VoteImages.Select(t => new VoteImage_sade()
                    {
                        id = t.id,
                        Aciklama = t.Aciklama,
                        ImageNo = t.ImageNo,
                        ImagePath = t.ImagePath

                    }).ToList()

                }).ToList();

                vote_sade.OylamaSahibi.id = oylama2.User.id;
                vote_sade.OylamaSahibi.Name = oylama2.User.UserDetail.Name;
                vote_sade.OylamaSahibi.SurName = oylama2.User.UserDetail.SurName;
                vote_sade.OylamaSahibi.Email = oylama2.User.Email;
                vote_sade.OylamaSahibi.Birthday = oylama2.User.UserDetail.Birthday;
                vote_sade.OylamaSahibi.Sex = oylama2.User.UserDetail.Sex;
                vote_sade.OylamaSahibi.ProfileImage = oylama2.User.ProfileImage;
                vote_sade.OylamaSahibi.SocialId = oylama2.User.SocialId;
                vote_sade.OylamaSahibi.SocialName = oylama2.User.SocialName;




                if (oylama2.VoteMessage != null)
                {
                    VoteMessage_sade voteMessage_sade;
                    for (int i = 0; i < oylama2.VoteMessage.Count; i++)
                    {
                        voteMessage_sade = new VoteMessage_sade();

                        voteMessage_sade.id = oylama2.VoteMessage[i].id;
                        voteMessage_sade.Message = oylama2.VoteMessage[i].Message;
                        voteMessage_sade.GondermeTarihi = oylama2.VoteMessage[i].GondermeTarihi;

                        voteMessage_sade.MesajSahibi.id = oylama2.VoteMessage[i].User.id;
                        voteMessage_sade.MesajSahibi.Name = oylama2.VoteMessage[i].User.UserDetail.Name;
                        voteMessage_sade.MesajSahibi.ProfileImage = oylama2.VoteMessage[i].User.ProfileImage;
                        voteMessage_sade.MesajSahibi.Sex = oylama2.VoteMessage[i].User.UserDetail.Sex;
                        voteMessage_sade.MesajSahibi.SocialId = oylama2.VoteMessage[i].User.SocialId;
                        voteMessage_sade.MesajSahibi.SocialName = oylama2.VoteMessage[i].User.SocialName;
                        voteMessage_sade.MesajSahibi.SurName = oylama2.VoteMessage[i].User.UserDetail.SurName;
                        voteMessage_sade.MesajSahibi.Email = oylama2.VoteMessage[i].User.Email;
                        voteMessage_sade.MesajSahibi.Birthday = oylama2.VoteMessage[i].User.UserDetail.Birthday;

                        vote_sade.OylamaMesajlari.Add(voteMessage_sade);
                    }
                }

                InVoteChatManager invotechatManager = new InVoteChatManager();
                vote_sade.Chattekiler = invotechatManager.ChattekileriGetir(oylama2.id);



                vote_sade.SessionUserId = kullanici_id;
                return vote_sade;
            }

            return null;
        }
        public bool Oyla(VotedressUser kullanici, int oylanan_id)
        {
            if (kullanici != null && oylanan_id != 0)
            {

                VoteProduct eklenen_oy = unitOfWork.Repository<VoteProduct>().Find(x => x.id == oylanan_id);
                eklenen_oy.VoteCount++;

                unitOfWork.Repository<VoteProduct>().Update(eklenen_oy);
                unitOfWork.SaveChanges();

                Vote deneme = eklenen_oy.Vote;

                MyVoted oyladim = new MyVoted();

                VotedressUser yeni_kullanici = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici.id);
                Vote yeni_vote = unitOfWork.Repository<Vote>().Find(x => x.id == eklenen_oy.Vote.id);

                oyladim.User = yeni_kullanici;
                oyladim.Vote = yeni_vote;


                unitOfWork.Repository<MyVoted>().Insert(oyladim);
                int result = unitOfWork.SaveChanges();



                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public Vote OylamaBilgisiGetir(Guid oylamaId)
        {
            return unitOfWork.Repository<Vote>().Find(x => x.id == oylamaId);
        }
        public List<Vote> UrunluOylamalariGetir(Guid UrunId)
        {
            return unitOfWork.Repository<Vote>().List(x => x.VoteProduct.Any(k => k.Product.id == UrunId));
        }

        public List<Vote> MagazaUrunluOylamalariGetir(Guid magazaId)
        {
            return unitOfWork.Repository<Vote>().List(x => x.VoteProduct.Any(k => k.Product.User.id == magazaId));
        }


        public OylamalarimViewModel OylamalarimSayfasi(Guid kullanici_id)
        {
            List<Vote> oylama = OylamalarimiGetir(kullanici_id);

            if (oylama.Count != 0)
            {

                DateTime enBuyukTarih = oylama.Max(x => x.StartTime);
                Vote vote = oylama.Where(x => x.StartTime == enBuyukTarih).FirstOrDefault();


                if (oylama.Count != 0)
                {

                    Vote_sade vote_sade = new Vote_sade();

                    vote_sade.id = vote.id;
                    vote_sade.PaylasimaAcikmi = vote.PaylasimaAcikmi;
                    vote_sade.ProfilGorunsunMu = vote.ProfilGorunsunMu;
                    vote_sade.StartTime = vote.StartTime;
                    vote_sade.TypeOfVote = vote.TypeOfVote;
                    vote_sade.VoteLink = vote.VoteLink;
                    vote_sade.FinishTime = vote.FinishTime;


                    vote_sade.OylamaUrunleri = vote.VoteProduct.Select(x => new VoteProduct_sade()
                    {

                        id = x.id,
                        ProductId = x.Product.id,
                        ProductName = x.Product.ProductName,
                        ProductImage = x.Product.ProductImage,
                        Price = x.Product.Price,
                        IsForSale = x.Product.IsForSale,
                        VoteCount = x.VoteCount,
                        LongDescription = x.Product.LongDescription,
                        ShortDescription = x.Product.ShortDescription,
                        UrunSahibi = new Magazalar_sade()
                        {
                            MagazaGuid = x.Product.User.id,
                            SirketAdi = x.Product.User.UserDetail.CompanyName,
                            SirketResmi = x.Product.User.ProfileImage,
                            TelNo = x.Product.User.UserDetail.PhoneNumber,
                            Email = x.Product.User.Email,
                            WebSite = "www.deneme.com",
                            MagazadakilerSayisi = x.Product.User.OnlineCount,
                            Sehir = x.Product.User.UserDetail.City.CityName,
                            Ilce = x.Product.User.UserDetail.County.CountyName,
                            Mahalle = x.Product.User.UserDetail.Neighborhood.NeighborhoodName,
                            Adres = x.Product.User.UserDetail.AdressDetail,
                            FranchiseAdi = x.Product.User.Franchise.FranchiseName,
                            FranchiseLogo = x.Product.User.Franchise.FranchiseLogo,
                        },

                        OylamaResimleri = x.VoteImages.Select(t => new VoteImage_sade()
                        {
                            id = t.id,
                            Aciklama = t.Aciklama,
                            ImageNo = t.ImageNo,
                            ImagePath = t.ImagePath

                        }).ToList()

                    }).ToList();

                    vote_sade.OylamaSahibi.id = vote.User.id;
                    vote_sade.OylamaSahibi.Name = vote.User.UserDetail.Name;
                    vote_sade.OylamaSahibi.SurName = vote.User.UserDetail.SurName;
                    vote_sade.OylamaSahibi.Email = vote.User.Email;
                    vote_sade.OylamaSahibi.Birthday = vote.User.UserDetail.Birthday;
                    vote_sade.OylamaSahibi.Sex = vote.User.UserDetail.Sex;
                    vote_sade.OylamaSahibi.ProfileImage = vote.User.ProfileImage;
                    vote_sade.OylamaSahibi.SocialId = vote.User.SocialId;
                    vote_sade.OylamaSahibi.SocialName = vote.User.SocialName;




                    if (vote.VoteMessage != null)
                    {
                        VoteMessage_sade voteMessage_sade;
                        for (int i = 0; i < vote.VoteMessage.Count; i++)
                        {
                            voteMessage_sade = new VoteMessage_sade();

                            voteMessage_sade.id = vote.VoteMessage[i].id;
                            voteMessage_sade.Message = vote.VoteMessage[i].Message;
                            voteMessage_sade.GondermeTarihi = vote.VoteMessage[i].GondermeTarihi;

                            voteMessage_sade.MesajSahibi.id = vote.VoteMessage[i].User.id;
                            voteMessage_sade.MesajSahibi.Name = vote.VoteMessage[i].User.UserDetail.Name;
                            voteMessage_sade.MesajSahibi.ProfileImage = vote.VoteMessage[i].User.ProfileImage;
                            voteMessage_sade.MesajSahibi.Sex = vote.VoteMessage[i].User.UserDetail.Sex;
                            voteMessage_sade.MesajSahibi.SocialId = vote.VoteMessage[i].User.SocialId;
                            voteMessage_sade.MesajSahibi.SocialName = vote.VoteMessage[i].User.SocialName;
                            voteMessage_sade.MesajSahibi.SurName = vote.VoteMessage[i].User.UserDetail.SurName;
                            voteMessage_sade.MesajSahibi.Email = vote.VoteMessage[i].User.Email;
                            voteMessage_sade.MesajSahibi.Birthday = vote.VoteMessage[i].User.UserDetail.Birthday;

                            vote_sade.OylamaMesajlari.Add(voteMessage_sade);
                        }
                    }

                    InVoteChatManager invotechatManager = new InVoteChatManager();
                    vote_sade.Chattekiler = invotechatManager.ChattekileriGetir(vote.id);
                    vote_sade.SessionUserId = kullanici_id;

                    OylamalarimViewModel oylamalarimViewModel = new OylamalarimViewModel();
                    oylamalarimViewModel.vote_Sade = vote_sade;
                    oylamalarimViewModel.oylamalarimModels = oylama.OrderByDescending(x => x.StartTime).Select(x => new OylamalarimModel()
                    {

                        OylamaId = x.id,
                        OylamaBaslangicZamani = x.StartTime,
                        OylamaBitisZamani = x.FinishTime,
                        OylamaDurumu = x.FinishTime < DateTime.Now ? true : false

                    }).ToList();

                    return oylamalarimViewModel;
                }
            }
            return null;
        }
    }
}
