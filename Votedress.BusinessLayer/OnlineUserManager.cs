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
    public class OnlineUserManager
    {
        private GenericUnitOfWork unitOfWork = null;

        public OnlineUserManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public OnlineUser OnlineKullaniciyiGetir(Guid kullanici_id)
        {
            return unitOfWork.Repository<OnlineUser>().Find(x => x.UserId == kullanici_id);
        }

        public List<OnlineUser> OnlineKullaniciyiGetir(List<Guid> kullanici_idleri)
        {
            return unitOfWork.Repository<OnlineUser>().List(x => kullanici_idleri.Contains(x.UserId));
        }

        public OnlineUser OnlineKullaniciyiGetirConId(string connectionId)
        {
            return unitOfWork.Repository<OnlineUser>().Find(x => x.ConnectionId == connectionId);
        }
    }
}
