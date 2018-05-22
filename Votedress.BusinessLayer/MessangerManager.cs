using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.DataAccessLayer;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class MessangerManager
    {
        private GenericUnitOfWork unitOfWork = null;

        public MessangerManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public int OnlineOl(string connectionId, Guid kullanici_id)
        {
            OnlineUser zaten_onlinemi = unitOfWork.Repository<OnlineUser>().Find(x => x.UserId == kullanici_id);
            if (zaten_onlinemi == null)
            {
                OnlineUser onlineUser = new OnlineUser();


                onlineUser.ConnectionId = connectionId;
                onlineUser.UserId = kullanici_id;
                onlineUser.User = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici_id);
                onlineUser.OnlineOlmaTarihi = DateTime.Now;
                onlineUser.Disconnected = "reflesh";


                unitOfWork.Repository<OnlineUser>().Insert(onlineUser);
                int result = unitOfWork.SaveChanges();

                if (result > 0)
                {
                    return 0;
                }
            }
            else
            {
                zaten_onlinemi.ConnectionId = connectionId;
                zaten_onlinemi.Disconnected = "reflesh";

                unitOfWork.Repository<OnlineUser>().Update(zaten_onlinemi);
                int result2 = unitOfWork.SaveChanges();
                if (result2 > 0)
                {
                    return 1;
                }
            }



            return -1;
        }

        public OnlineUser OfflineOl(Guid kullanici_id)
        {

            OnlineUser zaten_onlinemi = unitOfWork.Repository<OnlineUser>().Find(x => x.UserId == kullanici_id);


            if (zaten_onlinemi == null)
            {
                return zaten_onlinemi;
            }
            else
            {
                unitOfWork.Repository<OnlineUser>().Delete(zaten_onlinemi);
                unitOfWork.SaveChanges();
                return zaten_onlinemi;
            }


        }

        public OnlineUser OnlineMi(Guid kullanici_id)
        {
            
            OnlineUser online_kullanici = unitOfWork.Repository<OnlineUser>().Find(x => x.UserId == kullanici_id);
            return online_kullanici;
        }


        public List<OnlineUser> OnlineArkadaslar(Guid kullanici_id)
        {
           
            List<Friend> arkadaslar = unitOfWork.Repository<Friend>().List(x => x.User.id == kullanici_id).ToList();

            List<Guid> arkadaslar_id = arkadaslar.Select(x => x.MyFriend.id).ToList();

            if (arkadaslar != null)
            {                        
                List<OnlineUser> online_arkadaslar = unitOfWork.Repository<OnlineUser>().List(x => arkadaslar_id.Contains(x.UserId)).ToList();
                return online_arkadaslar;
            }

            return null;
        }

        public Guid fakeOfflineOl(string connectionId)
        {
           
            OnlineUser online_kullanici = unitOfWork.Repository<OnlineUser>().Find(x => x.ConnectionId == connectionId);

            if (online_kullanici != null)
            {
                online_kullanici.Disconnected = "close";
                online_kullanici.ConnectionId = connectionId;
                unitOfWork.Repository<OnlineUser>().Update(online_kullanici);
                unitOfWork.SaveChanges();

                return online_kullanici.UserId;
            }



            return Guid.Empty;
        }

        public string ConnectionIdGetir(Guid kullanici_id)
        {
           OnlineUser onlineUser= unitOfWork.Repository<OnlineUser>().Find(x => x.UserId == kullanici_id);

            return onlineUser.ConnectionId;

        }

    }
}
