using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Votedress.BusinessLayer;
using Votedress.Entities.Modellerim.AdminSayfasiModellerim;
using Votedress.Entities.Modellerim.AdminUrunEkleModellerim;
using Votedress.Entities.Modellerim.BusinessLayerResult;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim.AdminModel;
using Votedress.WebApp.App_Start;

namespace Votedress.WebApp.Controllers
{
    [LoginFilter]
    [KurumsalUserFilter]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            AnalysisManager analysisManager = new AnalysisManager();

            List<chart1Model> chart1Models = analysisManager.chart1VerileriniGetir(user.id);
            List<chart2Model> chart2Models = analysisManager.chart2VerileriniGetir(user.id);
            List<chart3Model> chart3Models = analysisManager.chart3VerileriniGetir(user.id);


            AdminAnasayfaViewModel adminAnasayfaViewModel = new AdminAnasayfaViewModel();


            adminAnasayfaViewModel.chart1Model = chart1Models;
            adminAnasayfaViewModel.chart2Model = chart2Models;
            ViewBag.Index = "active open";


            return View(adminAnasayfaViewModel);




            //var JsonModel = new
            //{
            //    tumSiparisler = orders.Select(x => new
            //    {
            //        SiparisId = x.id,
            //        SiparisTarihi = x.OrderDate,
            //        SiparisVerenTamAd = x.User.UserDetail.Name + " " + x.User.UserDetail.SurName,
            //        SiparisVerenCinsiyet = x.User.UserDetail.Sex,
            //        SiparisVerenYasi = (DateTime.Now.Year - x.User.UserDetail.Birthday.Value.Year),
            //        SiparisVerilenIlKodu = x.User.UserDetail.City.PlateNo,
            //        SiparisVerilenIlAdi = x.User.UserDetail.City.CityName,
            //        SiparisVerilenIlceKodu = x.User.UserDetail.County.CountyID,
            //        SiparisVerilenIlceAdi = x.User.UserDetail.County.CountyName,

            //        SiparisDetayi = x.OrderDetails.Select(k => new
            //        {
            //            SiparisDetayiId = k.id,
            //            SiparisDetayiUrunId = k.Product.id,
            //            SiparisDetayiUrunSahibiId = k.Product.User.id,
            //            SiparisDetayiUrunSahibiSirketAdi = k.Product.User.UserDetail.CompanyName,
            //            SiparisDetayiUrunSahibiMail = k.Product.User.Email,
            //            SiparisDetayiUrunBoyutu = k.Size,
            //            SiparisDetayiUrunRenkKodlari = k.ProductColor.ProductColorDetail.Select(t => new
            //            {
            //                renkKodu = t.Color.ColorCode,
            //                renkAdi = t.Color.ColorName,
            //            }),
            //            SiparisDetayiUrunAdeti = k.ProductCount,
            //            SiparisUrunFiyati = k.Product.Price,
            //            SiparisUrunMaliyeti = k.Product.Cost,
            //            SiparisUrunKategorileri = k.Product.ProductCategory.Select(t => new
            //            {
            //                kategoriAd = t.Category.CategoryName,
            //            })
            //        }),
            //    }),
            //    urunleriminKullanildigiOylamalar = votes.Select(x => new
            //    {
            //        OylamaId = x.id,
            //        OylamaTarihi = x.StartTime,
            //        OylamaSahibininTamAdi = x.User.UserDetail.Name + " " + x.User.UserDetail.SurName,
            //        OylamaSahibininCinsiyeti = x.User.UserDetail.Sex,
            //        OylamaSahibininYasi = (DateTime.Now.Year - x.User.UserDetail.Birthday.Value.Year),
            //        OylamaBaslataninIlKodu = x.User.UserDetail.City.PlateNo,
            //        OylamaBaslataninAdi = x.User.UserDetail.City.CityName,
            //        OylamaBaslataninIlceKodu = x.User.UserDetail.County.CountyID,
            //        OylamaBaslataninIlceAdi = x.User.UserDetail.County.CountyName,

            //        OylamadakiUrunum = x.VoteProduct.Where(t => t.Product.User.id == user.id).Select(t => new
            //        {
            //            UrunId = t.Product.id,
            //            UrunSahibiId = t.Product.User.id,
            //            UrunSahibiAdi = t.Product.User.UserDetail.CompanyName,
            //            UrunAdi = t.Product.ProductName,
            //            UrunOySayisi = t.VoteCount,
            //            UrunFiyati = t.Product.Price,
            //            UrunMaliyeti = t.Product.Cost

            //        })
            //    }),
            //    urunleriminKullanildigiKoleksiyonlar = collections.Select(x => new
            //    {

            //        KoleksiyonId = x.id,
            //        KoleksiyonAdi = x.CollectionName,
            //        KoleksiyonOlusturmaTarihi = x.CreateDate,
            //        KoleksiyonAciklamasi = x.Description,
            //        KoleksiyonSahibiId = x.User.id,
            //        KoleksiyonSahibiTamAd = x.User.UserDetail.Name + " " + x.User.UserDetail.SurName,
            //        KoleksiyonSahibiCinsiyet = x.User.UserDetail.Sex,
            //        KoleksiyonSahibiYas = (DateTime.Now.Year - x.User.UserDetail.Birthday.Value.Year),
            //        KoleksyiondakiUrunler = x.ProductCollection.Select(t => new
            //        {
            //            UrununAdi = t.Product.ProductName,
            //            UrununFiyati = t.Product.Price,
            //            UrununMaliyeti = t.Product.Cost,
            //            UrununKategorileri = t.Product.ProductCategory.Select(l => new
            //            {
            //                KategorAdi = l.Category.CategoryName,
            //            })
            //        })

            //    }),
            //    urunleriminOlduguSepetler = carts.Select(x => new
            //    {
            //        SepetId = x.id,
            //        SepetinSahibiId = x.User.id,
            //        SepetinSahibininTamAdi = x.User.UserDetail.Name + " " + x.User.UserDetail.SurName,
            //        SepetSahibininCinsiyeti = x.User.UserDetail.Sex,
            //        SepetSahibininYasi = (DateTime.Now.Year - x.User.UserDetail.Birthday.Value.Year),
            //        SepetDetayi = x.CartDetail.Select(y => new
            //        {

            //            SepetDetayiId = y.id,
            //            SepetEklenmeTarihi = y.AddToCartDate,
            //            SepettekiUrununRenkleri = y.ProductColor.ProductColorDetail.Select(k => new
            //            {
            //                RenkAdi = k.Color.ColorName,
            //                RenkKodu = k.Color.ColorCode,
            //            }),
            //            SepettekiUrununDetayi = new
            //            {
            //                UrunId = y.Product.id,
            //                UrununAdi = y.Product.ProductName,
            //                UrununMaliyeti = y.Product.Cost,
            //                UrununSatisFiyati = y.Product.Price,

            //                UrunSahibiDetayi = new
            //                {
            //                    UrunSahibiId = y.Product.User.id,
            //                    UrunSirketi = y.Product.User.UserDetail.CompanyName,
            //                    UrunSirketiMail = y.Product.User.Email,
            //                }
            //            },
            //            SepettekiUrununAdeti = y.ProductCount,
            //            SepettekiUrununBoyutu = y.Size,
            //        })
            //    })
            //};


        }


        public ActionResult UrunleriGetir()
        {
            ProductManager res = new ProductManager();

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;


            ViewBag.Urunler = "active open";

            List<Product> products = res.UrunleriGetir(user.id);

            return View(products);

        }


        public ActionResult UrunDetay(Guid urunId)
        {

            ProductManager productManager = new ProductManager();
            Product product = productManager.UrunGetir(urunId);

            UrunDetayViewModel urunDetayViewModel = new UrunDetayViewModel()
            {
                productId = product.id,
                price = product.Price,
                cost = product.Cost,
                productImage = product.ProductImage,
                longdescription = product.LongDescription,
                productName = product.ProductName,
                shortdescription = product.ShortDescription,
                productCategory = product.ProductCategory.Select(x => x.Category.CategoryName).ToList(),
                productDetails = product.ProductSize.Select(x => new ProductDetail()
                {
                    size = x.Size,
                    productColor = x.ProductColor.Select(y => new productColor()
                    {
                        productImageGallery = y.ProdutImageGallery.Select(t => new productImageGallery()
                        {
                            imagePath = t.ImagePath,
                            colorDetail = t.ProductColor.ProductColorDetail.Select(l => new colorDetail()
                            {
                                colorCode = l.Color.ColorCode,
                                colorName = l.Color.ColorName
                            }).ToList()
                        }).ToList()
                    }).ToList()

                }).ToList()

               
                
            };




            return View(urunDetayViewModel);
        }

        public ActionResult UrunEkle()
        {
            ViewBag.Urunler = "active open";
            ProductManager res = new ProductManager();

            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            List<Category> kategoriler = res.KategorileriniGetir(user.id);

            List<Category_sade> category_sades = kategoriler.Select(x => new Category_sade()
            {

                id = x.id,
                CategoryName = x.CategoryName,
                CreateDate = x.CreateDate,
                Description = x.Description

            }).ToList();

            ViewBag.KategoriId = new SelectList(category_sades, "id", "CategoryName");

            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(UrunEkle urun_bilgileri)
        {
            ViewBag.Urunler = "active open";

            ProductManager res = new ProductManager();
            VotedressUser user = new VotedressUser();

            user = Session["login"] as VotedressUser;

            List<Category> kategoriler = res.KategorileriniGetir(user.id);

            ViewBag.KategoriId = new SelectList(kategoriler, "id", "CategoryName");


            bool sonuc = res.UrunEkle(urun_bilgileri, user.id);

            if (sonuc != false)
            {
                ViewBag.UrunEklendiMi = "Ürün Başarıyla Eklendi.";
            }
            else
            {
                ViewBag.UrunEklendiMi = "Ürün Ekleme Başarısız.";
            }

            return View();
        }

        [HttpPost]
        public JsonResult KategoriEkle(KategoriEkle kategori)
        {

            ViewBag.Urunler = "active open";

            VotedressUser user = new VotedressUser();

            user = Session["login"] as VotedressUser;


            CollectionManager res = new CollectionManager();

            CollectionManagerResult res_collection = res.KategoriEkle(kategori, user.id);


            Collection_sade sade_collection = new Collection_sade();

            sade_collection.kategori_id = res_collection.Kategori.id;
            sade_collection.Kategori_adi = res_collection.Kategori.CategoryName;
            sade_collection.Errors = res_collection.Errors;



            return Json(sade_collection, JsonRequestBehavior.AllowGet);
        }

    }
}