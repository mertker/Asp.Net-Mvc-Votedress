using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class ControllerLoglamaManager
    {
        public void Logla(VotedressUser user,string ControllerName,string ActionName,string Parameter,DateTime CreatedTime)
        {
            GenericUnitOfWork unitOfWork = new GenericUnitOfWork();

            ControllerLoglama loglanmismi = new ControllerLoglama();
            loglanmismi = unitOfWork.Repository<ControllerLoglama>().Find(x => x.KullaniciId == user.id);

            if(loglanmismi!=null && Parameter!="")
            {

                loglanmismi.Burdan = loglanmismi.Buraya;
                loglanmismi.Buraya = ControllerName+"/"+ActionName;
                loglanmismi.CreatedTime = CreatedTime;
                loglanmismi.parameter = Parameter;

                unitOfWork.Repository<ControllerLoglama>().Update(loglanmismi);
                unitOfWork.SaveChanges();
            }
            else if(loglanmismi!=null && Parameter == "")
            {
                loglanmismi.Burdan = loglanmismi.Buraya;
                loglanmismi.Buraya = ControllerName + "/" + ActionName;
                loglanmismi.CreatedTime = CreatedTime;

                unitOfWork.Repository<ControllerLoglama>().Update(loglanmismi);
                unitOfWork.SaveChanges();
            }
            else
            {
                ControllerLoglama eklenecek = new ControllerLoglama()
                {
                    KullaniciId = user.id,
                    Burdan = "",
                    Buraya = ControllerName+"/"+ActionName,
                    parameter=Parameter,
                    CreatedTime = CreatedTime

                };

                unitOfWork.Repository<ControllerLoglama>().Insert(eklenecek);
                unitOfWork.SaveChanges();
            }







        }

        public ControllerLoglama LoglamaGetir(Guid kullaniciId)
        {
            GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
            return unitOfWork.Repository<ControllerLoglama>().Find(x => x.KullaniciId == kullaniciId);

        }
    }
}
