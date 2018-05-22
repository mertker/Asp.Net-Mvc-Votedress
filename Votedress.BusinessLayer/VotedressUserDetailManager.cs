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
    public class VotedressUserDetailManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public VotedressUserDetailManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public UserDetail GetUserDetail(Guid kullanici_id)
        {
            UserDetail kullanici = unitOfWork.Repository<UserDetail>().Find(x => x.UserId == kullanici_id);
            return kullanici;
        }

        
    }
}
