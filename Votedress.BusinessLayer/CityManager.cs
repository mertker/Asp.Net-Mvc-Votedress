using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class CityManager
    {
        private GenericUnitOfWork unitOfWork = null;

        public CityManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }

        public List<City> SehirleriGetir()
        {
            List<City> city = unitOfWork.Repository<City>().List();

            return city;
        }

        public List<County> IlceleriGetir(int id)
        {
            List<County> county = unitOfWork.Repository<County>().List(x=>x.City.CityID==id);

            return county;
        }

        public List<Neighborhood> MahalleleriGetir(int id)
        {
            List<Neighborhood> Neighborhood = unitOfWork.Repository<Neighborhood>().List(x => x.Area.AreaID == id);

            return Neighborhood;
        }
    }
}
