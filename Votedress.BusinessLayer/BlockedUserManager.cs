using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class BlockedUserManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public BlockedUserManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public bool EngelKontrol(Guid kullanici1, Guid kullanici2)
        {
            BlockedUser banli_mi = unitOfWork.Repository<BlockedUser>().Find(x => x.BlockedUser1.id == kullanici1 && x.BlockingUser.id == kullanici2);

            if (banli_mi == null)
            {
                return false;
            }

            return true;
        }

        public bool EngelKontrolCiftTarafli(Guid kullanici1, Guid kullanici2)
        {
            BlockedUser banli_mi = unitOfWork.Repository<BlockedUser>().Find(x => (x.BlockedUser1.id == kullanici1 && x.BlockingUser.id == kullanici2) || (x.BlockedUser1.id ==kullanici2  && x.BlockingUser.id == kullanici1));

            if (banli_mi == null)
            {
                return false;
            }

            return true;
        }

        public void Engelle(Guid id, Guid engellenenKullaniciId)
        {
            BlockedUser blockedUser= unitOfWork.Repository<BlockedUser>().Find(x => x.BlockingUser.id == id && x.BlockedUser1.id == engellenenKullaniciId);

            if(blockedUser==null)
            {
                unitOfWork.Repository<BlockedUser>().Insert(new BlockedUser()
                {
                    BlockingUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == id),
                    BlockedUser1 = unitOfWork.Repository<VotedressUser>().Find(x => x.id == engellenenKullaniciId),
                    BlockedTime = DateTime.Now
                });

                unitOfWork.SaveChanges();
            }
        }
    }
}
