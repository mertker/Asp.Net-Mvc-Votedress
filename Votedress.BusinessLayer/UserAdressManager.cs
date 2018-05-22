using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim;

namespace Votedress.BusinessLayer
{
    public class UserAdressManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public UserAdressManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }


        public UserAdress AddUserAdress(Guid userId, CheckoutViewModel checkoutViewModel)
        {
            VotedressUserManager votedressUserManager = new VotedressUserManager();
            VotedressUser votedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == userId);

            if (votedressUser != null)
            {
                UserAdress userAdress = new UserAdress()
                {
                    Adress=checkoutViewModel.Adres,
                    AdressTitle=checkoutViewModel.AdresBasligi,
                    Email=checkoutViewModel.Email,
                    Name=checkoutViewModel.Isim,
                    PhoneNumber=checkoutViewModel.TelefonNumarasi,
                    SurName=checkoutViewModel.Soyisim,
                    User=votedressUser,
                    City=unitOfWork.Repository<City>().Find(x=>x.CityID==checkoutViewModel.Sehir),
                    County = unitOfWork.Repository<County>().Find(x => x.CountyID == checkoutViewModel.Ilce),
                    Neighborhood = unitOfWork.Repository<Neighborhood>().Find(x => x.NeighborhoodID == checkoutViewModel.Mahalle),                  
                };

                userAdress= unitOfWork.Repository<UserAdress>().Insert(userAdress);
                unitOfWork.SaveChanges();

                return userAdress;
            }

            return null;
        }

        public UserAdress GetUserAdress(Guid id, int adressId)
        {
            return unitOfWork.Repository<UserAdress>().Find(x=>x.User.id==id && x.id==adressId);            
        }
    }
}
