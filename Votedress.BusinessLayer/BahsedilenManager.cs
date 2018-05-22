using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class BahsedilenManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public BahsedilenManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public List<Bahsedilen_sade> BahsedenleriGetir(Guid kullanici_id)
        {
            List<Bahsedilen> bahsedenlerList=unitOfWork.Repository<Bahsedilen>().List(x => x.BahsedilenId.id == kullanici_id && x.GorulmeDurumu == false);

            List<Bahsedilen_sade> bahsedilen_sadeList = new List<Bahsedilen_sade>();

            Bahsedilen_sade bahsedilen_sade;
            VotedressUser_sade votedressUser_sade_bahseden;
            for (int i = 0; i < bahsedenlerList.Count; i++)
            {
                votedressUser_sade_bahseden = new VotedressUser_sade()
                {
                    id = bahsedenlerList[i].BahsedenId.id,
                    Birthday = bahsedenlerList[i].BahsedenId.UserDetail.Birthday,
                    Email = bahsedenlerList[i].BahsedenId.Email,
                    Name = bahsedenlerList[i].BahsedenId.UserDetail.Name,
                    ProfileImage = bahsedenlerList[i].BahsedenId.ProfileImage,
                    Sex = bahsedenlerList[i].BahsedenId.UserDetail.Sex,
                    SocialId = bahsedenlerList[i].BahsedenId.SocialId,
                    SocialName = bahsedenlerList[i].BahsedenId.SocialName,
                    SurName = bahsedenlerList[i].BahsedenId.UserDetail.SurName
                };

                if (bahsedenlerList[i].Vote!=null)
                {
                    bahsedilen_sade = new Bahsedilen_sade();
                    bahsedilen_sade.GorulmeDurumu = bahsedenlerList[i].GorulmeDurumu;
                    bahsedilen_sade.BahsetmeTarihi = bahsedenlerList[i].BahsedilmeTarihi;
                    bahsedilen_sade.Mesaj = bahsedenlerList[i].Mesaj;
                    bahsedilen_sade.TipId = bahsedenlerList[i].Vote.id;
                    bahsedilen_sade.Tip = "vote";
                    bahsedilen_sade.bahsedilenYerAdi = bahsedenlerList[i].Vote.User.UserDetail.Name+" " + bahsedenlerList[i].Vote.User.UserDetail.SurName;

                    bahsedilen_sade.Bahseden = votedressUser_sade_bahseden;


                    bahsedilen_sadeList.Add(bahsedilen_sade);
                }
                else if(bahsedenlerList[i].Product!=null)
                {
                    bahsedilen_sade = new Bahsedilen_sade();
                    bahsedilen_sade.GorulmeDurumu = bahsedenlerList[i].GorulmeDurumu;
                    bahsedilen_sade.BahsetmeTarihi = bahsedenlerList[i].BahsedilmeTarihi;
                    bahsedilen_sade.Mesaj = bahsedenlerList[i].Mesaj;
                    bahsedilen_sade.TipId = bahsedenlerList[i].Product.id;
                    bahsedilen_sade.Tip = "product";
                    bahsedilen_sade.bahsedilenYerAdi = bahsedenlerList[i].Product.User.UserDetail.CompanyName;

                    bahsedilen_sade.Bahseden = votedressUser_sade_bahseden;


                    bahsedilen_sadeList.Add(bahsedilen_sade);
                }
                else if(bahsedenlerList[i].Collection!=null)
                {
                    bahsedilen_sade = new Bahsedilen_sade();
                    bahsedilen_sade.GorulmeDurumu = bahsedenlerList[i].GorulmeDurumu;
                    bahsedilen_sade.BahsetmeTarihi = bahsedenlerList[i].BahsedilmeTarihi;
                    bahsedilen_sade.Mesaj = bahsedenlerList[i].Mesaj;
                    bahsedilen_sade.TipId = bahsedenlerList[i].Collection.id;
                    bahsedilen_sade.Tip = "collection";
                    bahsedilen_sade.bahsedilenYerAdi = bahsedenlerList[i].Collection.User.UserDetail.Name+" "+ bahsedenlerList[i].Collection.User.UserDetail.SurName;


                    bahsedilen_sade.Bahseden = votedressUser_sade_bahseden;

                    bahsedilen_sadeList.Add(bahsedilen_sade);
                }
                else 
                {
                    bahsedilen_sade = new Bahsedilen_sade();
                    bahsedilen_sade.GorulmeDurumu = bahsedenlerList[i].GorulmeDurumu;
                    bahsedilen_sade.BahsetmeTarihi = bahsedenlerList[i].BahsedilmeTarihi;
                    bahsedilen_sade.Mesaj = bahsedenlerList[i].Mesaj;
                    bahsedilen_sade.TipId = bahsedenlerList[i].SocialShare.id;
                    bahsedilen_sade.Tip = "socialshare";
                    bahsedilen_sade.bahsedilenYerAdi = bahsedenlerList[i].SocialShare.VotedressUser.UserDetail.Name + " " + bahsedenlerList[i].SocialShare.VotedressUser.UserDetail.SurName;

                    bahsedilen_sade.Bahseden = votedressUser_sade_bahseden;

                    bahsedilen_sadeList.Add(bahsedilen_sade);
                }            
            }

            return bahsedilen_sadeList;
        }

        public Bahsedilen BahsedilenEkleOylama(Guid OylamaId,Guid BahsedenId,Guid BahsedilenId,string Mesaj)
        {
            Bahsedilen bahsedilen = new Bahsedilen();
                       
            bahsedilen.BahsedenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedenId);
            bahsedilen.BahsedilenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedilenId);
            bahsedilen.Vote = unitOfWork.Repository<Vote>().Find(x => x.id == OylamaId);
            bahsedilen.Collection = null;
            bahsedilen.Product = null;
            bahsedilen.SocialShare = null;
            bahsedilen.BahsedilmeTarihi = DateTime.Now;
            bahsedilen.GorulmeDurumu = false;
            bahsedilen.Mesaj = Mesaj;

            Bahsedilen eklenen= unitOfWork.Repository<Bahsedilen>().Insert(bahsedilen);
            unitOfWork.SaveChanges();

            return eklenen;   
        }

        public Bahsedilen BahsedilenEkleUrun(Guid urunId, Guid BahsedenId, Guid BahsedilenId, string Mesaj)
        {
            Bahsedilen bahsedilen = new Bahsedilen();

            bahsedilen.BahsedenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedenId);
            bahsedilen.BahsedilenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedilenId);
            bahsedilen.Vote = null;
            bahsedilen.Collection = null;
            bahsedilen.Product = unitOfWork.Repository<Product>().Find(x=>x.id==urunId);
            bahsedilen.SocialShare = null;
            bahsedilen.BahsedilmeTarihi = DateTime.Now;
            bahsedilen.GorulmeDurumu = false;
            bahsedilen.Mesaj = Mesaj;

            Bahsedilen eklenen = unitOfWork.Repository<Bahsedilen>().Insert(bahsedilen);
            unitOfWork.SaveChanges();

            return eklenen;
        }

        public Bahsedilen BahsedilenEkleCollection(Guid CollectionId, Guid BahsedenId, Guid BahsedilenId, string Mesaj)
        {
            Bahsedilen bahsedilen = new Bahsedilen();

            bahsedilen.BahsedenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedenId);
            bahsedilen.BahsedilenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedilenId);
            bahsedilen.Vote = null;
            bahsedilen.Collection = unitOfWork.Repository<Category>().Find(x => x.id == CollectionId);
            bahsedilen.Product = null;
            bahsedilen.SocialShare = null;
            bahsedilen.BahsedilmeTarihi = DateTime.Now;
            bahsedilen.GorulmeDurumu = false;
            bahsedilen.Mesaj = Mesaj;

            Bahsedilen eklenen = unitOfWork.Repository<Bahsedilen>().Insert(bahsedilen);
            unitOfWork.SaveChanges();

            return eklenen;
        }

        public Bahsedilen BahsedilenEkleSocialShare(Guid socialShareId, Guid BahsedenId, Guid BahsedilenId, string Mesaj)
        {
            Bahsedilen bahsedilen = new Bahsedilen();

            bahsedilen.BahsedenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedenId);
            bahsedilen.BahsedilenId = unitOfWork.Repository<VotedressUser>().Find(x => x.id == BahsedilenId);
            bahsedilen.Vote = null;
            bahsedilen.Collection = null;
            bahsedilen.Product = null;
            bahsedilen.SocialShare = unitOfWork.Repository<SocialShare>().Find(x => x.id == socialShareId);
            bahsedilen.BahsedilmeTarihi = DateTime.Now;
            bahsedilen.GorulmeDurumu = false;
            bahsedilen.Mesaj = Mesaj;

            Bahsedilen eklenen = unitOfWork.Repository<Bahsedilen>().Insert(bahsedilen);
            unitOfWork.SaveChanges();

            return eklenen;
        }


    }
}
