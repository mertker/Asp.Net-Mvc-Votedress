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
    public class WhisperManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public WhisperManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public List<Whisper_sade> GetWhispers(Guid alanId)
        {
            List<Whisper_sade> whisper_Sades = new List<Whisper_sade>();
            List<Whisper> whispers = unitOfWork.Repository<Whisper>().List(x => x.User1.id == alanId && x.WhisperStatus == true);

            foreach (var whisper in whispers)
            {
                int gorulmemisMesajSayisi = unitOfWork.Repository<PrivateMessage>().List(x => (x.AlanId.id == alanId && x.User.id == whisper.User2.id) && x.GorulmeDurumu == false).Count();

                if(whisper.User1.id==alanId)
                {
                    whisper_Sades.Add(new Whisper_sade()
                    {
                        id = whisper.id,
                        UserId = whisper.User2.id,
                        FullName = whisper.User2.UserDetail.Name + " " + whisper.User2.UserDetail.SurName,
                        WhisperStatus = whisper.WhisperStatus,
                        UserProfileImage = whisper.User2.ProfileImage,
                        GorulmemisMesajSayisi = gorulmemisMesajSayisi
                    });
                }
                else
                {
                    whisper_Sades.Add(new Whisper_sade()
                    {
                        id = whisper.id,
                        UserId = whisper.User1.id,
                        FullName = whisper.User1.UserDetail.Name + " " + whisper.User1.UserDetail.SurName,
                        WhisperStatus = whisper.WhisperStatus,
                        UserProfileImage = whisper.User1.ProfileImage,
                        GorulmemisMesajSayisi = gorulmemisMesajSayisi
                    });
                }




            }

            return whisper_Sades;
        }

        public void AddWhisper(Guid user1,Guid user2)
        {
            Whisper whisper = unitOfWork.Repository<Whisper>().Find(x => x.User1.id == user1 && x.User2.id == user2);

            if(whisper==null)
            {
                unitOfWork.Repository<Whisper>().Insert(new Whisper()
                {
                    User1 = unitOfWork.Repository<VotedressUser>().Find(x => x.id == user1),
                    User2 = unitOfWork.Repository<VotedressUser>().Find(x => x.id == user2),
                    WhisperStatus = true,
                });

                unitOfWork.Repository<Whisper>().Insert(new Whisper()
                {
                    User1 = unitOfWork.Repository<VotedressUser>().Find(x => x.id == user2),
                    User2 = unitOfWork.Repository<VotedressUser>().Find(x => x.id == user1),
                    WhisperStatus = true,
                });
            }
            else
            {
                whisper.WhisperStatus = true;

            }

            unitOfWork.SaveChanges();

        }

        public void HideWhisper(Guid id, Guid fisiltiSahibiId)
        {
            Whisper whisper= unitOfWork.Repository<Whisper>().Find(x => (x.User1.id == id && x.User2.id == fisiltiSahibiId));
            if(whisper!=null)
            {
                whisper.WhisperStatus = false;
                unitOfWork.SaveChanges();
            }
        }
        public void DeleteWhisper(Guid id, Guid fisiltiSahibiId)
        {
            Whisper whisper = unitOfWork.Repository<Whisper>().Find(x => (x.User1.id == id && x.User2.id == fisiltiSahibiId));
            if (whisper != null)
            {
                unitOfWork.Repository<Whisper>().Delete(whisper);
                unitOfWork.SaveChanges();
            }
        }

        public void ActivedWhisper(Guid id, Guid fisiltiSahibiId)
        {
            Whisper whisper = unitOfWork.Repository<Whisper>().Find(x => (x.User1.id == id && x.User2.id == fisiltiSahibiId));
            if (whisper != null)
            {
                whisper.WhisperStatus = true;
                unitOfWork.SaveChanges();
            }
        }
    }
}
