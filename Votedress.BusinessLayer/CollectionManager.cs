using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.DataAccessLayer;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.Messages;
using Votedress.Entities.Modellerim.AdminSayfasiModellerim;
using Votedress.Entities.Modellerim.BusinessLayerResult;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.BusinessLayer
{
    public class CollectionManager
    {
        private GenericUnitOfWork unitOfWork = null;
        public CollectionManager()
        {
            unitOfWork = new GenericUnitOfWork();
        }
        public CollectionManagerResult KategoriEkle(KategoriEkle kategori_bilgileri, Guid kullanici_id)
        {
            CollectionManagerResult res = new CollectionManagerResult();


            Category kategori_varmi = unitOfWork.Repository<Category>().Find(x => x.CategoryName == kategori_bilgileri.KategoriAdi);

            if (kategori_varmi == null)
            {

                VotedressUser user = unitOfWork.Repository<VotedressUser>().Find(x => x.id == kullanici_id);

                if (kategori_bilgileri != null && kullanici_id != null)
                {

                    Category kategori = new Category()
                    {
                        id = Guid.NewGuid(),
                        CategoryName = kategori_bilgileri.KategoriAdi,
                        Description = kategori_bilgileri.Aciklama,
                        CreateDate = DateTime.Now,
                        User = user
                    };

                    unitOfWork.Repository<Category>().Insert(kategori);
                    unitOfWork.SaveChanges();

                    res.Kategori = kategori;

                    return res;

                }
            }
            else
            {

                res.AddError(ErrorMessageCode.CollectionNameAlreadyExists, "Bu kategori adı zaten var");

                return res;
            }

            return res;

        }

        public List<Category> KategorileriGetir(Guid magazaId)
        {
            return unitOfWork.Repository<Category>().List(x=>x.User.id == magazaId);
        }


        public List<Collection> UrunKoleksiyonlariGetir(Guid magazaId)
        {
            return unitOfWork.Repository<Collection>().List(x=>x.User.id!=magazaId && x.ProductCollection.Any(k=>k.Product.User.id==magazaId));
        }
    }
}
