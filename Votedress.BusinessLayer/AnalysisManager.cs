using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim.AdminModel;

namespace Votedress.BusinessLayer
{
    public class AnalysisManager
    {
        public List<Bolge> bolgelers = new List<Bolge>() {

            new Bolge()
            {
                cityId=1,
                regionName="Akdeniz"
            },

            new Bolge()
            {
                cityId=2,
                regionName="Guney dogu"
            },

            new Bolge()
            {
                cityId=3,
                regionName="Ege"
            },

            new Bolge()
            {
                cityId=4,
                regionName="Karadeniz"
            },

            new Bolge()
            {
                cityId=5,
                regionName="Ic anadolu"
            },

            new Bolge()
            {
                cityId=6,
                regionName="Dogu anadolu"
            },

            new Bolge()
            {
                cityId=7,
                regionName="Ic anadolu"
            },

            new Bolge()
            {
                cityId=8,
                regionName="Akdeniz"
            },

            new Bolge()
            {
                cityId=9,
                regionName="Marmara"
            },
            new Bolge()
            {
                cityId=10,
                regionName="Karadeniz"
            },

        };


        public List<chart1Model> chart1VerileriniGetir(Guid id)
        {
            OrderManager orderManager = new OrderManager();

            List<Order> orders = orderManager.MagazaSiparisleriGetir(id);



            List<chart1Model> localGelirAnalizModels = new List<chart1Model>();
            int kontorl = 0;

            for (int i = 0; i < orders.Count; i++)
            {
                kontorl = 0;
                int yas = chart1Model.YasYuvarla(DateTime.Now.Year - orders[i].User.UserDetail.Birthday.Value.Year);
                for (int j = 0; j < localGelirAnalizModels.Count; j++)
                {
                    if (localGelirAnalizModels[j].BolgeAdi == orders[i].User.UserDetail.City.RegionName && yas == localGelirAnalizModels[j].Yas)
                    {
                        localGelirAnalizModels[j].KisiSayisi++;
                        for (int t = 0; t < orders[i].OrderDetails.Count; t++)
                        {
                            if (orders[i].OrderDetails[t].Product.User.id == id)
                            {
                                localGelirAnalizModels[j].Gelir += orders[i].OrderDetails[t].Product.Price * orders[i].OrderDetails[t].ProductCount;
                            }
                        }

                        kontorl = 1;
                        break;
                    }
                }

                if (kontorl == 0)
                {
                    chart1Model localGelirAnalizModel = new chart1Model()
                    {
                        BolgeAdi = orders[i].User.UserDetail.City.RegionName,
                        SehirAdi = orders[i].User.UserDetail.City.CityName,
                        KisiSayisi = 1,
                        Yas = DateTime.Now.Year - orders[i].User.UserDetail.Birthday.Value.Year
                    };

                    for (int t = 0; t < orders[i].OrderDetails.Count; t++)
                    {
                        if (orders[i].OrderDetails[t].Product.User.id == id)
                        {
                            localGelirAnalizModel.Gelir += orders[i].OrderDetails[t].Product.Price * orders[i].OrderDetails[t].ProductCount;
                        }
                    }

                    localGelirAnalizModels.Add(localGelirAnalizModel);
                }

            }

            return localGelirAnalizModels;
        }

        public List<chart2Model> chart2VerileriniGetir(Guid id)
        {

            OrderManager orderManager = new OrderManager();
            List<chart2Model> analizModeli = new List<chart2Model>() {

                new chart2Model()
                {
                    State="Marmara",
                    freq=new Freq()
                    {
                        beyaz=0,
                        kahverengi=0,
                        kirmizi=0,
                        mavi=0,
                        mor=0,
                        sari=0,
                        siyah=0,
                        yesil=0                     
                    }
                },
                new chart2Model()
                {
                    State="Ege",
                    freq=new Freq()
                    {
                        beyaz=0,
                        kahverengi=0,
                        kirmizi=0,
                        mavi=0,
                        mor=0,
                        sari=0,
                        siyah=0,
                        yesil=0
                    }
                },
                new chart2Model()
                {
                    State="Karadeniz",
                    freq=new Freq()
                    {
                        beyaz=0,
                        kahverengi=0,
                        kirmizi=0,
                        mavi=0,
                        mor=0,
                        sari=0,
                        siyah=0,
                        yesil=0
                    }
                },
                new chart2Model()
                {
                    State="Akdeniz",
                    freq=new Freq()
                    {
                        beyaz=0,
                        kahverengi=0,
                        kirmizi=0,
                        mavi=0,
                        mor=0,
                        sari=0,
                        siyah=0,
                        yesil=0
                    }
                },
                new chart2Model()
                {
                    State="Ic anadolu",
                    freq=new Freq()
                    {
                        beyaz=0,
                        kahverengi=0,
                        kirmizi=0,
                        mavi=0,
                        mor=0,
                        sari=0,
                        siyah=0,
                        yesil=0
                    }
                },
                new chart2Model()
                {
                    State="Dogu anadolu",
                    freq=new Freq()
                    {
                        beyaz=0,
                        kahverengi=0,
                        kirmizi=0,
                        mavi=0,
                        mor=0,
                        sari=0,
                        siyah=0,
                        yesil=0
                    }
                },
                new chart2Model()
                {
                    State="Guney dogu",
                    freq=new Freq()
                    {
                        beyaz=0,
                        kahverengi=0,
                        kirmizi=0,
                        mavi=0,
                        mor=0,
                        sari=0,
                        siyah=0,
                        yesil=0
                    }
                },


            };

            List<Order> orders = orderManager.MagazaSiparisleriGetir(id);

            foreach (var order in orders)
            {

                Bolge bolge = bolgelers.Where(x => x.cityId == order.UserAdress.City.CityID).FirstOrDefault();
                List<OrderDetail> orderDetails = order.OrderDetails.Where(x => x.Product.User.id == id).ToList();


                if(bolge!=null && (orderDetails.Count!=0 || orderDetails!=null))
                {
                    switch (bolge.regionName)
                    {
                        case "Marmara":

                            foreach (var orderDetail in orderDetails)
                            {
                                foreach (var productColorDetail in orderDetail.ProductColor.ProductColorDetail)
                                {
                                    switch (productColorDetail.Color.ColorName)
                                    {
                                        case "Beyaz":

                                            analizModeli.Where(x=>x.State=="Marmara").FirstOrDefault().freq.beyaz++;
                                            break;
                                        case "Siyah":

                                            analizModeli.Where(x => x.State == "Marmara").FirstOrDefault().freq.siyah++;
                                            break;
                                        case "Yeşil":

                                            analizModeli.Where(x => x.State == "Marmara").FirstOrDefault().freq.yesil++;
                                            break;
                                        case "Kirmizi":

                                            analizModeli.Where(x => x.State == "Marmara").FirstOrDefault().freq.kirmizi++;
                                            break;
                                        case "Sarı":

                                            analizModeli.Where(x => x.State == "Marmara").FirstOrDefault().freq.sari++;
                                            break;
                                        case "Mavi":

                                            analizModeli.Where(x => x.State == "Marmara").FirstOrDefault().freq.mavi++;
                                            break;
                                        case "Kahverengi":

                                            analizModeli.Where(x => x.State == "Marmara").FirstOrDefault().freq.kahverengi++;
                                            break;
                                        case "Mor":

                                            analizModeli.Where(x => x.State == "Marmara").FirstOrDefault().freq.mor++;
                                            break;
                                    }
                                }                         
                            }

                            break;
                        case "Ege":

                            foreach (var orderDetail in orderDetails)
                            {
                                foreach (var productColorDetail in orderDetail.ProductColor.ProductColorDetail)
                                {
                                    switch (productColorDetail.Color.ColorName)
                                    {
                                        case "Beyaz":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.beyaz++;
                                            break;
                                        case "Siyah":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.siyah++;
                                            break;
                                        case "Yeşil":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.yesil++;
                                            break;
                                        case "Kirmizi":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.kirmizi++;
                                            break;
                                        case "Sarı":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.sari++;
                                            break;
                                        case "Mavi":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.mavi++;
                                            break;
                                        case "Kahverengi":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.kahverengi++;
                                            break;
                                        case "Mor":

                                            analizModeli.Where(x => x.State == "Ege").FirstOrDefault().freq.mor++;
                                            break;
                                    }
                                }
                            }

                            break;
                        case "Karadeniz":

                            foreach (var orderDetail in orderDetails)
                            {
                                foreach (var productColorDetail in orderDetail.ProductColor.ProductColorDetail)
                                {
                                    switch (productColorDetail.Color.ColorName)
                                    {
                                        case "Beyaz":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.beyaz++;
                                            break;
                                        case "Siyah":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.siyah++;
                                            break;
                                        case "Yeşil":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.yesil++;
                                            break;
                                        case "Kirmizi":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.kirmizi++;
                                            break;
                                        case "Sarı":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.sari++;
                                            break;
                                        case "Mavi":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.mavi++;
                                            break;
                                        case "Kahverengi":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.kahverengi++;
                                            break;
                                        case "Mor":

                                            analizModeli.Where(x => x.State == "Karadeniz").FirstOrDefault().freq.mor++;
                                            break;
                                    }
                                }
                            }

                            break;
                        case "Akdeniz":

                            foreach (var orderDetail in orderDetails)
                            {
                                foreach (var productColorDetail in orderDetail.ProductColor.ProductColorDetail)
                                {
                                    switch (productColorDetail.Color.ColorName)
                                    {
                                        case "Beyaz":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.beyaz++;
                                            break;
                                        case "Siyah":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.siyah++;
                                            break;
                                        case "Yeşil":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.yesil++;
                                            break;
                                        case "Kirmizi":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.kirmizi++;
                                            break;
                                        case "Sarı":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.sari++;
                                            break;
                                        case "Mavi":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.mavi++;
                                            break;
                                        case "Kahverengi":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.kahverengi++;
                                            break;
                                        case "Mor":

                                            analizModeli.Where(x => x.State == "Akdeniz").FirstOrDefault().freq.mor++;
                                            break;
                                    }
                                }
                            }
                            break;
                        case "Guney dogu":

                            foreach (var orderDetail in orderDetails)
                            {
                                foreach (var productColorDetail in orderDetail.ProductColor.ProductColorDetail)
                                {
                                    switch (productColorDetail.Color.ColorName)
                                    {
                                        case "Beyaz":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.beyaz++;
                                            break;
                                        case "Siyah":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.siyah++;
                                            break;
                                        case "Yeşil":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.yesil++;
                                            break;
                                        case "Kirmizi":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.kirmizi++;
                                            break;
                                        case "Sarı":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.sari++;
                                            break;
                                        case "Mavi":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.mavi++;
                                            break;
                                        case "Kahverengi":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.kahverengi++;
                                            break;
                                        case "Mor":

                                            analizModeli.Where(x => x.State == "Guney dogu").FirstOrDefault().freq.mor++;
                                            break;
                                    }
                                }
                            }
                            break;
                        case "Ic anadolu":

                            foreach (var orderDetail in orderDetails)
                            {
                                foreach (var productColorDetail in orderDetail.ProductColor.ProductColorDetail)
                                {
                                    switch (productColorDetail.Color.ColorName)
                                    {
                                        case "Beyaz":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.beyaz++;
                                            break;
                                        case "Siyah":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.siyah++;
                                            break;
                                        case "Yeşil":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.yesil++;
                                            break;
                                        case "Kirmizi":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.kirmizi++;
                                            break;
                                        case "Sarı":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.sari++;
                                            break;
                                        case "Mavi":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.mavi++;
                                            break;
                                        case "Kahverengi":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.kahverengi++;
                                            break;
                                        case "Mor":

                                            analizModeli.Where(x => x.State == "Ic anadolu").FirstOrDefault().freq.mor++;
                                            break;
                                    }
                                }
                            }
                            break;
                        case "Dogu anadolu":

                            foreach (var orderDetail in orderDetails)
                            {
                                foreach (var productColorDetail in orderDetail.ProductColor.ProductColorDetail)
                                {
                                    switch (productColorDetail.Color.ColorName)
                                    {
                                        case "Beyaz":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.beyaz++;
                                            break;
                                        case "Siyah":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.siyah++;
                                            break;
                                        case "Yeşil":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.yesil++;
                                            break;
                                        case "Kirmizi":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.kirmizi++;
                                            break;
                                        case "Sarı":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.sari++;
                                            break;
                                        case "Mavi":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.mavi++;
                                            break;
                                        case "Kahverengi":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.kahverengi++;
                                            break;
                                        case "Mor":

                                            analizModeli.Where(x => x.State == "Dogu anadolu").FirstOrDefault().freq.mor++;
                                            break;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            return analizModeli;
        }

        public List<chart3Model> chart3VerileriniGetir(Guid id)
        {


            return null;
        }
    }

    public class Bolge
    {
        public int cityId { get; set; }
        public string regionName { get; set; }
    }
}
