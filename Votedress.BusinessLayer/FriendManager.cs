using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.DataAccessLayer;

using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.Modellerim.BusinessLayerResult;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class FriendManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public FriendManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public List<OnOffArkadaslar> OnOffArkadaslar(Guid kullanici_id)
        {

            if (kullanici_id != null)
            {

                List<Friend> arkadaslar = unitOfWork.Repository<Friend>().List(x => x.User.id == kullanici_id && x.Durum==true).ToList();
                List<Guid> arkadaslar_id = arkadaslar.Select(x => x.MyFriend.id).ToList();

                if (arkadaslar != null)
                {
                    List<OnlineUser> online_arkadaslar = unitOfWork.Repository<OnlineUser>().List(x => arkadaslar_id.Contains(x.UserId)).ToList();
                    List<PrivateMessage> gorulmemis_mesajlar = unitOfWork.Repository<PrivateMessage>().List(x => x.AlanId.id == kullanici_id && x.GorulmeDurumu == false).ToList();

                    List<OnOffArkadaslar> onoff_arkadaslar = new List<OnOffArkadaslar>();
                    OnOffArkadaslar arkdas;


                    if (online_arkadaslar != null)
                    {


                        for (int i = 0; i < online_arkadaslar.Count; i++)
                        {
                            arkdas = new OnOffArkadaslar();

                            arkdas.id = online_arkadaslar[i].UserId;
                            arkdas.AdSoyad = online_arkadaslar[i].User.UserDetail.Name + " " + online_arkadaslar[i].User.UserDetail.SurName;
                            arkdas.ProfilImage = online_arkadaslar[i].User.ProfileImage;
                            arkdas.Online = true;
                            arkdas.GorulmemisMesajSayisi = gorulmemis_mesajlar.Where(x => x.User.id == online_arkadaslar[i].UserId).Count();

                            onoff_arkadaslar.Add(arkdas);

                            for (int k = 0; k < arkadaslar.Count; k++)
                            {
                                if (arkadaslar[k].MyFriend.id == online_arkadaslar[i].UserId)
                                {
                                    arkadaslar.RemoveAt(k);
                                    break;
                                }
                            }
                        }

                        for (int i = 0; i < arkadaslar.Count; i++)
                        {
                            arkdas = new OnOffArkadaslar();

                            arkdas.id = arkadaslar[i].MyFriend.id;
                            arkdas.AdSoyad = arkadaslar[i].MyFriend.UserDetail.Name + " " + arkadaslar[i].MyFriend.UserDetail.SurName;
                            arkdas.ProfilImage = arkadaslar[i].MyFriend.ProfileImage;
                            arkdas.Online = false;

                            onoff_arkadaslar.Add(arkdas);

                        }

                        return onoff_arkadaslar;
                    }
                    else
                    {
                        for (int i = 0; i < arkadaslar.Count; i++)
                        {
                            arkdas = new OnOffArkadaslar();

                            arkdas.id = arkadaslar[i].MyFriend.id;
                            arkdas.AdSoyad = arkadaslar[i].MyFriend.UserDetail.Name + " " + arkadaslar[i].MyFriend.UserDetail.SurName;
                            arkdas.ProfilImage = arkadaslar[i].MyFriend.ProfileImage;
                            arkdas.Online = true;

                            onoff_arkadaslar.Add(arkdas);

                        }

                        return onoff_arkadaslar;
                    }
                }

            }

            return null;
        }

        public void AcceptFriendRequest(Guid id, Guid userId)
        {
            Friend friend = unitOfWork.Repository<Friend>().Find(x => x.User.id == userId && x.MyFriend.id == id);
            if(friend!=null)
            {
                friend.Durum = true;

                Friend newFriend = new Friend();

                VotedressUser ekleyenUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == id);
                VotedressUser eklenenUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == userId);

                newFriend.User = ekleyenUser;
                newFriend.MyFriend = eklenenUser;
                newFriend.Durum = true;
                newFriend.ArkadaslikTarihi = DateTime.Now;

                unitOfWork.Repository<Friend>().Insert(newFriend);

                unitOfWork.SaveChanges();
            }
        }

        public List<Friend> ArkadaslikIsteklerimiGetir(Guid id)
        {
            return unitOfWork.Repository<Friend>().List(x => x.MyFriend.id == id && x.Durum==false);
        }

        public void AddFriend(Guid id, Guid userId)
        {
            Friend friend = unitOfWork.Repository<Friend>().Find(x=>x.User.id==id && x.MyFriend.id==userId);

            if(friend==null)
            {
                friend = new Friend();

                VotedressUser ekleyenUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == id);
                VotedressUser eklenenUser= unitOfWork.Repository<VotedressUser>().Find(x => x.id == userId);

                friend.User = ekleyenUser;
                friend.MyFriend = eklenenUser;
                friend.Durum = false;
                friend.ArkadaslikTarihi = DateTime.Now;

                unitOfWork.Repository<Friend>().Insert(friend);

                unitOfWork.SaveChanges();

            }
        }

        public Friend ArkadasKontrol(Guid id, Guid alanId)
        {
            return unitOfWork.Repository<Friend>().Find(x => x.User.id == id && x.MyFriend.id == alanId);
        }

        public void DeleteFriend(Guid silenUserId, Guid silinecekArkadasId)
        {
            unitOfWork.Repository<Friend>().Delete(unitOfWork.Repository<Friend>().Find(x => x.User.id == silenUserId && x.MyFriend.id == silinecekArkadasId));
            unitOfWork.Repository<Friend>().Delete(unitOfWork.Repository<Friend>().Find(x => x.User.id == silinecekArkadasId  && x.MyFriend.id == silenUserId));
            unitOfWork.SaveChanges();

        }

        public object ArkadaslarimiGetir(Guid kullaniciId)
        {
            if (kullaniciId != Guid.Empty)
            {
                List<Friend> arkadaslar = unitOfWork.Repository<Friend>().List(x => x.User.id == kullaniciId && x.Durum == true);

                var JsonModel = new
                {

                    arkadaslarim = arkadaslar.Select(x => new
                    {

                        id = x.id,
                    })
                };

                return JsonModel;
            }

            return null;
        }
    }
}