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
    public class VoteBannedManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public VoteBannedManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public bool EngelKontrol(Guid kullanici_id,Guid chat_sahibi_id)
        {
            VoteBanned banli_mi = unitOfWork.Repository<VoteBanned>().Find(x => x.BanlananId.id == kullanici_id && x.BanlayanId.id == chat_sahibi_id);

            if(banli_mi==null)
            {
                return false;
            }

            return true;
        }


    }
}
