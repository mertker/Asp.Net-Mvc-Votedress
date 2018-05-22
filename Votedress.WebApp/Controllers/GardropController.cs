using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Votedress.BusinessLayer;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.Entities.ViewModellerim;
using Votedress.WebApp.App_Start;

namespace Votedress.WebApp.Controllers
{
    public class GardropController : Controller
    {
        // GET: Gardrop
        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        [OutputCache(Duration = 0, NoStore = true)]
        public ActionResult Index()
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;
            ViewBag.SessionID = user.id.ToString();

            return View();
        }


        [HttpGet]
        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult MagazalariGetir(int page, int CityID, int CountyID, int NeighborhoodID, int FranchiseID)
        {
            int pageSize = 12;
            VotedressUserManager userManager = new VotedressUserManager();
            List<VotedressUser> filtreliMagazalar = userManager.pagerMagazalariGetir(CityID, CountyID, NeighborhoodID, FranchiseID, page, pageSize);

            List<Magazalar_sade> sade_magazalar = filtreliMagazalar.Select(x => new Magazalar_sade
            {

                MagazaGuid = x.id,
                MagazadakilerSayisi = x.OnlineCount,
                SirketAdi = x.UserDetail.CompanyName,
                SirketResmi = x.ProfileImage,
                FranchiseAdi = x.Franchise.FranchiseName,
                FranchiseLogo = x.Franchise.FranchiseLogo,
                TelNo = x.UserDetail.PhoneNumber,
                Adres = x.UserDetail.AdressDetail,
                Sehir = x.UserDetail.City.CityName,
                Ilce = x.UserDetail.County.CountyName,
                Mahalle = x.UserDetail.Neighborhood.NeighborhoodName

            }).ToList();


            return Json(sade_magazalar, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [OutputCache(Duration = 999999999)]
        public JsonResult FranchiseleriGetir()
        {
            FranchiseManager franchiseManager = new FranchiseManager();
            List<Franchise> franchise = franchiseManager.FranchiseleriGetir();

            return Json(franchise, JsonRequestBehavior.AllowGet);
        }

        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        [OutputCache(Duration = 0)]
        public ActionResult Magaza(Guid id)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            ProductManager productManager = new ProductManager();
            List<Product> urunler = productManager.UrunleriGetir(id);


            CollectionManager collectionManager = new CollectionManager();

            List<Category> kategoriler = collectionManager.KategorileriGetir(id);

            var JsonModel = new
            {

                urunler = urunler.Select(x => new
                {

                    id = x.id,
                    productName = x.ProductName,
                    productImage = x.ProductImage,
                    Collections = x.ProductCategory.Select(k => new
                    {
                        id = k.Category.id,
                        collectionName = k.Category.CategoryName,
                        description = k.Category.Description,
                        createDate = k.Category.CreateDate,
                    }),
                    price = x.Price,
                    shortDescription = x.ShortDescription,
                    longDescription = x.LongDescription,
                    uploadDate = x.UploadDate,
                    detail = x.ProductSize.Select(k => new
                    {
                        productSize = k.Size,
                        productColors = k.ProductColor.Select(y => new
                        {
                            stockCount = y.StockCount,
                            color = y.ProductColorDetail.Select(u => new
                            {
                                colorName = u.Color.ColorName,
                                colorCode = u.Color.ColorCode,

                            }),
                            productImageGallery = y.ProdutImageGallery.Select(u => new
                            {
                                id = u.id,
                                imagePath = u.ImagePath
                            })
                        }),
                    }),

                }),

                magazaAdi = urunler[0].User.UserDetail.CompanyName,
                magazaId = urunler[0].User.id,
                kategoriler = kategoriler.Select(k => new
                {
                    id = k.id,
                    collectionName = k.CategoryName,
                    description = k.Description,
                    createDate = k.CreateDate,
                }),


            };

            return View(JsonModel);
        }


        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult UrunFiltrele(int page, Guid magazaId, List<int> renkId, List<Guid> kategoriId, int? enDusukFiyat, int? enYuksekFiyat)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            if (enDusukFiyat == null)
            {
                enDusukFiyat = 0;
            }

            if (enYuksekFiyat == null)
            {
                enYuksekFiyat = 0;
            }

            ProductManager productManager = new ProductManager();
            List<Product> urunler = productManager.SayfalamaliUrunleriGetir(page, 12, magazaId, renkId, kategoriId, enDusukFiyat.Value, enYuksekFiyat.Value);


            CollectionManager collectionManager = new CollectionManager();

            List<Category> kategoriler = collectionManager.KategorileriGetir(magazaId);

            if (urunler.Count != 0)
            {


                var JsonModel = new
                {
                    urunler = urunler.Select(x => new
                    {
                        id = x.id,
                        productName = x.ProductName,
                        productImage = x.ProductImage,
                        Collections = x.ProductCategory.Select(k => new
                        {
                            id = k.Category.id,
                            collectionName = k.Category.CategoryName,
                            description = k.Category.Description,
                            createDate = k.Category.CreateDate,
                        }),
                        price = x.Price,
                        shortDescription = x.ShortDescription,
                        longDescription = x.LongDescription,
                        uploadDate = x.UploadDate,
                        detail = x.ProductSize.Select(k => new
                        {
                            productSize = k.Size,
                            productColors = k.ProductColor.Select(y => new
                            {
                                stockCount = y.StockCount,
                                color = y.ProductColorDetail.Select(u => new
                                {
                                    colorName = u.Color.ColorName,
                                    colorCode = u.Color.ColorCode,
                                }),
                                productImageGallery = y.ProdutImageGallery.Select(u => new
                                {
                                    id = u.id,
                                    imagePath = u.ImagePath
                                })
                            }),
                        }),

                    }),

                    magazaAdi = urunler[0].User.UserDetail.CompanyName,
                    kategoriler = kategoriler.Select(k => new
                    {
                        id = k.id,
                        collectionName = k.CategoryName,
                        description = k.Description,
                        createDate = k.CreateDate,
                    }),

                };

                return Json(JsonModel, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }

        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult UrunDetayiGetir(Guid UrunID)
        {
            ProductManager productManager = new ProductManager();
            Product urun = productManager.UrunGetir(UrunID);

            int commentCount = urun.ProductComment.Count;
            for (int i = 0; i < urun.ProductComment.Count; i++)
            {
                commentCount = commentCount + urun.ProductComment[i].ProductCommentReply.Count();
            }


            SocialShareManager socialShareManager = new SocialShareManager();
            List<SocialShare> urunPaylasimi = socialShareManager.UrunPaylasimlariniGetir(UrunID);

            OylamaManager oylamaMnager = new OylamaManager();
            int urunluOylamalarCount = oylamaMnager.UrunluOylamalariGetir(UrunID).Count();


            int facebookShareCount = urunPaylasimi.Where(x => x.SocialName == "facebook").Count();
            int instagramShareCount = urunPaylasimi.Where(x => x.SocialName == "instagram").Count();
            int twitterShareCount = urunPaylasimi.Where(x => x.SocialName == "twitter").Count();
            int votedressShareCount = urunPaylasimi.Where(x => x.SocialName == "votedress").Count();


            var JsonModel = new
            {
                urun = new
                {
                    id = urun.id,
                    productName = urun.ProductName,
                    productImage = urun.ProductImage,
                    Collections = urun.ProductCollection.Select(k => new
                    {
                        id = k.Collection.id,
                        collectionName = k.Collection.CollectionName,
                        description = k.Collection.Description,
                        createDate = k.Collection.CreateDate,
                    }),
                    price = urun.Price,
                    shortDescription = urun.ShortDescription,
                    longDescription = urun.LongDescription,
                    uploadDate = urun.UploadDate,
                    detail = urun.ProductSize.Select(k => new
                    {
                        productSize = k.Size,
                        productColors = k.ProductColor.Select(y => new
                        {
                            id = y.id,
                            stockCount = y.StockCount,
                            color = y.ProductColorDetail.Select(u => new
                            {
                                colorName = u.Color.ColorName,
                                colorCode = u.Color.ColorCode,
                            }),
                            productImageGallery = y.ProdutImageGallery.Select(u => new
                            {
                                id = u.id,
                                imagePath = u.ImagePath
                            })
                        }),
                    }),
                    urunSosyalGucu = new
                    {
                        facebookShareCount = facebookShareCount,
                        instagramShareCount = instagramShareCount,
                        twitterShareCount = twitterShareCount,
                        votedressShareCount = votedressShareCount,
                        urunluOylamalarCount = urunluOylamalarCount,

                        commentCount = commentCount
                    }
                }
            };

            return Json(JsonModel, JsonRequestBehavior.AllowGet);
        }

        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        public ActionResult UrunDetayliIncele(Guid id)
        {
            ProductManager productManager = new ProductManager();
            Product urun = productManager.UrunGetir(id);

            int commentCount = urun.ProductComment.Count;
            for (int i = 0; i < urun.ProductComment.Count; i++)
            {
                commentCount = commentCount + urun.ProductComment[i].ProductCommentReply.Count();
            }


            SocialShareManager socialShareManager = new SocialShareManager();
            List<SocialShare> urunPaylasimi = socialShareManager.UrunPaylasimlariniGetir(id);

            OylamaManager oylamaMnager = new OylamaManager();
            int urunluOylamalarCount = oylamaMnager.UrunluOylamalariGetir(id).Count();


            int facebookShareCount = urunPaylasimi.Where(x => x.SocialName == "facebook").Count();
            int instagramShareCount = urunPaylasimi.Where(x => x.SocialName == "instagram").Count();
            int twitterShareCount = urunPaylasimi.Where(x => x.SocialName == "twitter").Count();
            int votedressShareCount = urunPaylasimi.Where(x => x.SocialName == "votedress").Count();


            var JsonModel = new
            {
                urun = new
                {
                    id = urun.id,
                    productName = urun.ProductName,
                    productImage = urun.ProductImage,
                    Collections = urun.ProductCollection.Select(k => new
                    {
                        id = k.Collection.id,
                        collectionName = k.Collection.CollectionName,
                        description = k.Collection.Description,
                        createDate = k.Collection.CreateDate,
                    }),
                    price = urun.Price,
                    shortDescription = urun.ShortDescription,
                    longDescription = urun.LongDescription,
                    uploadDate = urun.UploadDate,
                    detail = urun.ProductSize.Select(k => new
                    {
                        productSize = k.Size,
                        productColors = k.ProductColor.Select(y => new
                        {
                            id=y.id,
                            stockCount = y.StockCount,
                            color = y.ProductColorDetail.Select(u => new
                            {
                                colorName = u.Color.ColorName,
                                colorCode = u.Color.ColorCode,
                            }),
                            productImageGallery = y.ProdutImageGallery.Select(u => new
                            {
                                id = u.id,
                                imagePath = u.ImagePath
                            })
                        }),
                    }),
                    urunSosyalGucu = new
                    {
                        facebookShareCount = facebookShareCount,
                        instagramShareCount = instagramShareCount,
                        twitterShareCount = twitterShareCount,
                        votedressShareCount = votedressShareCount,
                        urunluOylamalarCount = urunluOylamalarCount,

                        commentCount = commentCount
                    },
                    comments = urun.ProductComment.OrderBy(x => x.CommentDate).Select(x => new
                    {
                        commentId = x.id,
                        commentOwnerId = x.VotedressUser.id,
                        commentOwnerFullName = x.VotedressUser.UserDetail.Name + " " + x.VotedressUser.UserDetail.SurName,
                        commentOwnerProfilImage = x.VotedressUser.ProfileImage,
                        comment = x.Comment,
                        commentDate = x.CommentDate,
                        commentLikes = x.ProductCommentLike.Select(t => new
                        {
                            LikedFullName = t.VotedressUser.UserDetail.Name + " " + t.VotedressUser.UserDetail.SurName,
                            LikedId = t.VotedressUser.id,
                        }),

                        commentReplies = x.ProductCommentReply.OrderBy(k => k.CommentDate).Select(k => new
                        {
                            commentId = k.id,
                            commentOwnerId = k.VotedressUser.id,
                            commentOwnerFullName = k.VotedressUser.UserDetail.Name + " " + k.VotedressUser.UserDetail.SurName,
                            commentOwnerProfilImage = k.VotedressUser.ProfileImage,
                            comment = k.Comment,
                            commentDate = k.CommentDate,
                            commentLikes = k.ProductCommentReplyLike.Select(t => new
                            {
                                LikedFullName = t.VotedressUser.UserDetail.Name + " " + t.VotedressUser.UserDetail.SurName,
                                LikedId = t.VotedressUser.id,

                            }),
                        })

                    })
                }
            };


            return View(JsonModel);
        }

        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult UrunBilgisiGetir(Guid id)
        {
            ProductManager productManager = new ProductManager();
            Product product = productManager.UrunGetir(id);

            if (product != null)
            {


                string salla = product.ShortDescription;
                if (product.ShortDescription.Length > 15)
                {
                    salla = product.ShortDescription.Substring(1, 14);
                }


                var urunBilgisi = new
                {


                    productId = product.id,
                    productName = product.ProductName,
                    productPrice = product.Price,
                    productCategory = product.ProductCategory.Select(x => new
                    {
                        productCategoryName = x.Category.CategoryName,
                    }),
                    productImage = product.ProductImage,
                    productDescription = salla
                };

                return Json(new { IsSuccess = true, urunBilgisi = urunBilgisi }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { IsSuccess = true }, JsonRequestBehavior.AllowGet);
            }


        }

        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult SepeteEkle(SepeteEkleViewModel sepetIcerigi)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            CartManager cartManager = new CartManager();
            CartDetail cartDetail = cartManager.SepeteUrunEkle(user.id, sepetIcerigi);

            Cart_sade cart_Sade = new Cart_sade()
            {
                id = cartDetail.id,
                Count = cartDetail.ProductCount,
                ProductId = cartDetail.Product.id,
                ProductImage = cartDetail.Product.ProductImage,
                ProductName = cartDetail.Product.ProductName,
                ProductPrice = cartDetail.Product.Price,
                Size = cartDetail.Size,
                ProductColorId = cartDetail.ProductColorId
            };

            return Json(cart_Sade, JsonRequestBehavior.AllowGet);
        }


        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult SepettenSil(int sepetId)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            CartManager cartManager = new CartManager();
            cartManager.SepettenSil(user.id, sepetId);

            return Json(sepetId, JsonRequestBehavior.AllowGet);
        }

        [LoginFilter]
        [BireyselUserFilter]
        [LoglamaFilter]
        public ActionResult OdemeYeri()
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;

            CartManager cartManager = new CartManager();
            Cart cart = cartManager.SepetimiGetir(user.id);

            if (cart != null)
            {



                var JsonModel = new
                {

                    carts = cart.CartDetail.Select(x => new
                    {
                        id = x.id,
                        ProductId = x.Product.id,
                        ProductName = x.Product.ProductName,
                        ProductImage = x.Product.ProductImage,
                        ProductPrice = x.Product.Price,
                        Count = x.ProductCount,
                        ProductColor = x.ProductColor.ProductColorDetail.Select(k => new
                        {
                            colorName = k.Color.ColorName,
                            colorCode = k.Color.ColorCode
                        }),
                        Size = x.Size
                    }),
                    adresses = cart.User.UserAdresses.Select(x => new
                    {

                        id = x.id,
                        AdresBasligi = x.AdressTitle,
                        Adres = x.Adress,
                        Mahalle = x.Neighborhood.NeighborhoodName,
                        Ilce = x.County.CountyName,
                        Sehir = x.City.CityName,
                        TelefonNumarasi = x.PhoneNumber,
                        Email = x.Email,
                        Isim = x.Name,
                        Soyisim = x.SurName,



                    })
                };

                return View(JsonModel);
            }
            else
            {

                return View();
            }

        }


        [LoginFilter]
        [BireyselUserFilter]
        public JsonResult OdemeyiTamamla(CheckoutViewModel newAdress)
        {
            VotedressUser user = new VotedressUser();
            user = Session["login"] as VotedressUser;
            CartManager cartManager = new CartManager();

            if (newAdress.id == 0)
            {
                UserAdressManager userAdressManager = new UserAdressManager();
                UserAdress adress = userAdressManager.AddUserAdress(user.id, newAdress);

                OrderManager orderManager = new OrderManager();
                orderManager.AddOrder(user.id, adress.id);


                cartManager.SepetiBosalt(user.id);

                return Json(true, JsonRequestBehavior.AllowGet);

            }
            else
            {
                OrderManager orderManager = new OrderManager();
                orderManager.AddOrder(user.id, newAdress.id);
                cartManager.SepetiBosalt(user.id);

                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }

    }
}
