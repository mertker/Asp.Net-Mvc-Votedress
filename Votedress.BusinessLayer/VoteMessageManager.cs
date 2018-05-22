using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.DataAccessLayer;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class VoteMessageManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public VoteMessageManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public VoteMessage_sade OylamaMesajEkle(Guid gonderen_id, Guid oylama_id, string mesaj)
        {               
            VotedressUser user = unitOfWork.Repository<VotedressUser>().Find(x => x.id == gonderen_id);
            Vote vote = unitOfWork.Repository<Vote>().Find(x => x.id == oylama_id); 

            VoteMessage voteMessage = new VoteMessage();
            voteMessage.Message = mesaj;
            voteMessage.User = user;
            voteMessage.Vote = vote;
            voteMessage.GondermeTarihi = DateTime.Now;

            unitOfWork.Repository<VoteMessage>().Insert(voteMessage);
            unitOfWork.SaveChanges();

            

            VoteMessage_sade voteMessage_sade = new VoteMessage_sade();

            voteMessage_sade.id = voteMessage.id;
            voteMessage_sade.GondermeTarihi = voteMessage.GondermeTarihi;
            voteMessage_sade.Message = voteMessage.Message;
     
            voteMessage_sade.MesajSahibi.id = user.id;
            voteMessage_sade.MesajSahibi.Name = user.UserDetail.Name;
            voteMessage_sade.MesajSahibi.ProfileImage = user.ProfileImage;
            voteMessage_sade.MesajSahibi.Sex = user.UserDetail.Sex;
            voteMessage_sade.MesajSahibi.SocialId = user.SocialId;
            voteMessage_sade.MesajSahibi.SocialName = user.SocialName;
            voteMessage_sade.MesajSahibi.SurName = user.UserDetail.SurName;
            voteMessage_sade.MesajSahibi.Email = user.Email;
            voteMessage_sade.MesajSahibi.Birthday = user.UserDetail.Birthday;
        
            return voteMessage_sade;
        }

        public void OylamadanMesajlariSil(Guid userId, Guid voteId)
        {
            List<VoteMessage> voteMessages = unitOfWork.Repository<VoteMessage>().List(x => x.User.id == userId && x.Vote.id == voteId);
            foreach (var item in voteMessages)
            {
                unitOfWork.Repository<VoteMessage>().Delete(item);
            }
           
            unitOfWork.SaveChanges();
        }
    }
}
