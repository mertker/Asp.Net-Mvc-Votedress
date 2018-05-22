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
    public class InVoteChatManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public InVoteChatManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public void AddUserChat(Guid kullanici_id, Guid oylama_id)
        {
            if (Chattemiyim(kullanici_id,oylama_id) == null)
            {
                InVoteChat invotechat = new InVoteChat()
                {
                    User = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici_id),
                    Vote = unitOfWork.Repository<Vote>().Find(x => x.id == oylama_id)
                };

                unitOfWork.Repository<InVoteChat>().Insert(invotechat);
                unitOfWork.SaveChanges();
            }
        }

        public void RemoveUserChat(Guid kullanici_id, Guid oylama_id)
        {

            InVoteChat invotechat = new InVoteChat()
            {
                User = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici_id),
                Vote = unitOfWork.Repository<Vote>().Find(x => x.id == oylama_id)
            };

            unitOfWork.Repository<InVoteChat>().Delete(invotechat);
            unitOfWork.SaveChanges();
        }

        public InVoteChat Chattemiyim(Guid kullanici_id, Guid oylama_id)
        {
            return unitOfWork.Repository<InVoteChat>().Find(x => x.User.id == kullanici_id && x.Vote.id == oylama_id);
        }

        public List<VotedressUser_sade> ChattekileriGetir(Guid oylamaId)
        {

            List<InVoteChat> Chattekiler = unitOfWork.Repository<InVoteChat>().List(x => x.Vote.id == oylamaId).ToList();

            List<VotedressUser_sade> sade_Chattekiler = Chattekiler.Select(x => new VotedressUser_sade()
            {
                id = x.User.id,
                Name = x.User.UserDetail.Name,
                SurName = x.User.UserDetail.SurName,
                Email = x.User.Email,
                SocialId = x.User.SocialId,
                SocialName = x.User.SocialName,
                Sex = x.User.UserDetail.Sex,
                Birthday = x.User.UserDetail.Birthday,
                ProfileImage = x.User.ProfileImage

            }).ToList();

            return sade_Chattekiler;
        }

    }
}
