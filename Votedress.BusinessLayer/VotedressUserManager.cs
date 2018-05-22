using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.Entities;
using Votedress.Entities.Modellerim;
using Votedress.Entities.Modellerim.GirisEkrainModellerim;
using Votedress.Entities.Modellerim.KayıtolEkranıModellerim;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.Messages;
using Votedress.Entities.Helpers;
using Votedress.Entities.Modellerim.BusinessLayerResult;
using Votedress.Entities.GirisEkraniModellerim;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.DataAccessLayer;

namespace Votedress.BusinessLayer
{
    public class VotedressUserManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public VotedressUserManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public UserManagerResult BireyselKullaniciKayit(BireyselHesapKayit kullanici)
        {
            UserManagerResult res = new UserManagerResult();

            VotedressUser kayitli_kullanici = EmailKontrol(kullanici.Email);

            if (kayitli_kullanici != null)
            {
                res.AddError(ErrorMessageCode.UserNameAlreadyExists, "Bu email zaten kayıtlı."); // Daha farklı hatalarda olsaydı onuda listeye eklicegimiz için list türünde yaptık
                res.HataNerece.Add("BireyselHesap.Email");
            }

            else
            {
                Guid id = Guid.NewGuid();

                VotedressUser user = new VotedressUser()
                {
                    id = id,
                    Email = kullanici.Email,
                    ActivateGuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Password = kullanici.Sifre,
                    Role = "bireysel",
                    ProfileImage = "/Content/img/profil_resmi.png",
                    SocialId = null,
                    SocialName = "votedress",
                    IsActive = false,
                   

                };


                UserDetail UserDetail = new UserDetail()
                {
                    UserId = id,
                    Birthday = kullanici.DogumTarihi,
                    Name = kullanici.Ad,
                    SurName = kullanici.Soyad,
                    Sex = kullanici.Cinsiyet,
                    City = null,
                    Neighborhood = null,
                    County = null,
                    User = user,
                    

                };

                unitOfWork.Repository<VotedressUser>().Insert(user);
                int dbResult = unitOfWork.SaveChanges();

                unitOfWork.Repository<UserDetail>().Insert(UserDetail);
                dbResult = +unitOfWork.SaveChanges();


                if (dbResult > 0)
                {
                    res.User = unitOfWork.Repository<VotedressUser>().Find(x => x.Email == kullanici.Email);


                    MailHelper MailGonder = new MailHelper();

                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activateGuid = $"{siteUri}/Account/HesapAktive/{res.User.ActivateGuid}";

                    string body = $"Hesabınızı aktifleştirmek için <a href='{activateGuid}' target='_blank'> tıklayınız.</a>";

                    MailGonder.SendMail(body, res.User.Email, "Votedress Hesap Aktifleştirme");
                }
            }

            return res;

        }

        public UserManagerResult KurumsalKullaniciKayit(KurumsalHesapKayit kullanici)
        {
            UserManagerResult res = new UserManagerResult();

            VotedressUser kayitli_kullanici = EmailKontrol(kullanici.Email);
            UserDetail kurumsal_kullanici = TcnoKontrol(kullanici.Tcno);

            int kontrol = 0;

            if (kayitli_kullanici != null)
            {
                res.AddError(ErrorMessageCode.UserNameAlreadyExists, "Bu email zaten kayıtlı."); // Daha farklı hatalarda olsaydı onuda listeye eklicegimiz için list türünde yaptık
                res.HataNerece.Add("KurumsalHesap.Email");
                kontrol = 1;
            }

            if (kurumsal_kullanici != null)
            {
                res.AddError(ErrorMessageCode.TcnoAlreadyExists, "Bu TC numarası kayitli"); // Daha farklı hatalarda olsaydı onuda listeye eklicegimiz için list türünde yaptık
                res.HataNerece.Add("KurumsalHesap.Tcno");
                kontrol = 1;
            }
            if (kontrol != 1)
            {


                Guid id = Guid.NewGuid();

                VotedressUser user = new VotedressUser()
                {
                    id = id,
                    Email = kullanici.Email,
                    ActivateGuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Password = kullanici.Sifre,
                    Role = "kurumsal",
                    ProfileImage = null,
                    SocialId = null,
                    SocialName = "votedress",
                    IsActive = false,


                };


                City il = new City();

                int cityId = int.Parse(kullanici.Il);
                il = unitOfWork.Repository<City>().Find(x => x.CityID == cityId);

                County ilce = new County();
                int countyID = int.Parse(kullanici.Ilce);
                ilce = unitOfWork.Repository<County>().Find(x => x.CountyID == countyID);

                Neighborhood mahalle = new Neighborhood();
                int NeighborhoodID = int.Parse(kullanici.Mahalle);
                mahalle = unitOfWork.Repository<Neighborhood>().Find(x => x.NeighborhoodID == NeighborhoodID);


                UserDetail UserDetail = new UserDetail()
                {
                    UserId = id,
                    Name = kullanici.Ad,
                    SurName = kullanici.Soyad,
                    City = il,
                    County = ilce,
                    Neighborhood = mahalle,
                    AdressDetail = kullanici.Adresdetayi,
                    CommencialTitle = kullanici.Ticariunvan,
                    LandPhone = kullanici.Sabitno,
                    PhoneNumber = kullanici.Ceptelefonno,
                    TcNo = kullanici.Tcno,
                    TypeOfBusiness = kullanici.Isletmeturu,
                    Birthday = null,
                    Sex = null,
                    User = user



                };


                unitOfWork.Repository<VotedressUser>().Insert(user);
                int dbResult = unitOfWork.SaveChanges();


                unitOfWork.Repository<UserDetail>().Insert(UserDetail);
                dbResult = +unitOfWork.SaveChanges();




                if (dbResult > 2)
                {
                    res.User = unitOfWork.Repository<VotedressUser>().Find(x => x.Email == kullanici.Email);
                    res.UserDetail = unitOfWork.Repository<UserDetail>().Find(x => x.UserId == res.User.id);


                    MailHelper MailGonder = new MailHelper();

                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activateGuid = $"{siteUri}/Account/HesapAktive/{res.User.ActivateGuid}";

                    string body = $"Hesabınızı aktifleştirmek için <a href='{activateGuid}' target='_blank'> tıklayınız.</a>";

                    MailGonder.SendMail(body, res.User.Email, "Votedress Hesap Aktifleştirme");
                }
            }
            return res;
        }

        public UserManagerResult HesapAktiveEt(Guid activeGuid)
        {

            UserManagerResult res = new UserManagerResult();
            res.User = unitOfWork.Repository<VotedressUser>().Find(x => x.ActivateGuid == activeGuid);

            if (res.User != null)
            {
                if (res.User.IsActive)
                {
                    res.AddError(ErrorMessageCode.UserAlreadyActive, "Bu hesap zaten aktif");
                    return res;
                }
                else
                {
                    res.User.IsActive = true;
                    unitOfWork.Repository<VotedressUser>().Update(res.User);
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Bu aktive kodu geçersiz");

            }
            return res;
        }

        public UserManagerResult GirisKontrol(Giris kullanici)
        {
            UserManagerResult res = new UserManagerResult();
            res.User = unitOfWork.Repository<VotedressUser>().Find(x => x.Email == kullanici.Email && x.Password == kullanici.Password);

            List<VotedressUser> k = new List<VotedressUser>();

            if (res.User != null)
            {
                if (res.User.IsActive != true)
                {
                    res.AddError(ErrorMessageCode.UserIsNotActive, "Bu hesap aktifleştirlmemiş Lütfen mail adresinizi kontrol ediniz");
                    res.HataNerece.Add("yukarida");
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı veya şifre uyuşmuyor");
                res.HataNerece.Add("yukarida");
            }
            return res;
        }

        public VotedressUser EmailKontrol(string email)
        {

            return unitOfWork.Repository<VotedressUser>().Find(x => x.Email == email);
        }

        public UserDetail TcnoKontrol(string tcno)
        {
            return unitOfWork.Repository<UserDetail>().Find(x => x.TcNo == tcno);
        }

        public VotedressUser KullaniciGetir(Guid kullanici_id)
        {
            return unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici_id);

        }

        public void MagazadakilerinSayisiniArttir(string magazaId)
        {
            Guid magaza_id = new Guid(magazaId);
            VotedressUser user = KullaniciGetir(magaza_id);

            user.OnlineCount++;
            unitOfWork.Repository<VotedressUser>().Update(user);
            unitOfWork.SaveChanges();
        }

        public void MagazadakilerinSayisiniAzalt(string magazaId)
        {
            Guid magaza_id = new Guid(magazaId);
            VotedressUser user = KullaniciGetir(magaza_id);

            user.OnlineCount--;
            unitOfWork.Repository<VotedressUser>().Update(user);
            unitOfWork.SaveChanges();

        }

        public List<VotedressUser> pagerMagazalariGetir(int cityID,int countyID,int neighborhoodID,int franchiseID,int page = 1, int pageSize=12 )
        {
            if(cityID==0 && franchiseID==0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal").Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            if (cityID == 0 && franchiseID !=0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal" && x.Franchise.id==franchiseID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            if (cityID!=0 && countyID == 0 && neighborhoodID == 0 && franchiseID==0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal" && x.UserDetail.City.CityID==cityID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            if(cityID!=0 && countyID != 0 && neighborhoodID == 0 && franchiseID == 0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal" && x.UserDetail.City.CityID == cityID && x.UserDetail.County.CountyID==countyID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            if(cityID != 0 && countyID != 0 && neighborhoodID!= 0 && franchiseID == 0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal" && x.UserDetail.City.CityID == cityID && x.UserDetail.County.CountyID == countyID && x.UserDetail.Neighborhood.NeighborhoodID==neighborhoodID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            

            if (cityID != 0 && countyID == 0 && neighborhoodID == 0 && franchiseID != 0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal" && x.UserDetail.City.CityID == cityID && x.Franchise.id== franchiseID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            if (cityID != 0 && countyID != 0 && neighborhoodID == 0 && franchiseID != 0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal" && x.UserDetail.City.CityID == cityID && x.UserDetail.County.CountyID == countyID && x.Franchise.id== franchiseID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            if (cityID != 0 && countyID != 0 && neighborhoodID != 0 && franchiseID != 0)
            {
                return unitOfWork.Repository<VotedressUser>().List(x => x.Role == "kurumsal" && x.UserDetail.City.CityID == cityID && x.UserDetail.County.CountyID == countyID && x.UserDetail.Neighborhood.NeighborhoodID == neighborhoodID && x.Franchise.id== franchiseID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            return null;
        }
    }
}