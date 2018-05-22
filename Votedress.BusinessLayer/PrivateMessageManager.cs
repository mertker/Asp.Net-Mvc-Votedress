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
    public class PrivateMessageManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public PrivateMessageManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public List<PrivateMessage> MesajlariGetir(Guid session_id, Guid kiminle_id)
        {
            

            if (session_id != null && kiminle_id != null)
            {
                return unitOfWork.Repository<PrivateMessage>().List(x => x.User.id == session_id && x.AlanId.id == kiminle_id || x.User.id == kiminle_id && x.AlanId.id == session_id).OrderBy(x => x.GöndermeTarihi).ToList();
            }

            return null;
        }
        public int MesajGonder(Guid gonderen_id, Guid alan_id, string mesaj, DateTime gonderme_tarihi)
        {
           
          
            PrivateMessage privateMessage = new PrivateMessage();

            VotedressUser gonderen_kullanici =  unitOfWork.Repository<VotedressUser>().Find(x => x.id == gonderen_id);
            VotedressUser alan_kullanici = unitOfWork.Repository<VotedressUser>().Find(x => x.id == alan_id);


            privateMessage.AlanId = alan_kullanici;
            privateMessage.User = gonderen_kullanici;
            privateMessage.Message = mesaj;
            privateMessage.GöndermeTarihi = gonderme_tarihi;
            privateMessage.GorulmeDurumu = false;

            unitOfWork.Repository<PrivateMessage>().Insert(privateMessage);
            unitOfWork.SaveChanges();

            return privateMessage.id;

        }
        public bool MesajGoruldu(int mesaj_id)
        {
            
            PrivateMessage mesaj = unitOfWork.Repository<PrivateMessage>().Find(x => x.id == mesaj_id);

            mesaj.GorulmeDurumu = true;

            unitOfWork.Repository<PrivateMessage>().Update(mesaj);
            int sonuc = unitOfWork.SaveChanges();

            if (sonuc > 0)
            {
                return true;

            }

            return false;

        }

        public List<PrivateMessage> GorulmemisMesajlariGetir(Guid kullanici_id)
        {
            if (kullanici_id != null)
            {
               
                List<PrivateMessage> gorulmemis_mesajlar = unitOfWork.Repository<PrivateMessage>().List(x => x.AlanId.id == kullanici_id && x.GorulmeDurumu == false).ToList();

                List<Guid> kimle = gorulmemis_mesajlar.Where(x => x.AlanId.id == kullanici_id && x.GorulmeDurumu == false).Select(x => x.User.id).Distinct().ToList();
                List<PrivateMessage> gorulmemis_mesajlar2 = new List<PrivateMessage>();

                for (int i = 0; i < kimle.Count; i++)
                {
                    gorulmemis_mesajlar2.Add(gorulmemis_mesajlar.Where(x => x.AlanId.id == kullanici_id && x.User.id == kimle[i]).OrderByDescending(x => x.GöndermeTarihi).FirstOrDefault());

                }

                return gorulmemis_mesajlar2;
            }

            return null;
        }

        public bool MesajlarGoruldu(Guid session_id, Guid kiminle_id)
        {
            if (session_id != null && kiminle_id != null)
            {
                List<PrivateMessage> gorulmemisMesajlar = unitOfWork.Repository<PrivateMessage>().List(x => x.User.id == kiminle_id && x.AlanId.id == session_id && x.GorulmeDurumu==false).ToList();

                for (int i = 0; i < gorulmemisMesajlar.Count; i++)
                {
                    gorulmemisMesajlar[i].GorulmeDurumu = true;
                    unitOfWork.Repository<PrivateMessage>().Update(gorulmemisMesajlar[i]);
                    unitOfWork.SaveChanges();
                }
                return true;
            }

            return false;
        }
    }
}
